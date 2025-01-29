using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{
    internal class Vjezba01
    {
        public static void Izvedi()
        {

            //Console.WriteLine("01");

            bool x = true;
            bool y = false;

            bool andRezultat = (x && y); //ako je X istinit onda se podrazumjeva da je true
                                         // u ovom slučaju je false jer Y ne zadovoljava uvjet
            Console.WriteLine(andRezultat);

            
            bool orRezultat = (x || y); // ako je X ili Y zadovoljavaju true, onda je rezultat istinit = true = točan --> || - double pipe je oznaka za or
            Console.WriteLine(orRezultat);

            bool notRezultat1 = (x && !y); // X=true, Y=false, ali u ovom slučaju sa ! mjenjamo Y u ture
            Console.WriteLine(notRezultat1);

            bool notRezultat2 = !x; // ! invert X koji je bio true, sada je false
            Console.WriteLine(notRezultat2);

        }

        
       

    }
}
