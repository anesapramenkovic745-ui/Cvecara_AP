using Cvecara_AP.Data;
using Cvecara_AP.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Cvecara_AP.Repositories
{
    public class PorudzbinaRepository
    {
        // tekst = deo imena/prezimena kupca ili broj porudžbine (može biti prazan)
        // od / do = opcioni datumi (null ako nisu izabrani)
        public List<Porudzbina> Pretrazi(string tekst, DateTime? od, DateTime? @do)
        {
            List<Porudzbina> lista = new List<Porudzbina>();

            string sql =
                "SELECT p.porudzbina_id, CONCAT(k.ime, ' ', IFNULL(k.prezime, '')) AS kupac, " +
                "p.datum, p.ukupna_cena " +
                "FROM porudzbine p JOIN korisnici k ON k.korisnici_id = p.kupac_id " +
                "WHERE 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(tekst))
                sql += "AND (k.ime LIKE @tekst OR k.prezime LIKE @tekst " +
                       "OR CAST(p.porudzbina_id AS CHAR) = @broj) ";
            if (od.HasValue)
                sql += "AND p.datum >= @od ";
            if (@do.HasValue)
                sql += "AND p.datum <= @do ";

            sql += "ORDER BY p.porudzbina_id";

            using (MySqlConnection conn = Konekcija.NapraviKonekciju())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                if (!string.IsNullOrWhiteSpace(tekst))
                {
                    cmd.Parameters.AddWithValue("@tekst", "%" + tekst.Trim() + "%");
                    cmd.Parameters.AddWithValue("@broj", tekst.Trim());
                }
                if (od.HasValue)
                    cmd.Parameters.AddWithValue("@od", od.Value.Date);
                if (@do.HasValue)
                    cmd.Parameters.AddWithValue("@do", @do.Value.Date);

                conn.Open();
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        Porudzbina p = new Porudzbina();
                        p.PorudzbinaId = Convert.ToInt32(r["porudzbina_id"]);
                        p.Kupac = r["kupac"].ToString();
                        p.Datum = Convert.ToDateTime(r["datum"]);
                        p.UkupnaCena = Convert.ToDecimal(r["ukupna_cena"]);
                        lista.Add(p);
                    }
                }
            }
            return lista;
        }

        public List<StavkaPorudzbine> VratiStavke(int porudzbinaId)
        {
            List<StavkaPorudzbine> lista = new List<StavkaPorudzbine>();

            string sql =
                "SELECT c.naziv, c.boja, s.kolicina, s.cena_po_jedinici, " +
                "s.kolicina * s.cena_po_jedinici AS iznos " +
                "FROM stavke_porudzbine s JOIN cvece c ON c.cvece_id = s.cvece_id " +
                "WHERE s.porudzbina_id = @id ORDER BY s.stavke_porudzbine_id";

            using (MySqlConnection conn = Konekcija.NapraviKonekciju())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", porudzbinaId);
                conn.Open();
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        StavkaPorudzbine s = new StavkaPorudzbine();
                        s.Naziv = r["naziv"].ToString();
                        s.Boja = r["boja"].ToString();
                        s.Kolicina = Convert.ToInt32(r["kolicina"]);
                        s.CenaPoJedinici = Convert.ToDecimal(r["cena_po_jedinici"]);
                        s.Iznos = Convert.ToDecimal(r["iznos"]);
                        lista.Add(s);
                    }
                }
            }
            return lista;
        }

        // Kreira porudžbinu, stavke i smanjuje stanje, sve u jednoj transakciji.
        // Vraća broj nove porudžbine.
        public int Kupi(int kupacId, List<StavkaKorpe> korpa)
        {
            using (MySqlConnection conn = Konekcija.NapraviKonekciju())
            {
                conn.Open();
                using (MySqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        decimal ukupno = 0;
                        foreach (StavkaKorpe s in korpa)
                            ukupno += s.Iznos;

                        // 1. zaglavlje porudžbine
                        long porudzbinaId;
                        using (MySqlCommand cmd = new MySqlCommand(
                            "INSERT INTO porudzbine (kupac_id, datum, ukupna_cena) " +
                            "VALUES (@kupac, @datum, @ukupno)", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@kupac", kupacId);
                            cmd.Parameters.AddWithValue("@datum", DateTime.Now.Date);
                            cmd.Parameters.AddWithValue("@ukupno", ukupno);
                            cmd.ExecuteNonQuery();
                            porudzbinaId = cmd.LastInsertedId;
                        }

                        foreach (StavkaKorpe s in korpa)
                        {
                            // 2. smanjenje stanja (samo ako ima dovoljno)
                            int izmenjeno;
                            using (MySqlCommand cmd = new MySqlCommand(
                                "UPDATE cvece SET kolicina = kolicina - @kol " +
                                "WHERE cvece_id = @id AND kolicina >= @kol", conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@kol", s.Kolicina);
                                cmd.Parameters.AddWithValue("@id", s.CveceId);
                                izmenjeno = cmd.ExecuteNonQuery();
                            }

                            if (izmenjeno == 0)
                                throw new Exception("Nema dovoljno na stanju za: " + s.Naziv);

                            // 3. stavka porudžbine
                            using (MySqlCommand cmd = new MySqlCommand(
                                "INSERT INTO stavke_porudzbine " +
                                "(porudzbina_id, cvece_id, kolicina, cena_po_jedinici) " +
                                "VALUES (@por, @cvece, @kol, @cena)", conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@por", porudzbinaId);
                                cmd.Parameters.AddWithValue("@cvece", s.CveceId);
                                cmd.Parameters.AddWithValue("@kol", s.Kolicina);
                                cmd.Parameters.AddWithValue("@cena", s.Cena);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                        return (int)porudzbinaId;
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}