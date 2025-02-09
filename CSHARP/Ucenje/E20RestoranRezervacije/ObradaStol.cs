using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ucenje.E20KonzolnaAplikacija;
using Ucenje.E20RestoranRezervacije.Models;

namespace Ucenje.E20RestoranRezervacije
{
    internal class ObradaStol
    {
        public List<Stol> Stolovi { get; set; }

        public ObradaStol()
        {
            Stolovi = new List<Stol>();
            if (PomocnoRR.DEV)
            {
                UcitajTestnePodatke();
            }
        }

        private void UcitajTestnePodatke()
        {
            for (int i = 0; i < 10; i++)
            {
                Stolovi.Add(new Stol()
                {
                    BrojStola = i + 1,
                    Kapacitet = Faker.RandomNumber.Next(2, 8),
                    Lokacija = string.Join(" ", Faker.Lorem.Words(3)) 
                });
            }
        }

        public void PrikaziIzbornik()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Izbornik za rad sa stolovima");
            Console.ResetColor();
            Console.WriteLine("-------------------------");
            Console.WriteLine("1. Pregled svih stolova");
            Console.WriteLine("2. Unos novog stola");
            Console.WriteLine("3. Promjena podataka postojećeg stola");
            Console.WriteLine("4. Brisanje stola");
            Console.WriteLine("5. Povratak na glavni izbornik");
            OdabirOpcijeIzbornika();
        }

        private void OdabirOpcijeIzbornika()
        {
            Console.WriteLine();
            switch (PomocnoRR.UcitajRasponBroja("Odaberite stavku izbornika", 1, 5))
            {
                case 1:
                    PrikaziStol();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnosNovogStola();
                    PrikaziIzbornik();
                    break;
                case 3:
                    PromjeniPodatkeStola();
                    PrikaziIzbornik();
                    break;
                case 4:
                    ObrisiStol();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.Clear();
                    break;
            }
        }

        private void ObrisiStol()
        {
            if (Stolovi.Count == 0)
            {
                Console.WriteLine("Nema stolova za brisanje.");
                return;
            }

            PrikaziStol();
            var odabrani = Stolovi[
                PomocnoRR.UcitajRasponBroja("Odaberi redni broj stola za brisanje",
                1, Stolovi.Count) - 1
                ];
            if (PomocnoRR.UcitajBool("Jeste li sigurni da želite obrisati stol broj " + odabrani.BrojStola + "? (DA/NE)", "da"))
            {
                Stolovi.Remove(odabrani);
            }
        }

        private void PromjeniPodatkeStola()
        {
            if (Stolovi.Count == 0)
            {
                Console.WriteLine("Nema stolova za promjenu.");
                return;
            }

            PrikaziStol();
            var odabrani = Stolovi[
                PomocnoRR.UcitajRasponBroja("Odaberi redni broj za promjenu: ",
                1, Stolovi.Count) - 1
                ];

            odabrani.BrojStola = PomocnoRR.UcitajRasponBroja("Unesi novi broj stola: ", 1, int.MaxValue);
            odabrani.Kapacitet = PomocnoRR.UcitajRasponBroja("Unesi novi kapacitet stola: ", 1, int.MaxValue);
            odabrani.Lokacija = PomocnoRR.UcitajString(odabrani.Lokacija, "Unesi novu lokaciju stola: ", 50, true);

        }

        public void PrikaziStol()
        {
            PrikaziStol(Stolovi, "Popis stolova u aplikaciji");
        }

        public void PrikaziStol(List<Stol> stoloviLista, string naslov)
        {
            Console.WriteLine("----------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(naslov);
            Console.ResetColor();
            Console.WriteLine("----------------");

            if (stoloviLista.Count == 0)
            {
                Console.WriteLine("Trenutno nema unesenih stolova.");
                return;
            }

            int rb = 0;
            foreach (var s in stoloviLista)
            {
                Console.WriteLine(++rb + ". Broj stola: " + s.BrojStola + ", Kapacitet: " + s.Kapacitet + ", Lokacija: " + s.Lokacija);
            }
        }

        private void UnosNovogStola()
        {
            Console.WriteLine("***************");
            Console.WriteLine("Unesite tražene podatke o stolu");
            Stolovi.Add(new()
            {
                BrojStola = PomocnoRR.UcitajRasponBroja("Unesi broj stola: ", 1, int.MaxValue),
                Kapacitet = PomocnoRR.UcitajRasponBroja("Unesi kapacitet stola: ", 1, int.MaxValue),
                Lokacija = PomocnoRR.UcitajString("Unesi lokaciju stola: ", 50, true),
            });
            PotvrdaUnosa();
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
                ObradaStol obradaStol = new ObradaStol();
                obradaStol.Resetirajunesenepodatke();
                obradaStol.PrikaziIzbornik();
                return false;
            }
        }

        private void Resetirajunesenepodatke()
        {
            if (Stolovi.Count > 0)
            {
                Stolovi.RemoveAt(Stolovi.Count - 1);
            }
        }
    }
}