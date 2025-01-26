using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{
    /// <summary>
    /// Osoba unosi broj godina
    /// Program ispisuje da li je punoljetna ili ne
    /// </summary>
    internal class E14Z2
    {

        public static void Izvedi()
        {
            // old school
            int godine = E14Metode.UcitajBroj("Unesi broj svojih godina", 1, 120);
            if (godine < 18)
            {
                Console.WriteLine("Maloljetna osoba");
            }
            else
            {
                Console.WriteLine("Punoljetna osoba");
            }


            // one liner
            Console.WriteLine((E14Metode.UcitajBroj("Unesi broj svojih godina", 1, 120)<18 ? "Maloljetna" : "Punoljetna") + " osoba");

        }


    }
}
