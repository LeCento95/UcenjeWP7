using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{
    internal class Vjezba02
    {

        // Za učitani cijeli broj između 10 i 99 ispiši jediničnu vrijednost
        // 13 --> 3
        // 21 --> 1
        public static void Izvedi()
        {
            //Console.WriteLine("02");
            Console.WriteLine("Unesi cijeli broj između 10 i 99: ");
            int broj = int.Parse(Console.ReadLine());
            Console.WriteLine(broj % 10); // ispisati će samo zadnju znamenku

            Console.WriteLine("Ponovi unos: ");
            Console.WriteLine(Console.ReadLine()[1]);

            
            Console.WriteLine("Unesi cijeli broj između 10 i 99: ");
            int br = int.Parse(Console.ReadLine());
            Console.WriteLine(br / 10); // ispisati će samo prvu znamenku

            Console.WriteLine("Ponovi unos: ");
            Console.WriteLine(Console.ReadLine()[1]);


        }

    }
}
