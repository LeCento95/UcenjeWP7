namespace WebAPI9.Models
{
    public class Osoba
    {
        public int Sifra { get; set; }
        public string Ime { get; set; } = "";
        public string? Prezime { get; set; }
        public DateTime Datum { get; set; } = DateTime.Now;
        public bool Aktivan { get; set; }

    }
}
