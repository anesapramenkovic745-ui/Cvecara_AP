using System.ComponentModel;

namespace Cvecara_AP.Models
{
    public class Cvece
    {
        public int CveceId { get; set; }
        public string Naziv { get; set; }
        public string Boja { get; set; }
        public decimal Cena { get; set; }
        public int Kolicina { get; set; }

        [Browsable(false)]
        public int DobavljacId { get; set; }

        public string Dobavljac { get; set; }   // naziv dobavljača (za prikaz)
        public string Tipovi { get; set; }      // nazivi tipova spojeni zarezom (za prikaz)

        public Cvece() { }
    }
}