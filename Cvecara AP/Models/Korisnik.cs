namespace Cvecara_AP.Models
{
    public class Korisnik
    {
        public int KorisniciId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public string Tip { get; set; }   // KUPAC ili DOBAVLJAC

        public Korisnik() { }

        public Korisnik(int id, string ime, string prezime, string email,
                        string telefon, string adresa, string tip)
        {
            KorisniciId = id;
            Ime = ime;
            Prezime = prezime;
            Email = email;
            Telefon = telefon;
            Adresa = adresa;
            Tip = tip;
        }
    }
}