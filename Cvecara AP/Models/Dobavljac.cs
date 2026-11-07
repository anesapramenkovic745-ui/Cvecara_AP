namespace Cvecara_AP.Models
{
    public class Dobavljac
    {
        public int DobavljacId { get; set; }
        public string Naziv { get; set; }
        public string KontaktOsoba { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Adresa { get; set; }

        public Dobavljac() { }

        public Dobavljac(int id, string naziv, string kontaktOsoba,
                         string telefon, string email, string adresa)
        {
            DobavljacId = id;
            Naziv = naziv;
            KontaktOsoba = kontaktOsoba;
            Telefon = telefon;
            Email = email;
            Adresa = adresa;
        }

        // Da bi se u padajućoj listi (ComboBox) prikazao naziv
        public override string ToString()
        {
            return Naziv;
        }
    }
}