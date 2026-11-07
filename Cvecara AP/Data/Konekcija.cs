using MySql.Data.MySqlClient;

namespace Cvecara_AP.Data
{
    public static class Konekcija
    {
        // XAMPP podešavanja: korisnik root, bez lozinke
        private static readonly string connectionString =
            "Server=localhost;Port=3306;Database=cvecara2;Uid=root;Pwd=;CharSet=utf8mb4;SslMode=Disabled;";

        // Pravi novu konekciju (koristiće je svaki repozitorijum)
        public static MySqlConnection NapraviKonekciju()
        {
            return new MySqlConnection(connectionString);
        }

        // Proverava da li veza sa bazom radi
        public static bool Testiraj(out string poruka)
        {
            try
            {
                using (MySqlConnection conn = NapraviKonekciju())
                {
                    conn.Open();
                    poruka = "Veza sa bazom cvecara2 uspešno radi!";
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                poruka = "Greška: " + ex.Message;
                return false;
            }
        }
    }
}