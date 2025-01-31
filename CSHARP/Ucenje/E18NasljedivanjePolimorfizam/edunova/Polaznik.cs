namespace Ucenje.E18NasljedivanjePolimorfizam.edunova
{
    public class Polaznik : Entitet
    {
        public string Ime { get; set; } = "";
        public string Prezime { get; set; } = "";
        public string? Oib { get; set; }
        public string Email { get; set; } = "";

        override public string ToString()
        {
            return $"{Ime} {Prezime}";
        }
    }
}
