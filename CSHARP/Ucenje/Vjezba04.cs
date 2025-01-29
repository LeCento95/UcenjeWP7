using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{
    internal class Vjezba04
    {
        // Program od korisnika traži unos tri cijela broja
        // Program ispisuje manji broj
        // unos 5 i 2 --> 2
        // unos 3 i 8 --> 3
        // unos 2 i 1 --> 1
        // unos 4 i 4 --> Brojevi su jednaki
        public static void Izvedi()
        {
            //Console.WriteLine("04");
            Console.WriteLine("Unesi prvi cijeli broj: ");
            string pbroj = Console.ReadLine();

            Console.WriteLine("Unesi drugi cijeli broj: ");
            string dbroj = Console.ReadLine();

            Console.WriteLine("Unesi treći cijeli broj: ");
            string tbroj = Console.ReadLine();

            int pbroj1, dbroj2, tbroj3;

            if (int.TryParse(pbroj, out pbroj1) && int.TryParse(dbroj, out dbroj2) && int.TryParse(tbroj, out tbroj3)) // Pokušava pretvoriti stringove pbroj1, dbroj2 i tbroj3 u cijele brojeve.
            {                                                                                                          // int.TryParse vraća true ako je pretvorba uspjela i sprema rezultat u varijablu (pbroj1, dbroj2 ili tbroj3).
                                                                                                                       // && (logički "i") znači da *sve* pretvorbe moraju uspjeti da bi uvjet bio istinit.
                if (pbroj1 == dbroj2 && dbroj2 == tbroj3) // Provjerava jesu li sva tri broja jednaka.
                {
                    Console.WriteLine("Brojevi su jednaki."); // Ako su svi brojevi jednaki, ispisuje se ova poruka.
                }
                else // Ako brojevi nisu svi jednaki...
                {
                    int najmanji = Math.Min(pbroj1, Math.Min(dbroj2, tbroj3)); // Nalazi najmanji broj koristeći metodu Math.Min. Prvo se pronalazi manji od prva dva broja, a zatim se taj manji broj uspoređuje s trećim brojem.
                    Console.WriteLine("Najmanji broj je: " + najmanji); // Ispisuje najmanji broj.
                }
            }
            else // Ako barem jedna pretvorba nije uspjela (korisnik nije unio cijeli broj)...
            {
                Console.WriteLine("Neispravan unos. Molim unesi cijele brojeve."); // Ispisuje se poruka o grešci.
            }

        }
        
    } 
}

    
    

