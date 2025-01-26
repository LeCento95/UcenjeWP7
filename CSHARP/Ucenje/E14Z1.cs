using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{
    internal class E14Z1
    {
        /// <summary>
        /// Zadatak: Program učitava dva broja i ispisuje zbroj
        /// </summary>
        public static void Izvedi()
        {
            Console.WriteLine(E14Metode.UcitajBroj("Unesi prvi broj",10,20) 
                + E14Metode.UcitajBroj("Unesi drugi broj",1,10));
        }

    }
}
