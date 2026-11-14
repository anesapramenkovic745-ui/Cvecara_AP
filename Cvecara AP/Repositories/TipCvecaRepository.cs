using Cvecara_AP.Data;
using Cvecara_AP.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Cvecara_AP.Repositories
{
    public class TipCvecaRepository
    {
        public List<TipCveca> VratiSve()
        {
            List<TipCveca> lista = new List<TipCveca>();
            string sql = "SELECT tip_id, naziv FROM tipovi_cveca ORDER BY tip_id";

            using (MySqlConnection conn = Konekcija.NapraviKonekciju())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                conn.Open();
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        lista.Add(new TipCveca(
                            Convert.ToInt32(r["tip_id"]),
                            r["naziv"].ToString()));
                    }
                }
            }
            return lista;
        }

        public void Dodaj(TipCveca t)
        {
            string sql = "INSERT INTO tipovi_cveca (naziv) VALUES (@naziv)";
            using (MySqlConnection conn = Konekcija.NapraviKonekciju())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@naziv", t.Naziv);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Izmeni(TipCveca t)
        {
            string sql = "UPDATE tipovi_cveca SET naziv=@naziv WHERE tip_id=@id";
            using (MySqlConnection conn = Konekcija.NapraviKonekciju())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@naziv", t.Naziv);
                cmd.Parameters.AddWithValue("@id", t.TipId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Obrisi(int id)
        {
            string sql = "DELETE FROM tipovi_cveca WHERE tip_id=@id";
            using (MySqlConnection conn = Konekcija.NapraviKonekciju())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}