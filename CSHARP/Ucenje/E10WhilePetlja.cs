using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{
    internal class E10WhilePetlja
    {
        public static void Izvedi()
        {
            //Console.WriteLine("E10");

            // while radi s bool

            // beskonačna petlja
            while (true)
            {
                Console.WriteLine("Ispis iz beskonačne petlje nakon čega je break");
                break;
            }

            int i = 0;
            while (i++ < 10)
            {
                Console.WriteLine(i);
            }


            Console.WriteLine("***********");
            // continue radi na isti način
            int j = 0;
            while(i >= 10 && j++ < 10)
            {
                Console.WriteLine(i*j); // može još i || te !
            }


            // u for i while se ne mora ući

            int odBroja = 10;
            int doBroja = 0;


            for(int x = odBroja; x <= doBroja; x++)
            {
                Console.WriteLine(x);
            }

            bool uvjet = false;

            while (uvjet)
            {
                Console.WriteLine("Neće se ispisati");
            }


        }


    }
}
