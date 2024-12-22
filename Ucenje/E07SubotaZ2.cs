using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{
    internal class E07SubotaZ2
    {

        // Program od korisnika traži unos broj godina koje ima korisnik
        // Program ispisuje da li je korisnik punoljetna osoba ili ne


        // dodatno: ako je unos ispod nula godine ili iznad 112 godina ipisati GREŠKA

        public static void Izvedi()
        {

            // kompliciranje
            int godine = 26;
            bool aktivan = false;
            string grad = "Osijek";

            Console.WriteLine("Korisnik je stanovnik {0} grada, {1}, iako {2}",
                grad=="Osijek" ? "super" : "prosječnog",
                godine>=18 ? aktivan ? "A" : "B" : "C",
                aktivan ? "D" : godine<18 ? "E" : grad!="osijek" ? "F" : "G"
                );




            int x = 4, y = 4, z = 7;
            string rezultat;

            if (x == y)
            {
                if (y == z)
                {
                    rezultat = "Sva tri broja su jednaka.";
                }
                else
                {
                    rezultat = "x i y su jednaki, ali z je drukčiji.";
                }
            }
            else
            {
                rezultat = "x je drukčiji od y.";
            }

            Console.WriteLine(rezultat);


            //int x = 4, y = 4, z = 7;
            //string rezultat = x == y
            rezultat = x == y
            ? (y == z
            ? "Sva tri broja su jednaka."
            : "x i y su jednaki, ali z je drukčiji.")
            : "x je drukčiji od y.";
            Console.WriteLine(rezultat);


        }

    }
}
