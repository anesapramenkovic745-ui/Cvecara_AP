namespace Cvecara_AP.Models
{
    public class StavkaPorudzbine
    {
        public string Naziv { get; set; }
        public string Boja { get; set; }
        public int Kolicina { get; set; }
        public decimal CenaPoJedinici { get; set; }
        public decimal Iznos { get; set; }

        public StavkaPorudzbine() { }
    }
}