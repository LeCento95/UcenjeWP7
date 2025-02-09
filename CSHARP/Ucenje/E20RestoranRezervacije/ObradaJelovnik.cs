using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ucenje.E20KonzolnaAplikacija;
using Ucenje.E20RestoranRezervacije.Models;

namespace Ucenje.E20RestoranRezervacije
{
    internal class ObradaJelovnik
    {
        public List<Jelovnik> Jela { get; set; }

        public ObradaJelovnik()
        {
            Jela = new List<Jelovnik>();
            if (PomocnoRR.DEV)
            {
                UcitajTestnePodatke();
            }
        }

        private void UcitajTestnePodatke()
        {
            Jela.Add(new Jelovnik { NazivJela = "Pizza Capricciosa", Kategorija = "Glavno jelo", Opis = "Šunka, sir, gljive, rajčica", Cijena = 75 });
            Jela.Add(new Jelovnik { NazivJela = "Pasta Carbonara", Kategorija = "Glavno jelo", Opis = "Jaja, slanina, sir", Cijena = 60 });
            Jela.Add(new Jelovnik { NazivJela = "Salata Cezar", Kategorija = "Predjelo", Opis = "Piletina, zelena salata, croutoni", Cijena = 50 });
            Jela.Add(new Jelovnik { NazivJela = "Burger", Kategorija = "Glavno jelo", Opis = "Juneće meso, sir, povrće", Cijena = 80 });
            Jela.Add(new Jelovnik { NazivJela = "Tiramisu", Kategorija = "Desert", Opis = "Kolač od kave i sira", Cijena = 40 });
        }

        public void PrikaziIzbornik()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Izbornik za rad s jelovnikom");
            Console.ResetColor();
            Console.WriteLine("-------------------------");
            Console.WriteLine("1. Pregled svih jela");
            Console.WriteLine("2. Unos novog jela");
            Console.WriteLine("3. Promjena podataka postojećeg jela");
            Console.WriteLine("4. Brisanje jela");
            Console.WriteLine("5. Povratak na glavni izbornik");
            OdabirOpcijeIzbornika();
        }

        private void OdabirOpcijeIzbornika()
        {
            Console.WriteLine();
            switch (PomocnoRR.UcitajRasponBroja("Odaberite stavku izbornika", 1, 5))
            {
                case 1:
                    PrikaziJelo();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnosNovogJela();
                    PrikaziIzbornik();
                    break;
                case 3:
                    PromjeniPodatkeJela();
                    PrikaziIzbornik();
                    break;
                case 4:
                    ObrisiJelo();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.Clear();
                    break;
            }
        }

        public void PrikaziJelo()
        {
            PrikaziJelo(Jela, "Popis jela u aplikaciji");
        }

        public void PrikaziJelo(List<Jelovnik> jelaLista, string naslov)
        {
            Console.WriteLine("----------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(naslov);
            Console.ResetColor();
            Console.WriteLine("----------------");

            if (jelaLista.Count == 0)
            {
                Console.WriteLine("Trenutno nema unesenih jela.");
                return;
            }

            int rb = 0;
            foreach (var j in jelaLista)
            {
                Console.WriteLine($"{++rb}. {j.Naziv} ({j.Opis}) - {j.Cijena} kn");
            }
        }

        private void UnosNovogJela()
        {
            Console.WriteLine("***************");
            Console.WriteLine("Unesite tražene podatke o jelu");
            Jela.Add(new()
            {
                Naziv = PomocnoRR.UcitajString("Unesi naziv jela: ", 50, true),
                Opis = PomocnoRR.UcitajString("Unesi opis jela: ", 200, false),
                Cijena = (decimal)PomocnoRR.UcitajDecimalniBroj("Unesi cijenu jela: ", 0, float.MaxValue),
            });
            PotvrdaUnosa();
        }

        private void PromjeniPodatkeJela()
        {
            PrikaziJelo();
            if (Jela.Count == 0) return;

            int redniBroj = PomocnoRR.UcitajRasponBroja("Unesite redni broj jela koje želite promijeniti: ", 1, Jela.Count);
            var jeloZaPromjenu = Jela[redniBroj - 1];

            Console.WriteLine("Unesite nove podatke (ili pritisnite ENTER za preskakanje):");

            jeloZaPromjenu.Naziv = PomocnoRR.UcitajString("Unesi naziv jela (ili ENTER za preskakanje): ", 50, true, jeloZaPromjenu.Naziv.ToString());
            jeloZaPromjenu.Opis = PomocnoRR.UcitajString("Unesi opis jela (ili ENTER za preskakanje): ", 200, false, jeloZaPromjenu.Opis.ToString());
            jeloZaPromjenu.Cijena = PomocnoRR.UcitajDecimal("Unesi cijenu jela (ili ENTER za preskakanje): ", jeloZaPromjenu.Cijena);

            PotvrdaUnosa();
        }

        private void ObrisiJelo()
        {
            PrikaziJelo();
            if (Jela.Count == 0) return;

            int redniBroj = PomocnoRR.UcitajRasponBroja("Unesite redni broj jela koje želite obrisati: ", 1, Jela.Count);
            var jeloZaBrisanje = Jela[redniBroj - 1];

            Console.WriteLine($"Jeste li sigurni da želite obrisati jelo {jeloZaBrisanje.Naziv}?");
            if (PomocnoRR.UcitajBool("Odgovorite sa DA ili NE: "))
            {
                Jela.Remove(jeloZaBrisanje);
                Console.WriteLine("Jelo je uspješno obrisano.");
            }
            else
            {
                Console.WriteLine("Odustali ste od brisanja jela.");
            }
        }

        private static bool PotvrdaUnosa()
        {
            Console.WriteLine("Želite li spremiti promjene? (DA/NE)");
            string potvrdaUnosa = Console.ReadLine().ToLower();

            if (potvrdaUnosa == "da")
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Podaci su spremljeni, hvala. ");
                Console.WriteLine();

                return true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("------------------------------");
                Console.WriteLine("Odustali ste od unosa. ");
                Console.WriteLine("------------------------------");
                return false;
            }
        }
    }
}