namespace Cvecara_AP.Models
{
    public class KorisnikAplikacije
    {
        public int KorisnikId { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string Uloga { get; set; }
        public int? KupacId { get; set; }

        public KorisnikAplikacije(int korisnikId, string korisnickoIme, string lozinka, string uloga, int? kupacId)
        {
            KorisnikId = korisnikId;
            KorisnickoIme = korisnickoIme;
            Lozinka = lozinka;
            Uloga = uloga;
            KupacId = kupacId;
        }

        public bool JeAdmin()
        {
            return Uloga == "ADMIN";
        }
    }
}