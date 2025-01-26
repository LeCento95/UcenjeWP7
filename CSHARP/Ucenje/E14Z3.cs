using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{
    internal class E14Z3
    {
        /// <summary>
        /// Program unosi ime, prezime i godine osobe te ispisuje:
        /// Dobar dan, ja sam {0} {1}, i imam {2} godina
        /// </summary>
        public static void Izvedi()
        {
            Console.WriteLine(
                "Dobar dan, ja sam {0} {1}, i imam {2} godina",
                E14Metode.UcitajString("Unesi svoje ime","Ime obavezno"),
                E14Metode.UcitajString("Unesi prezime","I prezime je obavezno"),
                E14Metode.UcitajBroj("I unesi svoje godine",1,110)
                );
        }
    }
}
