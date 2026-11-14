namespace Cvecara_AP.Models
{
    public class TipCveca
    {
        public int TipId { get; set; }
        public string Naziv { get; set; }

        public TipCveca() { }

        public TipCveca(int id, string naziv)
        {
            TipId = id;
            Naziv = naziv;
        }

        // Da se u listama (ComboBox, CheckedListBox) prikaže naziv
        public override string ToString()
        {
            return Naziv;
        }
    }
}