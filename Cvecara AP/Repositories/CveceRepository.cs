using Cvecara_AP.Data;
using Cvecara_AP.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Cvecara_AP.Repositories
{
    public class CveceRepository
    {
        public List<Cvece> VratiSve()
        {
            List<Cvece> lista = new List<Cvece>();
            string sql =
                "SELECT c.cvece_id, c.naziv, c.boja, c.cena, c.kolicina, c.dobavljac_id, " +
                "d.naziv AS dobavljac, " +
                "(SELECT GROUP_CONCAT(t.naziv ORDER BY t.naziv SEPARATOR ', ') " +
                " FROM cvece_tipovi ct JOIN tipovi_cveca t ON t.tip_id = ct.tip_id " +
                " WHERE ct.cvece_id = c.cvece_id) AS tipovi " +
                "FROM cvece c LEFT JOIN dobavljaci d ON d.dobavljac_id = c.dobavljac_id " +
                "ORDER BY c.cvece_id";

            using (MySqlConnection conn = Konekcija.NapraviKonekciju())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                conn.Open();
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        Cvece c = new Cvece();
                        c.CveceId = Convert.ToInt32(r["cvece_id"]);
                        c.Naziv = r["naziv"].ToString();
                        c.Boja = r["boja"].ToString();
                        c.Cena = Convert.ToDecimal(r["cena"]);
                        c.Kolicina = Convert.ToInt32(r["kolicina"]);
                        c.DobavljacId = Convert.ToInt32(r["dobavljac_id"]);
                        c.Dobavljac = r["dobavljac"] == DBNull.Value ? "" : r["dobavljac"].ToString();
                        c.Tipovi = r["tipovi"] == DBNull.Value ? "" : r["tipovi"].ToString();
                        lista.Add(c);
                    }
                }
            }
            return lista;
        }

        // ID-evi tipova koje ovo cveće ima (za štikliranje kvačica)
        public List<int> VratiTipIds(int cveceId)
        {
            List<int> ids = new List<int>();
            string sql = "SELECT tip_id FROM cvece_tipovi WHERE cvece_id = @id";

            using (MySqlConnection conn = Konekcija.NapraviKonekciju())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", cveceId);
                conn.Open();
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                        ids.Add(Convert.ToInt32(r["tip_id"]));
                }
            }
            return ids;
        }

        public void Dodaj(Cvece c, List<int> tipIds)
        {
            using (MySqlConnection conn = Konekcija.NapraviKonekciju())
            {
                conn.Open();
                using (MySqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        string sql = "INSERT INTO cvece (naziv, boja, cena, kolicina, dobavljac_id) " +
                                     "VALUES (@naziv, @boja, @cena, @kolicina, @dobavljac)";
                        long noviId;
                        using (MySqlCommand cmd = new MySqlCommand(sql, conn, tran))
                        {
                            DodajParametre(cmd, c);
                            cmd.ExecuteNonQuery();
                            noviId = cmd.LastInsertedId;
                        }

                        UpisiTipove(conn, tran, (int)noviId, tipIds);
                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Izmeni(Cvece c, List<int> tipIds)
        {
            using (MySqlConnection conn = Konekcija.NapraviKonekciju())
            {
                conn.Open();
                using (MySqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        string sql = "UPDATE cvece SET naziv=@naziv, boja=@boja, cena=@cena, " +
                                     "kolicina=@kolicina, dobavljac_id=@dobavljac WHERE cvece_id=@id";
                        using (MySqlCommand cmd = new MySqlCommand(sql, conn, tran))
                        {
                            DodajParametre(cmd, c);
                            cmd.Parameters.AddWithValue("@id", c.CveceId);
                            cmd.ExecuteNonQuery();
                        }

                        // stare tipove brišemo i upisujemo izabrane iznova
                        using (MySqlCommand cmd = new MySqlCommand(
                            "DELETE FROM cvece_tipovi WHERE cvece_id=@id", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@id", c.CveceId);
                            cmd.ExecuteNonQuery();
                        }

                        UpisiTipove(conn, tran, c.CveceId, tipIds);
                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Obrisi(int id)
        {
            using (MySqlConnection conn = Konekcija.NapraviKonekciju())
            {
                conn.Open();
                using (MySqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        using (MySqlCommand cmd = new MySqlCommand(
                            "DELETE FROM cvece_tipovi WHERE cvece_id=@id", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                        using (MySqlCommand cmd = new MySqlCommand(
                            "DELETE FROM cvece WHERE cvece_id=@id", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        private void UpisiTipove(MySqlConnection conn, MySqlTransaction tran, int cveceId, List<int> tipIds)
        {
            foreach (int tipId in tipIds)
            {
                using (MySqlCommand cmd = new MySqlCommand(
                    "INSERT INTO cvece_tipovi (cvece_id, tip_id) VALUES (@cvece, @tip)", conn, tran))
                {
                    cmd.Parameters.AddWithValue("@cvece", cveceId);
                    cmd.Parameters.AddWithValue("@tip", tipId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void DodajParametre(MySqlCommand cmd, Cvece c)
        {
            cmd.Parameters.AddWithValue("@naziv", c.Naziv);
            cmd.Parameters.AddWithValue("@boja", c.Boja);
            cmd.Parameters.AddWithValue("@cena", c.Cena);
            cmd.Parameters.AddWithValue("@kolicina", c.Kolicina);
            cmd.Parameters.AddWithValue("@dobavljac", c.DobavljacId);
        }
    }
}