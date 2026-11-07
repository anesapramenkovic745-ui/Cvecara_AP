using Cvecara_AP.Data;
using Cvecara_AP.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Cvecara_AP.Repositories
{
    public class KorisnikRepository
    {
        // Vraća sve korisnike zadatog tipa (KUPAC ili DOBAVLJAC)
        public List<Korisnik> VratiSve(string tip)
        {
            List<Korisnik> lista = new List<Korisnik>();
            string sql = "SELECT korisnici_id, ime, prezime, email, telefon, adresa, tip " +
                         "FROM korisnici WHERE tip = @tip ORDER BY prezime, ime";

            using (MySqlConnection conn = Konekcija.NapraviKonekciju())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@tip", tip);
                conn.Open();
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        lista.Add(new Korisnik(
                            Convert.ToInt32(r["korisnici_id"]),
                            r["ime"].ToString(),
                            r["prezime"] == DBNull.Value ? "" : r["prezime"].ToString(),
                            r["email"] == DBNull.Value ? "" : r["email"].ToString(),
                            r["telefon"] == DBNull.Value ? "" : r["telefon"].ToString(),
                            r["adresa"] == DBNull.Value ? "" : r["adresa"].ToString(),
                            r["tip"].ToString()));
                    }
                }
            }
            return lista;
        }

        public void Dodaj(Korisnik k)
        {
            string sql = "INSERT INTO korisnici (ime, prezime, email, telefon, adresa, tip) " +
                         "VALUES (@ime, @prezime, @email, @telefon, @adresa, @tip)";
            using (MySqlConnection conn = Konekcija.NapraviKonekciju())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                DodajParametre(cmd, k);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Izmeni(Korisnik k)
        {
            string sql = "UPDATE korisnici SET ime=@ime, prezime=@prezime, email=@email, " +
                         "telefon=@telefon, adresa=@adresa WHERE korisnici_id=@id";
            using (MySqlConnection conn = Konekcija.NapraviKonekciju())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                DodajParametre(cmd, k);
                cmd.Parameters.AddWithValue("@id", k.KorisniciId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Obrisi(int id)
        {
            string sql = "DELETE FROM korisnici WHERE korisnici_id=@id";
            using (MySqlConnection conn = Konekcija.NapraviKonekciju())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void DodajParametre(MySqlCommand cmd, Korisnik k)
        {
            cmd.Parameters.AddWithValue("@ime", k.Ime);
            cmd.Parameters.AddWithValue("@prezime", k.Prezime);
            cmd.Parameters.AddWithValue("@email", k.Email);
            cmd.Parameters.AddWithValue("@telefon", k.Telefon);
            cmd.Parameters.AddWithValue("@adresa", k.Adresa);
            cmd.Parameters.AddWithValue("@tip", k.Tip);
        }
    }
}