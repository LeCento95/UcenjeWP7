using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{
    internal class E16Vjezbanje
    {

        public static void Izvedi()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Dobrodošli u vježbanje srijedom");
            Console.ResetColor();
            Izbornik();
            Console.WriteLine("Doviđenja!");
        }

        private static void Izbornik()
        {
            Console.WriteLine();
            Console.WriteLine("1. Za uneseni broj provjeri da li je parni ili ne?");
            Console.WriteLine("2. Riječ unazad");
            Console.WriteLine("3. Provjera sigurnosti lozinke");
            Console.WriteLine("0. Izlaz iz aplikacije");
            OdabirOpcijeIzbornika();
        }

        private static void OdabirOpcijeIzbornika()
        {
            switch (E14Metode.UcitajBroj("Odaberi opciju izbornika"))
            {
                case 1:
                    ParnostBroja();
                    Izbornik();
                    break;
                case 2:
                    RijecUnazad();
                    Izbornik();
                    break;
                case 3:
                    ProvjeraSigurnostiLozinke();
                    Izbornik();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Nije opcija izbornika");
                    Izbornik();
                    break;
            }
        }

        private static void ProvjeraSigurnostiLozinke()
        {
            NaslovPrograma("Program za unesenu lozinku ispisuje da li je: dobra, loša ili zla");
            string lozinka = E14Metode.UcitajString("Unesi svoju lozinku za provjeru", "Obavezan unos");
            // maskiranje u subotu https://stackoverflow.com/questions/3404421/password-masking-console-application

            int razina = 0;

            if (lozinka.Length >= 8)
            {
                razina++;
            }
            // imaš broj u sebi
            razina += ProvjeraLozinka(lozinka, 48, 57);

            // imaš mali znak u sebi
            razina += ProvjeraLozinka(lozinka,97,122);

            // imaš veliki znak u sebi
            razina += ProvjeraLozinka(lozinka, 65, 90);

            // interpukcijski znakovi
            razina += (ProvjeraLozinka(lozinka, 33, 47) 
                + ProvjeraLozinka(lozinka, 58, 63) 
                + ProvjeraLozinka(lozinka, 123, 126))>0 ? 1 : 0;

            Console.WriteLine(razina);

        }

        private static int ProvjeraLozinka(string lozinka, int v1, int v2)
        {
            foreach (char z in lozinka)
            {
                if (z >= v1 && z <= v2)
                {
                    return 1;
                }
            }
            return 0;
        }

        private static void RijecUnazad()
        {
            NaslovPrograma("Program za unesenu riječ ispisuje istu unazad.");
            string unos = E14Metode.UcitajString("Unesi riječ","Nisi unio riječ");
            for(int i = unos.Length - 1; i >= 0; i--)
            {
                Console.Write(unos[i]);
            }
            Console.WriteLine();
        }

        private static char z = '-';

        private static void NaslovPrograma(string v)
        {
            Linija(v.Length + 6);
            Console.WriteLine("{0}{1} {2} {3}{4}",z,z,v,z,z);
            Linija(v.Length + 6);
        }

        private static void Linija(int v)
        {
            for (int i = 0; i < v; i++)
            {
                Console.Write(z); // ovaj ostaje u istom redu
            }
            Console.WriteLine(); // ovaj ode u novi red
        }

        private static void ParnostBroja()
        {
            NaslovPrograma("Program za uneseni broj ispisuje da li je paran ili ne.");
            int broj = E14Metode.UcitajBroj("Unesi cijeli broj za provjeru", 1, 100);
            if (broj % 2 == 0)
            {
                Console.WriteLine("Broj {0} je paran",broj);
            }
            else
            {
                Console.WriteLine("Broj {0} je neparan", broj);
            }
            Console.WriteLine("-- Kraj programa provjere parnosti broja --"); // i ovo bi se dalo izvući u metodu
        }
    }
}
