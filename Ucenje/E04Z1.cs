using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{
    internal class E04Z1
    {

        // Program unosi od korisnika cijeli broj.
        // Program ispuje da li je broj paran ili neparan

        public static void Izvedi()
        {
            Console.Write("Unesi cijeli broj: ");
            int broj = int.Parse(Console.ReadLine());

            if (broj % 2 == 0)
            {
                Console.WriteLine("PARAN");
            }
            else
            {
                Console.WriteLine("NEPARAN");
            }

            Console.WriteLine("{0}PARAN", broj % 2 == 0 ? "" : "NE"); 

        }

    }
}
