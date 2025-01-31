namespace Ucenje.E18NasljedivanjePolimorfizam.edunova
{
    public class Grupa : KlasaNaziv
    {
        public Smjer Smjer { get; set; } = new Smjer(); // veza 1:n
        public string? Predavac { get; set; }
        public Polaznik[]? Polaznici { get; set; } // veza n:n
    }
}
