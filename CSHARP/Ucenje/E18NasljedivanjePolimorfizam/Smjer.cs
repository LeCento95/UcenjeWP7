using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.E18NasljedivanjePolimorfizam
{
    public class Smjer : Entitet // Klasa Smjer nasljeduje klasu Entitet, sva njezina javna i zasticena svojstva i metode
    {
        // svojstvo
        public string? Naziv { get; set; }

        // konstruktor
        public Smjer() // bez da kazem :base() poziva se prazan konstruktor nadklase - OVO MI SE BAS I NE SVIDA
        {
            Console.WriteLine("Pozivam konstruktor klase Smjer");
        }

        public Smjer(int sifra,string naziv): base(sifra)
        {
            // los nacin
            //Sifra = sifra;
            Naziv = naziv;
        }



        // metoda (koja nije konstruktor)
        public void TestNacinaPristupa()
        {

            Sifra = 1;
            //NeVidimUPodKlasama = "ne vidim"; private sintaksna greska je pa je zato komentirana linij
            VidimUPodKlasama = "vidim"; // protected svojstvo iz nadklase
           

        }

        override public string ToString()
        {
            return "{\"sifra\": " + Sifra + ", \"naziv\": \"" + Naziv + "\"}";
        }

        // za primjer ali ovo je bolje ostaviti default - po HashCode
        override public bool Equals(object obj)
        {
            if (!(obj is Smjer))
            {
                return false;
            }

            return Naziv == ((Smjer)obj).Naziv && Sifra== ((Smjer)obj).Sifra;
        }

    }
}
