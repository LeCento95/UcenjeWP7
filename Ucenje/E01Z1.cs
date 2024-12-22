using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{
    internal class E01Z1
    {

        public static void Izvedi()
        {
            //Console.WriteLine("E01Z1");

            // Program od korisnika unosi zasebno ime i prezime
            // Program ispisuje prezime i ime

            Console.Write("Unesi svoje ime: ");
            string ime = Console.ReadLine();

            Console.Write("Unesi svoje prezime: ");
            string prezime = Console.ReadLine();

            Console.WriteLine("{0} {1}", prezime,ime);


        }









    }
}
