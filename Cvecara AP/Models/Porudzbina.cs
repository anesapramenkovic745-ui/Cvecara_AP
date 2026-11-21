using System;

namespace Cvecara_AP.Models
{
    public class Porudzbina
    {
        public int PorudzbinaId { get; set; }
        public string Kupac { get; set; }
        public DateTime Datum { get; set; }
        public decimal UkupnaCena { get; set; }

        public Porudzbina() { }
    }
}