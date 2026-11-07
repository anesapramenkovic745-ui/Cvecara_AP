using Cvecara_AP.Data;
using Cvecara_AP.Models;
using MySql.Data.MySqlClient;
using System;

namespace Cvecara_AP.Repositories
{
    public class KorisnikAplikacijeRepository
    {
        // Vraća korisnika ako su podaci tačni, a ako nisu vraća null
        public KorisnikAplikacije Prijavi(string korisnickoIme, string lozinka)
        {
            string sql = "SELECT korisnik_id, korisnicko_ime, lozinka, uloga, kupac_id " +
                         "FROM korisnici_aplikacije " +
                         "WHERE korisnicko_ime = @ime AND lozinka = @lozinka";

            using (MySqlConnection conn = Konekcija.NapraviKonekciju())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                // parametrizovan upit (štiti od SQL injection-a)
                cmd.Parameters.AddWithValue("@ime", korisnickoIme);
                cmd.Parameters.AddWithValue("@lozinka", lozinka);

                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int? kupacId = null;
                        if (reader["kupac_id"] != DBNull.Value)
                            kupacId = Convert.ToInt32(reader["kupac_id"]);

                        return new KorisnikAplikacije(
                            Convert.ToInt32(reader["korisnik_id"]),
                            reader["korisnicko_ime"].ToString(),
                            reader["lozinka"].ToString(),
                            reader["uloga"].ToString(),
                            kupacId);
                    }
                }
            }
            return null;
        }
    }
}