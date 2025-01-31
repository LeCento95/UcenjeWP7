using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.E19GSALE
{
    public static class Ekstenzije
    {
        public static void Ispis(this Entitet entitet)
        {
            Console.WriteLine("Ispis iz ekstenzije");
            Console.WriteLine(entitet.Sifra);
        }

        public static void Odradi(this ISucelje sucelje)
        {
            Console.WriteLine("Odraðujem posao u ekstenziji");
            sucelje.OdradiPosao();
            Console.WriteLine("Odradio sam posao u ekstenziji");
        }
    }
}
