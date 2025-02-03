using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{
    internal class ZimskiZadatci
    {
        public static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;

            while (true)
            {
                Console.WriteLine("Odaberite zadatak: ");
                Console.WriteLine("1. Površina pravokutnika");
                Console.WriteLine("2. Provjera broja");
                Console.WriteLine("3. Zbroj niza");
                Console.WriteLine("4. Prosjek ocijena");
                Console.WriteLine("5. Fibonaccijev niz");
                Console.WriteLine("6. Preokret stringa");
                Console.WriteLine("7. Brojanje samoglasnika");
                Console.WriteLine("8. Pretvorba temperature");
                Console.WriteLine("9. Sortiranje niza");
                Console.WriteLine("10. Kalkulator");
                Console.WriteLine("Q. Izlaz");

                string izbor = Console.ReadLine();

                switch (izbor)
                {
                    case "1":
                        PovrsinaPravokutnika();
                        break;
                    case "2":
                        ProvjeraBroja();
                        break;
                    case "3":
                        ZbrojNiza();
                        break;
                    case "4":
                        ProsjekOcijena();
                        break;
                    case "5":
                        FibonaccijevNiz();
                        break;
                    case "6":
                        PreokretStringa();
                        break;
                    case "7":
                        BrojanjeSamoglasnika();
                        break;
                    case "8":
                        PretvorbaTemperature();
                        break;
                    case "9":
                        SortiranjeNiza();
                        break;
                    case "10":
                        Kalkulator();
                        break;
                    case "Q":
                        Console.WriteLine("Doviđenja! ");
                        return; // Izlaz iz aplikacije
                    default:
                        Console.WriteLine("Neispravan izbor. ");
                        break;
                }



            }


        }

        // Kalkulator

        private static void Kalkulator()
        {
            {
                double broj1, broj2;

                Console.Write("Unesite prvi broj: ");
                if (!double.TryParse(Console.ReadLine(), out broj1))
                {
                    Console.WriteLine("Neispravan unos broja.");
                    return;
                }

                Console.Write("Unesite drugi broj: ");
                if (!double.TryParse(Console.ReadLine(), out broj2))
                {
                    Console.WriteLine("Neispravan unos broja.");
                    return;
                }

                Console.Write("Unesite operaciju (+, -, *, /): ");
                char operacija = Console.ReadLine()[0];

                double rezultat = 0;

                switch (operacija)
                {
                    case '+':
                        rezultat = broj1 + broj2;
                        break;
                    case '-':
                        rezultat = broj1 - broj2;
                        break;
                    case '*':
                        rezultat = broj1 * broj2;
                        break;
                    case '/':
                        if (broj2 == 0)
                        {
                            Console.WriteLine("Dijeljenje s nulom nije moguće. ");
                            return; // Prekid funkcije ako je drugi broj nula
                        }
                        rezultat = broj1 / broj2;
                        break;
                    default:
                        Console.WriteLine("Neispravna operacija.");
                        return; // Prekid funkcije ako je operacija neispravna
                }

                Console.WriteLine("Rezultat: " + rezultat);
            }
        }

        // Sortiranje niza

        private static void SortiranjeNiza()
        {
            int[] niz;
            int n;

            Console.Write("Unesite veličinu niza: ");
            if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.WriteLine("Neispravan unos veličine niza.");
                return;
            }

            niz = new int[n];

            Console.WriteLine("Unesite elemente niza: ");
            for (int i = 0; i < n; i++) // Ispravljeno: petlja ide do n
            {
                Console.Write("Element " + (i + 1) + ": ");
                if (!int.TryParse(Console.ReadLine(), out niz[i]))
                {
                    Console.WriteLine("Neispravan unos elementa niza.");
                    return;
                }
            }

            
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (niz[j] > niz[j + 1])
                    {
                        int temp = niz[j];
                        niz[j] = niz[j + 1];
                        niz[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("Sortirani niz: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(niz[i] + " ");
            }
            Console.WriteLine();


        }


        // Pretvorba temperature

        private static void PretvorbaTemperature()
        {
            double temp;
            char izbor;

            Console.Write("Unesite temperaturu: ");
            if (!double.TryParse(Console.ReadLine(), out temp))
            {
                Console.WriteLine("Neispravan unos temperature.");
                return;
            }

            Console.Write("Unesite temperaturu (C za Celzijus, F za Fahrenheit): ");
            if (!char.TryParse(Console.ReadLine().ToUpper()[0].ToString(), out izbor))
            {
                Console.WriteLine("Neispravan unos mjerne jedinice.");
                return;
            }

            double rezultat = 0;

            if (izbor == 'C')
            {
                rezultat = temp * 9 / 5 + 32;
                Console.WriteLine(temp + "C je " + rezultat + "F");
            }
            else if (izbor == 'F')
            {
                rezultat = (temp - 32) * 5 / 9;
                Console.WriteLine(temp + "F je " + rezultat + "C");
            }
            else
            {
                Console.WriteLine("Neispravan unos. Molim vas unesite C ili F. ");
            };
            return;
        }


        // Brojanje samoglasnika
        private static void BrojanjeSamoglasnika()
        {
            string unos;
            int brojac = 0;

            Console.Write("Unesite string: ");
            unos = Console.ReadLine().ToLower(); // pretvaranje stringa u mala slova

            for (int i = 0; i < unos.Length; i++) // Petlja prolazi kroz svaki znak u stringu
            {
                char znak = unos[i]; // trenutni znak u stringu
                if (znak == 'a' || znak == 'e' || znak == 'i' || znak == 'o' || znak == 'u')
                {
                    brojac++; // povećanje brojača ako je znak samoglasnik
                }
            }

            Console.WriteLine("Broj samoglasnika u stringu je: " + brojac); // Ispis nakon petlje
        }
    



        // Preokret stringa
        private static void PreokretStringa()
        {
            string rString; //  originalni string
            string revString = ""; // preokrenuti string

            Console.Write("Unesite znak: ");
            rString = Console.ReadLine();

            for (int i = rString.Length - 1; i >= 0; i--) //Petlja ide od zadnjeg do prvog znaka
            {
                revString += rString[i]; // dodavanje znaka na kraj preokrenutog stringa
            }
            Console.WriteLine("Obrnuti string je: " + revString);
        }


        // Fibonaccijev niz
        private static void FibonaccijevNiz()
        {
            int n; // broj članova Fibonaccijevog niza
            int a = 0; // prvi član niza
            int b = 1; // drugi član niza

            Console.Write("Unesite broj n (broj članova nita): ");
            n = int.Parse(Console.ReadLine());

            Console.WriteLine("a" + n + "članova niza");
            if (n >= 1)
            {
                Console.Write(a + " "); // ispis prvog člana niza
            }

            if (n >= 2)
            {
                Console.Write(b + " "); // ispis drugog člana niza
            }

            for (int i = 3; i <=n; i++) // Petlja za ispis preostalih članova
            {
                int c = a + b; // izračun sljedećeg člana niza
                Console.Write(c + ""); // ispis sljedećeg člana niza

                a = b;
                b = c;
            }

            Console.WriteLine();
        }


        // Prosjek ocjena
        private static void ProsjekOcijena()
        {
            Console.WriteLine("Unesite zbroj ocijena: ");
            int brojOcijena = int.Parse(Console.ReadLine());

            double zbrojOcjena = 0, prosjek;
            for (int i = 0; i < brojOcijena; i++)
            {
                Console.Write("Unesite ocjenu: ");
                double ocjena = double.Parse(Console.ReadLine());
                zbrojOcjena += ocjena;
            }

            double prosjekOcjena = zbrojOcjena / brojOcijena; // izračun prosjeka ocijena

            Console.WriteLine("Prosjek ocjena je: " +prosjekOcjena);
        }


        // Zbroj niza
        private static void ZbrojNiza()
        {
            int[] niz;
            int n;
            int zbroj = 0;

            Console.Write("Unesite veličinu niza: ");
            n = Convert.ToInt32(Console.ReadLine());


            niz = new int[n];

            Console.WriteLine("Unesite elemente niza: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write("Element"+ (i+1) + ":" );
                niz[i] = Convert.ToInt32(Console.ReadLine());
            }

            foreach (int broj in niz)
            {
                zbroj += broj;
            }

            Console.WriteLine("Zbroj elemenata niza je: " + zbroj);
        }

        // Provjera broja
        private static void ProvjeraBroja()
        {
            int broj;

            Console.Write("Unesite cijeli broj: ");

            broj = Convert.ToInt32(Console.ReadLine()); // pretvaranje stringa u cijeli broj

            if (broj > 0)
            {
                Console.WriteLine("Broj je pozitivan. ");
            }
            else if (broj < 0)
            {
                Console.WriteLine("Broj je negativan. ");
            }
            else
            {
                Console.WriteLine("Broj je nula");
            }
        }

        // Površina pravokutnika
        private static void PovrsinaPravokutnika()
        {
            double duljina; // deklaracija varijable duljina
            double sirina; // deklaracija varijable širina
            double povrsina; // deklaracija varijable površina

            Console.Write("Unesite duljinu pravokutnika: ");
            
            duljina = Convert.ToDouble(Console.ReadLine()); // unos duljine pravokutnika

            Console.Write("Unesite širinu pravokutnika: ");

            sirina = Convert.ToDouble(Console.ReadLine()); // unos širine pravokutnika

            povrsina = duljina * sirina; // formula za izračun površine pravokutnika

            Console.WriteLine("Površina pravokutnika je" +povrsina);
        }
    }
}
