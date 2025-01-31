namespace Ucenje.E18NasljedivanjePolimorfizam.edunova
{
    public abstract class KlasaNaziv : Entitet
    {
        public string Naziv { get; set; } = "";

        override public string ToString()
        {
            return Naziv;
        }
    }
}
