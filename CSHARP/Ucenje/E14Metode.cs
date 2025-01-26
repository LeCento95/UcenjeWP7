using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{
    internal class E14Metode
    {

        // metoda je organizacijska jedinica koda koja služi određenoj svrsi
        // Cilj rada s metodama: Write once, use everywhere
        // static - označava da se metoda može pozvati na klasi
        public static void Izvedi()
        {
            Console.WriteLine("E14");
            // Metode se sastoje od dva djela:
            // 1. Tijelo metode
            // 2. Poziv metode

            // iz statične metode na klasi može samo pozvati drugu statičnu metodu, posljedično sve nađe metoda danas će biti statične

            // poziv metode
            Tip1();
           
            Tip2(5);

            Tip2(3, "Osijek");

            Console.WriteLine(Tip3());
            // svi prosti brojevi od 1 do 100
            for(int i = 1; i < 100; i++)
            {
                if (Tip4(i))
                {
                    Console.WriteLine(i);
                }
            }

            

        }

        // prvo se piše tijelo metode
        /// <summary>
        /// Metoda tipa 1: Ne vraća vrijednost, ne prima vrijednost
        /// ne vraća vrijednost - void
        /// ne prima vrijednost - u zagradama nakon naziva metode nema parametara
        /// mora trenutno biti static
        /// ne piše public ili nešto drugo: radi se o načinu pristupa;
        /// bez navođenja: vidljivo samo u ovoj klasi
        /// </summary>
        static void Tip1()
        {
            Console.WriteLine("Ispis iz metode Tip 1");
        }


        // 2. ne vraća vrijednost, prima parametre
        // int i je parametar
        /// <summary>
        /// Metoda koja ispisuje broj i njegovo uvećanje za 10
        /// </summary>
        /// <param name="i">Primljeni broj</param>
        private static void Tip2(int i)
        {
            Console.WriteLine("Primio sam broj {0}", i);
            Console.WriteLine("Uvećan za 10 on iznosi {0}", i+10);
        } 

        // potpis metode: naziv metode + lista parametara koje prima
        protected static void Tip2(int i, string s) // method overloading
        {
            Console.WriteLine(s);
            Console.WriteLine("Primio sam {0}",i);
        }


        // 3. vraća vrijednost, ne prima parametre
        public static string Tip3()
        {
            // ako nije void, metoda mora vratiti (return) ona tip za koji je deklarirana
            return "Web programiranje";
        }

        // 4. [NAJZANIMLJIVIJA] vraća vrijednost, prima parametre
        /// <summary>
        /// Za dani broj odlučuje da li je prim ili ne
        /// </summary>
        /// <param name="broj">Broj koji se analizira</param>
        /// <returns>true ako je prim, false ako nije</returns>
        public static bool Tip4(int broj)
        {
         
            for(int i = 2; i < broj; i++)
            {
                if (broj % i == 0)
                {
                    // short cuircuiting
                    // prekidam i petlju i metodu i vraća false
                    return false;
                }
            }

            return true;
        }


        public static int UcitajBroj(string poruka)
        {
            while (true)
            {
                Console.Write(poruka + ": ");
                try
                {
                    return int.Parse(Console.ReadLine());
                }
                catch 
                {
                    Console.WriteLine("Niste unijeli broj");
                }
            }
            //return 0; //samo da ne bude greška, kasnije obrisati
        }

        public static int UcitajBroj(string poruka, int min, int max)
        {
            int i = 0;
            for(; ; )
            {
                Console.Write(poruka + ": ");
                try
                {
                    i = int.Parse(Console.ReadLine());
                    if(i<min || i > max)
                    {
                        Console.WriteLine("Broj nije u danom rasponu {0} i {1}",min,max);
                        continue;
                    }
                    return i;
                }
                catch 
                {
                    Console.WriteLine("Nisi unio broj!");
                   
                }
            }
        }



        /// <summary>
        /// Unosi string
        /// </summary>
        /// <param name="poruka">Poruka koja se ispijuje korisniku</param>
        /// <param name="greska">Poruka greške u slučaju da nije napravio unos</param>
        /// <returns>String koji je unio korisnik</returns>
        public static string UcitajString(string poruka, string greska)
        {
            string s;
            do
            {
                Console.Write(poruka + ": ");
                s = Console.ReadLine();
                if (s.Trim().Length == 0)
                {
                    Console.WriteLine(greska);
                    continue;
                }
                return s;
            } while (true);
        }





    }
}
