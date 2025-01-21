using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{
    internal class E08ForPetlja
    {
        public static void Izvedi()
        {


            // Na osnovu dosadašnjeg znanja:
            //Ispišite 10 puta jedno ispod drugog Osijek
            // OVO NIJE DOBRA PRAKSA (Best practice)

            Console.WriteLine("Osijek");
            Console.WriteLine("Osijek");
            Console.WriteLine("Osijek");
            Console.WriteLine("Osijek");
            Console.WriteLine("Osijek");
            Console.WriteLine("Osijek");
            Console.WriteLine("Osijek");
            Console.WriteLine("Osijek");
            Console.WriteLine("Osijek");
            Console.WriteLine("Osijek");
            Console.WriteLine("Osijek");

            Console.WriteLine("**********");

            for (int i = 0; i < 10; i++)// PAZITI DA OVDE NE DOĐE točka zarez // i=i+1, i+=1
            {
                Console.WriteLine("Osijek");
            }

            // kao i kod if ne moraju biti {}, ali se onda petlja odnosi samo na prvu liniju

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Ispisujem {0}. broj.", i + 1);
            }

            // zbroj prvih 100 brojeva
            int suma = 0;
            for (int i = 1; i <= 100; i++)
            {
                suma += i;
                // ako želimo pratiti proces, ispisujemo unutar petlje, prije }
                //Console.WriteLine("{0} + {1} = {2}",suma-i,i, suma);
            }

            // ako želimo samo rezultat, ispisuje nakon petlja, nakon }
            //Console.WriteLine(suma);

            // petlja može ići i "unazad"
            for (int i = 10; i > 0; i--)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("**********");

            //  petlja ne mora ići za korak 1
            for (int i = 0; i < 10; i += 2)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("**********");

            int odKuda = 2, doKuda = 20, uvećanje = 3; // simulacija da je unio korisnik

            // ono u čemu težimo u kodu jest kod bez konstanti
            for (int i = odKuda; i <= doKuda; i += uvećanje)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("**********");


            int[] niz = { 2, 3, 4, 5, 3, 2, 2 }; // dužina je 7

            //Ispišite broj 5
            Console.WriteLine(niz[3]);

            Console.WriteLine("**********");

            // u novim linijama ispiši sve elemente niza

            for (int i = 0; i < niz.Length; i++)
            {
                Console.WriteLine(niz[i]); // ovo je slovo i, ne broj 1
            }

            // for petlja se može gnjezditi
            for (int i = 0; i < 10; i++)


                for (int j = 0; j < 10; j++) // unutarnja petlja su kolone
                {
                    Console.Write("{0,4} ", (i + 1) * (j + 1));
                }

            Console.WriteLine();



            int redaka = 8;
            int stupaca = 6;


            // for petlja se može gnijezditi
            for(int i = 0; i < redaka; i++) // vanjska petlja su redovi
            {


                for (int j = 0; j < stupaca; j++) // unutarnja petlja su kolone
                {
                    Console.Write("{0,4} ", (i + 1) * (j + 1));
                }

                Console.WriteLine();

            }


        }

            

    }








}

