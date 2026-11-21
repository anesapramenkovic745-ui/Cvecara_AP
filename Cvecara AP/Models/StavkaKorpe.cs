namespace Cvecara_AP.Models
{
    public class StavkaKorpe
    {
        public int CveceId { get; set; }
        public string Naziv { get; set; }
        public string Boja { get; set; }
        public decimal Cena { get; set; }
        public int Kolicina { get; set; }
        public decimal Iznos { get { return Cena * Kolicina; } }

        public StavkaKorpe() { }
    }
}