using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ucenje.E20KonzolnaAplikacija;
using Ucenje.E20RestoranRezervacije.Models;

namespace Ucenje.E20RestoranRezervacije
{
    internal class ObradaGost
    {
        public List<Gost>   Gosti { get; set; }

        public ObradaGost() 
        {
            Gosti = new List<Gost>();
            if (PomocnoRR.DEV)
            {
                UcitajTestnePodatke();
            }
        }

        private void UcitajTestnePodatke()
        {
            for (int i = 0; i < 10; i++)
            {
                Gosti.Add(new Gost()
                {
                    Ime = Faker.Name.First(),
                    Prezime = Faker.Name.Last(),
                });
            }
        }

        public void PrikaziIzbornik()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Izbornik za rad s gostima");
            Console.ResetColor();
            Console.WriteLine("-------------------------");
            Console.WriteLine("1. Pregled svih gostiju");
            Console.WriteLine("2. Unos novog gosta");
            Console.WriteLine("3. Promjena podataka postojećeg gosta");
            Console.WriteLine("4. Brisanje gosta");
            Console.WriteLine("5. Povratak na glavni izbornik ");
            OdabirOpcijeIzbornika();
        }

        private void OdabirOpcijeIzbornika()
        {
            Console.WriteLine();
            switch (PomocnoRR.UcitajRasponBroja("Odaberite stavku izbornika", 1, 5))
            {
                case 1:
                    PrikaziGosta();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnosNovogGosta();
                    PrikaziIzbornik();
                    break;
                case 3:
                    PromjenipodatkeGosta();
                    PrikaziIzbornik();
                    break;
                case 4:
                    ObrsiGosta();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.Clear();
                    break;
            }
        }

        private void ObrsiGosta()
        {
            var odabrani = Gosti[
                PomocnoRR.UcitajRasponBroja("Odaberi redni broj gosta za brisanje",
                1, Gosti.Count) - 1
                ];
            if (PomocnoRR.UcitajBool("Jeste li sigurni da želite obrisati gosta" + odabrani.Ime + "" + odabrani.Prezime + "? (DA/NE)", "da"))
            {
                Gosti.Remove(odabrani);
            }
        }

        private void PromjenipodatkeGosta()
        {
            PrikaziGosta();
            var odabrani = Gosti[
                PomocnoRR.UcitajRasponBroja("Odaberi redni broj za promjenu: ",
                1, Gosti.Count) - 1
                ];
            odabrani.Sifra = PomocnoRR.UcitajRasponBroja("Unesi šifru gosta: ", 1, int.MaxValue);
            odabrani.Ime = PomocnoRR.UcitajString(odabrani.Ime, "Unesi ime gosta: ", 50, true);
            odabrani.Prezime = PomocnoRR.UcitajString("Unesi prezime gosta: ", 50, true);
            odabrani.BrojTelefona = PomocnoRR.UcitajString("Unesi broj telefona gosta: ", 50, true);
            odabrani.Email = PomocnoRR.UcitajString("Unesi Email gosta: ", 50, true);
        }

        public void PrikaziGosta()
        {
            PrikaziGosta(Gosti, "Popis gostiju u aplikaciji");
        }

        public void PrikaziGosta(List<Gost> gostiLista, string naslov)
        {
            Console.WriteLine("----------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(naslov);
            Console.ResetColor();
            Console.WriteLine("----------------");

            int pg = 0;
            foreach (var g in gostiLista)
            {
                Console.WriteLine(++pg + ". " + g.Ime + " " + g.Prezime);
            }
        }

        private void UnosNovogGosta()
        {
            Console.WriteLine("***************");
            Console.WriteLine("Unesite tražene podatke o gostu");
            Gosti.Add(new()
            {
                Sifra = PomocnoRR.UcitajRasponBroja("Unesi šifru gosta: ", 1, int.MaxValue),
                Ime = PomocnoRR.UcitajString("Unesi ime gosta: ", 50, true),
                Prezime = PomocnoRR.UcitajString("Unesi prezime gosta: ", 50, true),
                BrojTelefona = PomocnoRR.UcitajString("Unesi telefon gosta: ", 50, true),
                Email = PomocnoRR.UcitajString("Unesi email gosta: ", 50, true),
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
                ObradaGost obradaGost = new ObradaGost();
                obradaGost.Resetirajunesenepodatke();
                obradaGost.PrikaziIzbornik();
                return false;
            }
        }
        
        private void Resetirajunesenepodatke()
        {
            if (Gosti.Count > 0)
            {
                Gosti.RemoveAt(Gosti.Count - 1);
            }
        }

    }
}
