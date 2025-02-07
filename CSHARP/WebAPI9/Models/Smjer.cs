namespace WebAPI9.Models
{
    public class Smjer:Entitet
    {

        public Smjer() {
            Vaucer = false;
            Cijena = 0;
            IzvodiSeOd = DateTime.Now;
            DatumPromjene = DateTime.Now;
        }

        public string? Naziv { get; set; }
        public float? Cijena { get; set; }
        public DateTime? IzvodiSeOd { get; set; }
        public bool? Vaucer { get; set; }

        public DateTime? DatumPromjene { get; set; }

        public override string ToString()
        {
            return "Sifra=" + Sifra + " ,Naziv=" + Naziv + ", Cijena=" + Cijena +
                ", IzvodiSeOd=" + IzvodiSeOd + ", Verificiran=" + Vaucer; 
        }

    }
}
