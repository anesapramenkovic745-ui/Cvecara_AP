using Cvecara_AP.Data;
using Cvecara_AP.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Cvecara_AP.Repositories
{
    public class DobavljacRepository
    {
        public List<Dobavljac> VratiSve()
        {
            List<Dobavljac> lista = new List<Dobavljac>();
            string sql = "SELECT dobavljac_id, naziv, kontakt_osoba, telefon, email, adresa " +
                         "FROM dobavljaci ORDER BY naziv";

            using (MySqlConnection conn = Konekcija.NapraviKonekciju())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                conn.Open();
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        lista.Add(new Dobavljac(
                            Convert.ToInt32(r["dobavljac_id"]),
                            r["naziv"].ToString(),
                            r["kontakt_osoba"] == DBNull.Value ? "" : r["kontakt_osoba"].ToString(),
                            r["telefon"] == DBNull.Value ? "" : r["telefon"].ToString(),
                            r["email"] == DBNull.Value ? "" : r["email"].ToString(),
                            r["adresa"] == DBNull.Value ? "" : r["adresa"].ToString()));
                    }
                }
            }
            return lista;
        }

        public void Dodaj(Dobavljac d)
        {
            string sql = "INSERT INTO dobavljaci (naziv, kontakt_osoba, telefon, email, adresa) " +
                         "VALUES (@naziv, @kontakt, @telefon, @email, @adresa)";
            using (MySqlConnection conn = Konekcija.NapraviKonekciju())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                DodajParametre(cmd, d);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Izmeni(Dobavljac d)
        {
            string sql = "UPDATE dobavljaci SET naziv=@naziv, kontakt_osoba=@kontakt, " +
                         "telefon=@telefon, email=@email, adresa=@adresa " +
                         "WHERE dobavljac_id=@id";
            using (MySqlConnection conn = Konekcija.NapraviKonekciju())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                DodajParametre(cmd, d);
                cmd.Parameters.AddWithValue("@id", d.DobavljacId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Obrisi(int id)
        {
            string sql = "DELETE FROM dobavljaci WHERE dobavljac_id=@id";
            using (MySqlConnection conn = Konekcija.NapraviKonekciju())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void DodajParametre(MySqlCommand cmd, Dobavljac d)
        {
            cmd.Parameters.AddWithValue("@naziv", d.Naziv);
            cmd.Parameters.AddWithValue("@kontakt", d.KontaktOsoba);
            cmd.Parameters.AddWithValue("@telefon", d.Telefon);
            cmd.Parameters.AddWithValue("@email", d.Email);
            cmd.Parameters.AddWithValue("@adresa", d.Adresa);
        }
    }
}