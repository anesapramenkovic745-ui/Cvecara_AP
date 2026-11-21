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
                        lista.Add(NapraviCvece(r));
                    }
                }
            }
            return lista;
        }

        // Ponuda za kupca: samo cveće koje ima na stanju, sa filterima
        // tipId = 0 znači "svi tipovi"; cenaOd / cenaDo = 0 znači "bez ograničenja"
        public List<Cvece> Pretrazi(string naziv, string boja, decimal cenaOd, decimal cenaDo, int tipId)
        {
            List<Cvece> lista = new List<Cvece>();

            string sql =
                "SELECT c.cvece_id, c.naziv, c.boja, c.cena, c.kolicina, c.dobavljac_id, " +
                "d.naziv AS dobavljac, " +
                "(SELECT GROUP_CONCAT(t.naziv ORDER BY t.naziv SEPARATOR ', ') " +
                " FROM cvece_tipovi ct JOIN tipovi_cveca t ON t.tip_id = ct.tip_id " +
                " WHERE ct.cvece_id = c.cvece_id) AS tipovi " +
                "FROM cvece c LEFT JOIN dobavljaci d ON d.dobavljac_id = c.dobavljac_id " +
                "WHERE c.kolicina > 0 ";

            if (!string.IsNullOrWhiteSpace(naziv))
                sql += "AND c.naziv LIKE @naziv ";
            if (!string.IsNullOrWhiteSpace(boja))
                sql += "AND c.boja LIKE @boja ";
            if (cenaOd > 0)
                sql += "AND c.cena >= @cenaOd ";
            if (cenaDo > 0)
                sql += "AND c.cena <= @cenaDo ";
            if (tipId > 0)
                sql += "AND EXISTS (SELECT 1 FROM cvece_tipovi x " +
                       "WHERE x.cvece_id = c.cvece_id AND x.tip_id = @tipId) ";

            sql += "ORDER BY c.naziv";

            using (MySqlConnection conn = Konekcija.NapraviKonekciju())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                if (!string.IsNullOrWhiteSpace(naziv))
                    cmd.Parameters.AddWithValue("@naziv", "%" + naziv.Trim() + "%");
                if (!string.IsNullOrWhiteSpace(boja))
                    cmd.Parameters.AddWithValue("@boja", "%" + boja.Trim() + "%");
                if (cenaOd > 0)
                    cmd.Parameters.AddWithValue("@cenaOd", cenaOd);
                if (cenaDo > 0)
                    cmd.Parameters.AddWithValue("@cenaDo", cenaDo);
                if (tipId > 0)
                    cmd.Parameters.AddWithValue("@tipId", tipId);

                conn.Open();
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        lista.Add(NapraviCvece(r));
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

        // Pravi objekat Cvece iz trenutnog reda čitača (koriste VratiSve i Pretrazi)
        private Cvece NapraviCvece(MySqlDataReader r)
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
            return c;
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