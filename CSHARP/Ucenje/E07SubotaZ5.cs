﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{
    /* 
    
    Napiši program koji od korisnika traži da unese broj od 1 do 7 koji predstavlja dan u tjednu
    (1 - ponedjeljak, 2 - utorak, itd...)
    Program zatim treba ispisati što korisnik radi taj dan prema sljedećim pravilima:

        Vikendom (subota i nedjelja): Korisnik odmara.
        Radnim danom:
        Ako je da ponedjeljak ili srijeda, korisnik ide na trening.
        Ako je dan utorak ili četvrtak, korisnik uči programiranje.
        Ako je dan petak, korisnik ide u kino.

    */
    
    
        internal class E07SubotaZ5
    {
        public static void Izvedi()
        {

            Console.WriteLine("Unesite broj dana u tjednu (1-7): ");
            int dan = int.Parse(Console.ReadLine());

            string aktivnost = dan switch
            {
                1 or 2 => "Idem na trening",
                2 or 4 => "Učim programiranje",
                5 => "Idem u kino",
                6 or 7 => "Odmaram se",
                _ => "Neispravan unos."
            };

            Console.WriteLine((dan >= 1 && dan <= 5)
                ? "Danas je {0} dan i {1},"
                : "Vikend je, {1}.", dan, aktivnost);

        }
    }
}
