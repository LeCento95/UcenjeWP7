using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{
    internal class E04UvjetnoGrananjeIf
    {

        public static void Izvedi()
        {
            //Console.WriteLine("E04");

            int broj = 7; // ovo je kao da sam ispisao poruku i da je korisnik unio broj 7

            // operator == provjerava jednakost, on je tipa bool

            bool uvjet = broj == 7;

            // if radi s bool tipom podataka
            if (uvjet)
            {
                Console.WriteLine("Broj ima vrijednost 7");
            }


            // u pravilu se if koristi ovako
            if (broj == 7)
            {
                Console.WriteLine("ponovo je jednako 7");
            }

            // if može i bez {} i tada se odnosi samo na prvu liniju nakon if
            if (broj == 7)
                Console.WriteLine("I bez {} je jednako");
            //Console.WriteLine("I ovo bih da je uz uvjet jednakosti da je broj 7");


            if (broj == 7)
            {
                Console.WriteLine("I opet je 7 ali uz inače");
            }
            else
            {
                Console.WriteLine("Broj NIJE 7");
            }


            // maksimalni oblik if naredbe
            if (broj == 6)
            {
                Console.WriteLine("Sad je 6");
            }
            else if (broj == 7)
            {
                Console.WriteLine("Sad je 7");
            }// može ići koliko god else if želimo
            else // može i ne mora
            {
                Console.WriteLine("broj nije niti 6 niti 7");
            }


            // if koristi <, >, <=, >= i != različito

            // logički operatori and or i not

            // and & ili &&

            broj = 1;
            int temp = 2;

            if (broj != 1 & temp < 0) // provjeravati će se oba uvjeta
            {
                Console.WriteLine("Hladno je");
            }

            if (broj != 1 && temp < 0) // Ako prvi uvjet nije ispunjen ne provjerava se drugi
            {
                Console.WriteLine("Hladno je");
            }

            // or | (Altgr + W) ||

            if (broj > 0 | temp > 0) // Provjerava oba uvjeta
            {
                Console.WriteLine("Toplo je");
            }

            if (broj > 0 || temp > 0) // Ako je prvi uvjet zadovoljen ne provjerava se drugi
            {
                Console.WriteLine("Toplo je");
            }


            // not !
            if (!(broj > 1 || temp > 0))
            {
                Console.WriteLine("Ovo je kompliciran izraz");
            }

            // if se može ugnježđivati

            if(broj > 0)
            {
                if (temp==0)
                {
                    Console.WriteLine("Ugnježđeno");
                }
            }


            // djelokrug varijable (scope)

            if (broj > 0)
            {
                int t = 8; // ova varijabla živi samo unutar ovog if-a
            }

            //Console.WriteLine(t); // varijabla t nije vidljiva izvan gore definiranog if-a


            string grad = "Osijek";

            if (grad == "Osijek")
            {
                Console.WriteLine("Super");
            }
            else
            {
                Console.WriteLine("Nije Super");
            }

            // u slučaju da if i else imaju istu akciju (naredba, metoda) tada se može koristiti
            // inline if (? : operator)

            Console.WriteLine(grad=="Osijek" ? "Super" : "Nije Super");


        }



    }
}
