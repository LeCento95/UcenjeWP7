using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{


    //Program unosi ime osobe
    //S najmanjom mogučnošću greške program ispisuje da li je osoba muškog ili ženskog spola
    internal class Vjezba06
    {
        public static void Izvedi()
        {
            //Console.WriteLine("06");

            Console.WriteLine("Unesi ime: ");
            string ime = Console.ReadLine();
            ime = ime.ToLower(); //Pretvaranje imena u mala slova radi usporedbe

            if (ime[ime.Length -1] == 'a') // Provera zadnjeg slova imena
            {
                Console.WriteLine("Žensko");
            }
            else
            {
                Console.WriteLine("Muško");
            }

            //Console.WriteLine(Console.ReadLine()[^1] == 'a' ? "Žensko" : "Muško");


        }


    }
}
