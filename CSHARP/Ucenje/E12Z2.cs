using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{
    internal class E12Z2
    {
        public static void Izvedi()
        {
            // Korisnik unosi dvije riječi
            // Program ispisuje unesene druga, pa prva riječi redosljedom unazad u istoj liniji

            // npr. Pero Kava
            // ispisa: avaK oreP

            Console.WriteLine("Unesi prvu riječ: ");
            string rijec1 = Console.ReadLine();

            Console.WriteLine("Unesi drugu riječ: ");
            string rijec2 = Console.ReadLine();

            string unazad = "";
            rijec2 = rijec1 + " " + rijec2;

            for (int i = rijec2.Length-1; i >= 0; i--)
            {
                unazad += rijec2[i];
            }

            Console.WriteLine("{0}", unazad);


        }


    }
}
