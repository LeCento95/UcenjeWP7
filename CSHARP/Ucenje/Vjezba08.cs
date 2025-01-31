using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{
    internal class Vjezba08
    {

        // 10 puta jedno ispod drugog ispišite Osijek
        public static void Izvedi()
        {
            
            //Console.WriteLine("08");
            // unaprijed poznat broj ponavljanja
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine("{0}. Osijek iz petlje", i);
            }

            string grad = "Osijek";
            for (int i = grad.Length -1; i >= 0; i--)
            {
                Console.WriteLine(grad[i]);
            }

            Console.WriteLine();



        }


    }
}
