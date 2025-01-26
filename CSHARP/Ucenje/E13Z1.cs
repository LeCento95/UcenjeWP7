using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{
    internal class E13Z1
    {
        // Osigurati unos broja
        public static void Izvedi()
        {
            int broj;
            while (true)
            {
                Console.WriteLine("Unesite cijeli broj: ");
                string unos = Console.ReadLine();
                try
                {
                    broj = int.Parse(unos);
                    break;
                }
                catch
                {
                    Console.WriteLine("Pogrešan unos. Molim unesite cijeli broj.");
                }
            }
            Console.WriteLine($"Unijeli ste broj: {broj}");

            // Osigurati unos parnog broja


            int br;
            while (true)
            {
                Console.WriteLine("Unesite parni cijeli broj: ");
                string unos = Console.ReadLine();
                try
                {
                    br = int.Parse(unos);
                    if (br % 2 == 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Broj nije paran. Molim unesite parni broj.");
                    }
                }
                catch
                {
                    Console.WriteLine("Pogrešan unos. Molim unesite cijeli broj");
                }
            }
            Console.WriteLine($"Unijeli ste parni broj: {br}");

            // Osigurati unos visine čovjeka

            double visina;
            while (true)
            {
                Console.WriteLine("Unesite visinu čovjeka u metrima: ");
                string unos = Console.ReadLine();
                try
                {
                    visina = double.Parse(unos);
                    if (visina > 0 && visina < 3)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Nerealna visina za čovjeka. Unesi visinu u metrima.");
                    }
                }
                catch
                {
                    Console.WriteLine("Pogrešan unos. Unesi broj u oblicu x.xx");
                } 
            }
            Console.WriteLine($"Unio si visinu: {visina} m");
        }
    }
}