using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{
    // Program od korisnika traži unos dva cijela broj
    // Program ispisuje manji
    // unos 5 i 2 --> 2
    // unos 3 i 8 --> 3
    // unos 4 i 4 --> Brojevi su jednaki


    internal class E07SubotaZ3
    {
        public static void Izvedi()
        {

            Console.Write("Unesi prvi broj: ");
            int pb = int.Parse(Console.ReadLine());

            Console.Write("Unesi drugi broj: ");
            int db = int.Parse(Console.ReadLine());

            Console.WriteLine(pb < db ? pb : db < pb ? db : "Jednaki su");
            
            
            Console.Write("Unesi prvi broj: ");
            int pbroj = int.Parse(Console.ReadLine());

            Console.Write("Unesi drugi broj: ");
            int dbroj = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Unesi treći broj: ");
            int tbroj = int.Parse(Console.ReadLine());

            Console.WriteLine(pbroj < dbroj ? pbroj : pbroj < tbroj ? pbroj : dbroj < pbroj ? dbroj : dbroj < tbroj ? dbroj : tbroj < pbroj ? tbroj : tbroj < dbroj ? tbroj : "Jednaki su");
           

       }

        // DZ: isto napravi za tri broja


       

    }
}           
