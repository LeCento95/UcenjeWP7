using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{
    internal class E13Z2
    {
        
        public static void Izvedi()
        {
            // Osigurajte unos decimalnog broja
            float b = 0;

            while (true)
            {
                Console.Write("Unesi broj: ");
                try
                {
                    b = float.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Niste unijeli broj");
                }
            }


            Console.WriteLine("{0:F3}",b);

            // 123,89 OK
            // 289 NO

            // Osigurajte unos imena grada
            string unos;
            
            while (true) {
                pocetak:
                Console.Write("Unesi ime grada: ");
                unos = Console.ReadLine();
                if(unos.Trim() == "")
                {
                    Console.WriteLine("Nisi unio ime grada");
                    continue;
                }
                // nešto si unio
                // da li je to samo broj
                try
                {
                    int.Parse(unos);
                    Console.WriteLine("Ne smiješ unijeti broj");
                    continue;
                }
                catch 
                {

                    
                }

                // da li u unosu imamo brojeve
                foreach (char znak in unos)
                {
                   
                    if (!(znak < 48 || znak > 57))
                    {
                        Console.WriteLine("Uneseni znak {0} je broj, " +
                            "on je dio slijeda znakova ...{1}, {2}, {3}...", znak,
                            (char)(znak - 1), znak, (char)(znak + 1));
                        goto pocetak;
                    }
                }


                break;
            }
            Console.WriteLine(unos);



        }
    }
}
