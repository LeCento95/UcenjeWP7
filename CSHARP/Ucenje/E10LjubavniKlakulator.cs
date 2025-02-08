using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{
    internal class E10LjubavniKlakulator
    {
        public static void Izvedi()
        {
            char srce = '\u2764';
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("${srce}{srce}{srce} Dobro došli u ljubavni kalkulator {srce}{srce}{srce}");
            Console.ResetColor();
            Console.WriteLine();


            string ime1 = UcitajIme("Unesi svoje ime: ");
            string ime2 = UcitajIme("Unesi ime osobe koju voliš: ");


            char[] imena = (ime1 + ime2).ToCharArray();

            Dictionary<char, int> brojac = new Dictionary<char, int>();


            foreach (char slovo in imena)
            {
                if (brojac.ContainsKey(slovo))
                {
                    brojac[slovo]++;
                }
                else
                {
                    brojac[slovo] = 1;
                }
            }


            int[] imenabrojevi = new int[imena.Length];
            int indeks = 0;
            foreach (char znak in imena)
            {
                int broj = brojac.FirstOrDefault(par => par.Key == znak).Value;
                imenabrojevi[indeks] = broj;
                indeks++;
            }

            Console.WriteLine(string.Join("", imenabrojevi));

            string rezultat = ZbrojiZnamenke(imenabrojevi);
            IspisiRezultat(rezultat, ime1, ime2, srce);
        }

        private static string UcitajIme(string poruka)
        {
            string ime;
            while (true)
            {
                ime = E14Metode.UcitajString(poruka).ToString().ToUpper();
                if (SamoSlova(ime))
                {
                    return ime;
                }
                Console.WriteLine("Greška! Dozvoljena su samo slova, pokušajte ponovno!");
            }
        }

        private static bool SamoSlova(string ime)
        {
            foreach (char znak in ime)
            {
                if (!char.IsLetter(znak))
                {
                    return false;
                }
            }
            return true;
        }

        private static string ZbrojiZnamenke(int[] broj)
        {
            if(broj.Length <= 1)
            {
                return string.Join("", broj);
            }

            int prvi = broj[0];
            int zadnji = broj[broj.Length - 1];
            int sum = prvi + zadnji;


            int[] sredina = new int[broj.Length - 2];
            Array.Copy(broj, 1, sredina, 0, broj.Length - 2);
            string sredinaString = ZbrojiZnamenke(sredina);
            string rezultat = sum.ToString() + sredinaString;
            if (rezultat.Length > 2)
            {
                return ZbrojiZnamenke(stringUBroj(rezultat));
            }
            return rezultat;
        }

        private static int[] stringUBroj(string broj)
        {
            int[] brojevi = new int[broj.Length];
            for (int i = 0; i < broj.Length; i++)
            {
                brojevi[i] = int.Parse(broj[i].ToString());
            }
            return brojevi;
        }

        private static void IspisiRezultat(string rezultat, string ime1, string ime2, char srce)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (int.Parse(rezultat) <= 25)
                Console.WriteLine("{0} i {1} imaju ljubavni rezultat {2}%. Nažalost, vi niste jedno za drugo :(", ime1, ime2, rezultat);
            else if (int.Parse(rezultat) > 25 && int.Parse(rezultat) <= 50)
                Console.WriteLine("{0} i {1} imaju ljubavni rezultat {2}%. Hm, možda ipak možeš naći nekog boljeg?", ime1, ime2, rezultat);
            else if (int.Parse(rezultat) > 50 && int.Parse(rezultat) <= 75)
                Console.WriteLine("{0} i {1} imaju ljubavni rezultat {2}%. Ova kombinacija ima potencijala, samo naprijed!", ime1, ime2, rezultat);
            else
                Console.WriteLine("{0} i {1} imaju ljubavni rezultat {2}%. Pa ovo je prava ljubav, čestitamo! <3", ime1, ime2, rezultat);

            for (int i = 1; i <= int.Parse(rezultat); i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{srce}");
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }
            
}
