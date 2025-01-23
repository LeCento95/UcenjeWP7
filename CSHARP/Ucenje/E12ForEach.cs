using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{
    internal class E12ForEach
    {
        public static void Izvedi()
        {
            Console.WriteLine("E12");

            // foreach je skraćeni for

            Console.WriteLine("Unesi ime grada");
            string grad = Console.ReadLine();

            // svako slovo grada ispiši jedno ispod drugog
            for (int i = 0; i < grad.Length; i++)
            {
                Console.WriteLine(grad[i]);
            }

            // u slučejevima kada idemo od početka do kraja (većina puta)

            Console.WriteLine("**********");
            foreach(char znak in grad)
            {
                Console.WriteLine(znak);
            }

            Console.WriteLine("**********");

            for (int i =grad.Length-1;i>=0; i--)
            {
                Console.WriteLine(grad[i]);
            }

            Console.WriteLine("**********");

            for (int i = 0; i < grad.Length; i++)
            {
                Console.WriteLine(grad[^(i+1)]);
            }



            int[] brojevi = { 1, 2, 2, 3, 3, 3, 3, 3 };

            foreach(int i in brojevi)
            {
                Console.WriteLine(i);
            }

            


        }
    }
}
