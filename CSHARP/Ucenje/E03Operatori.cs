using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{
    internal class E03Operatori
    {

        public static void Izvedi()
        {

            //Console.WriteLine("E03Operatori");

            // neću objašnjavati + - * /

            int i, j;

            i = 2; j = 3;

            i += j; // 1 = i + j

            // modulo operator % ostatak nakon cijelobrojnog djeljenja

            Console.WriteLine( i / j ); // kada se dijele dva intigera dobije se int (izgubi se decimalni dio)
            Console.WriteLine( i / (float) j);

            Console.WriteLine( 5 % 2 );


            // increment i decrement

            i = 1;
            // različiti načini uvećanja za broj 1
            i = 1 + 1;
            i += 1;
            i++;
            ++i;

            Console.WriteLine("**************");



            i = 1;
            Console.WriteLine(i); // 1
            Console.WriteLine(i++); // 1 -> Prvo se koristi, pa se onda uveća
            Console.WriteLine(++i); // 3 -> Prvo se uveća, pa se koristi

            // sve isto vrijedi i za decrement i--, --i

            Console.WriteLine("**************");

            int x = 1, y = 0;

            x = x + --y; // x=, y=-1
            y += ++x; // x=1, 0
            Console.WriteLine(++x - y--); // 2 
            Console.WriteLine(y); // -1




        }



    }
}
