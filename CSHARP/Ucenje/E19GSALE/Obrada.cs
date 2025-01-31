using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.E19GSALE
{
    public class Obrada<T> : ISucelje where T : Entitet
    {

        public T? PredmetObrade { get; set; }

        public void OdradiPosao()
        {
            Posao();
        }

        public void Posao()
        {
            Console.WriteLine(PredmetObrade?.Sifra);
        }

        // u programiranju se rijetko kada nesto briše, uvijek se dodaje
        // ova metoda je deprecated
        [Obsolete("Koristi metodu Job()")] // atributi se stavljaju iznad metode i oni su uputa 3rd party alatima
        public void Job()
        {
            Console.WriteLine("Stara metoda");
        }

    }
}
