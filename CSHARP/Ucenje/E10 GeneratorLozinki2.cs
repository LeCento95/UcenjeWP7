using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{
    internal class E10_GeneratorLozinki2
    {
        /*Generator lozinki
        Program od korisnika traži unos podataka:
        Dužina lozinke
        Uključena/isključena velika slova
        Uključena/isključena mala slova
        Uključeni/isključeni brojevi
        Uključeni/isključeni interpunkcijski znakovi
        Lozinka počinje ili ne s brojem
        Lozinka počinje ili ne s interpunkcijskim znakom
        Lozinka završava ili ne s brojem
        Lozinka završava ili ne s interpunkcijskim znakom
        Lozinka ima/nema ponavljajuće znakove
        Broj lozinki koje je potrebno generirati

        Shodno unesenim pravilima program generira rezultat(jedna ili više lozinki)
        */
        public static void Izvedi()
        {
            Console.WriteLine("Dobro došli u Generator lozinki! Molimo da odaberete sljedeće opcije: ");
            Console.WriteLine();
            int duzinaLozinke;

            while (true)
            {
                duzinaLozinke = E14Metode.UcitajCijeliBroj("Dužina lozinke (unesite broj znakova 5-20): ");
                try // Blok za obradu iznimki
                {
                    if (duzinaLozinke < 5 || duzinaLozinke > 20)
                    {
                        Console.WriteLine("Uneseni broj je izvan raspona, pokušajte ponovno!");
                        continue;
                    }
                    break;
                }
                catch // Hvata eventualne iznimke koje se mogu dogoditi tijekom unosa broja.
                {

                }
            }

            bool prvoInterpunkcija = false;
            bool zadnjeInterpunkcija = false;
            bool prvoBroj = false;
            bool zadnjeBroj = false;
            int brojLozinki = E14Metode.UcitajCijeliBroj("Upišite željeni broj lozinki: ");
            bool velikaSlova = E14Metode.UcitajBool("Uključena velika slova (DA ili NE): ", "DA");
            bool malaSlova = E14Metode.UcitajBool("Uključena mala slova (DA ili NE): ", "DA");
            bool brojevi = E14Metode.UcitajBool("Uključeni brojevi (DA ili NE): ", "DA");

            if (brojevi)
            {
                prvoBroj = E14Metode.UcitajBool("Želite li da lozinka započinje brojem (DA ili NE): ", "DA");
                zadnjeBroj = E14Metode.UcitajBool("Želite li da lozinka završava brojem (DA ili NE): ", "DA");
            }
            bool interpunkcija = E14Metode.UcitajBool("Uključeni interpunkcijski znakovi (DA ili NE): ", "DA");

            if (interpunkcija && !prvoBroj)
            {
                prvoInterpunkcija = E14Metode.UcitajBool("Želite li da lozinka započinje interpunkcijskim znakom (DA ili NE): ", "DA");

            }
            if (interpunkcija && !zadnjeBroj)
            {
                zadnjeInterpunkcija = E14Metode.UcitajBool("Želite li da lozinka završava interpunkcijskim znakom (DA ili NE): ", "DA");
            }

            //optimizirana verzija uvjet neispravan unos

            bool NeispravanUnos() // Funkcija koja provjerava je li korisnik unio ispravne postavke. Vraća true ako je unos neispravan, a false inače.
            {
                return (!brojevi && !interpunkcija && !velikaSlova && !malaSlova) ||  
                       (!prvoBroj && !prvoInterpunkcija && !velikaSlova && !malaSlova) ||
                       (!zadnjeBroj && !zadnjeInterpunkcija && !velikaSlova && !malaSlova);
                // Provjerava kombinacije postavki koje nisu dopuštene (npr. ako nisu uključena ni slova ni brojevi ni interpunkcijski znakovi).
                
            }
            if (NeispravanUnos()) // Ako je unos neispravan, ispiši poruku o pogrešci i ponovi postupak unosa pozivom funkcije Izvedi().
            {
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Greška! Provjerite svoj unos i ponovno odaberite opcije!");
                Console.ResetColor();
                Console.WriteLine();
                Izvedi();
                
                
            }
            else
            {
                bool ponavljanjeZnakova = E14Metode.UcitajBool("Ponavljajući znakovi (DA ili NE): ", "DA");
                string znakovi = SkupOdabranihZnakova(velikaSlova, malaSlova, brojevi, interpunkcija); // Poziva funkciju SkupOdabranihZnakova() za stvaranje skupa znakova koji će se koristiti za generiranje lozinke.

                for (int i = 0; i < brojLozinki; i++)
                {

                    string lozinka = GenerirajLozinku(duzinaLozinke, znakovi, prvoBroj, prvoInterpunkcija, zadnjeBroj, zadnjeInterpunkcija, ponavljanjeZnakova, velikaSlova, malaSlova);
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{i + 1}. lozinka: {lozinka}");
                    Console.ResetColor();

                }

            }
        }
        private static string SkupOdabranihZnakova(bool velikaSlova, bool malaSlova, bool brojevi, bool interpunkcija)
        {
            string znakovi = "";
            if (velikaSlova)
            {
                znakovi += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            }
            if (malaSlova)
            {
                znakovi += "abcdefghijklmnopqrstuvwxyz";
            }
            if (brojevi)
            {
                znakovi += "0123456789";
            }
            if (interpunkcija)
            {
                znakovi += "!@#$%^&*()_+-=[]{}|;:,.<>?";
            }

            return znakovi;

        }

        private static string GenerirajLozinku(int duzinaLozinke, string znakovi, bool prvoBroj, bool prvoInterpunkcija, bool zadnjeBroj, bool zadnjeInterpunkcija, bool ponavljanjeZnakova, bool malaSlova, bool velikaSlova)
        {
            Random random = new Random();
            char[] lozinka = new char[duzinaLozinke];

            //prvi znak
            if (prvoBroj)
            {
                char[] brojevi = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                lozinka[0] = brojevi[random.Next(brojevi.Length)];
            }
            else if (prvoInterpunkcija)
            {
                char[] interpunkcija = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '-', '=', '[', ']', '{', '}', '|', ';', ':', ',', '.', '<', '>', '?' };
                lozinka[0] = interpunkcija[random.Next(interpunkcija.Length)];
            }
            else
            {
                char[] slova;
                if (malaSlova && velikaSlova)
                {
                    slova = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
                }
                else if (malaSlova && !velikaSlova)
                {
                    slova = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
                }
                else
                {
                    slova = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
                }
                lozinka[0] = slova[random.Next(slova.Length)];
            }
            //zadnji znak
            if (zadnjeBroj)
            {
                char[] brojevi = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                lozinka[duzinaLozinke - 1] = brojevi[random.Next(brojevi.Length)];
            }
            else if (zadnjeInterpunkcija)
            {
                char[] interpunkcija = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '-', '=', '[', ']', '{', '}', '|', ';', ':', ',', '.', '<', '>', '?' };
                lozinka[duzinaLozinke - 1] = interpunkcija[random.Next(interpunkcija.Length)];
            }
            else
            {
                char[] slova;
                if (malaSlova && velikaSlova)
                {
                    slova = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
                }
                else if (malaSlova && !velikaSlova)
                {
                    slova = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
                }
                else
                {
                    slova = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
                }
                lozinka[duzinaLozinke - 1] = slova[random.Next(slova.Length)];

            }

            //PONAVLJANJE ZNAKOVA
            if (ponavljanjeZnakova)
            {
                for (int i = 1; i < duzinaLozinke - 1; i++)
                {
                    lozinka[i] = znakovi[random.Next(znakovi.Length)];
                }
            }
            else
            {
                for (int i = 1; i < duzinaLozinke - 1; i++)
                {
                    do
                    {
                        lozinka[i] = znakovi[random.Next(znakovi.Length)];
                    }
                    while (lozinka[i] == lozinka[0] && lozinka[i] == lozinka[duzinaLozinke - 1]);

                }
            }


            //  LOZINKA 


            return new string(lozinka);
        }

    }

}
