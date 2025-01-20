using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{

    // Program unosi ime osobe
    // S najmanjom mogućnošću greške program ispisuje da li je osoba muškog ili ženskog spola

    internal class E07SubotaZ6
    {

        public static void Izvedi()
        {
            Console.WriteLine("Unesi ime osobe: ");

            string ime = Console.ReadLine();
            ime = ime.ToLower();

            if (ime[ime.Length - 1] == 'a')
            {
                Console.WriteLine("Žensko");
            }
            else
            {
                Console.WriteLine("Muško");
            }

            Console.WriteLine(Console.ReadLine().ToLower()[^1] == 'a' ? "Žensko" : "Muško");


        }
    }
}
