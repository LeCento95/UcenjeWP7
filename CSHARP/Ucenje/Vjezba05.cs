using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Ucenje
{
    /*
    Program učitava od korisnika ime grada. U ovisnosti o imenu grada ispisuje regiju prema sljedećim pravilima:

        Vukovar --> Slavonija
        Split --> Dalmacija
        Varaždin --> Međimurje
        Rovinj --> Istra
        Za ostale unose program ispisuje: Ne znam koja je to regia
    */
    internal class Vjezba05
    {
        public static void Izvedi()
        {
            //Console.WriteLine("05");
            Console.WriteLine("Upiši ime grada: ");
            string grad = Console.ReadLine();

            string regija = grad switch // 'switch' izraz (u ovom slučaju 'switch expression' jer vraća vrijednost) omogućuje uvjetno grananje koda ovisno o vrijednosti varijable 'grad'.
                                        // Ovo je moderniji način pisanja 'switch' naredbe.         
            {
                "Vukovar" => ("Slavonija"),
                "Split" => ("Dalmacija"),
                "Varaždin" => ("Međimurje"),
                "Rovinj" => ("Istra"),
                _ => ("Ne znam koja je to regija.")
            };
            Console.WriteLine($"Regija: {regija}");


        }
    }
}





