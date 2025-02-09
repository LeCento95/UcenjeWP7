using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ucenje.E20KonzolnaAplikacija;
using Ucenje.E20RestoranRezervacije.Models;

namespace Ucenje.E20RestoranRezervacije
{
    internal class ObradaRezervacija
    {
        public List<Rezervacija> Rezervacije { get; set; }
        private ObradaGost _obradaGost;
        private ObradaStol _obradaStol;

        public ObradaRezervacija(ObradaGost obradaGost, ObradaStol obradaStol)
        {
            Rezervacije = new List<Rezervacija>();
            _obradaGost = obradaGost;
            _obradaStol = obradaStol;
            if (PomocnoRR.DEV)
            {
                UcitajTestnePodatke();
            }
        }

        public ObradaRezervacija()
        {
        }

        private void UcitajTestnePodatke()
        {
            for (int i = 0; i < 5; i++)
            {
                if (_obradaGost.Gosti.Count > 0 && _obradaStol.Stolovi.Count > 0)
                {
                    Rezervacije.Add(new Rezervacija
                    {
                        GostId = _obradaGost.Gosti[i % _obradaGost.Gosti.Count].Sifra,
                        StolId = _obradaStol.Stolovi[i % _obradaStol.Stolovi.Count].Sifra,
                        DatumVrijeme = DateTime.Now.AddDays(i),
                        BrojOsoba = Faker.RandomNumber.Next(1, 6),
                        Napomena = Faker.Lorem.Sentence()
                    });
                }
            }
        }

        public void PrikaziIzbornik()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Izbornik za rad s rezervacijama");
            Console.ResetColor();
            Console.WriteLine("-------------------------");
            Console.WriteLine("1. Pregled svih rezervacija");
            Console.WriteLine("2. Unos nove rezervacije");
            Console.WriteLine("3. Promjena podataka postojeće rezervacije");
            Console.WriteLine("4. Brisanje rezervacije");
            Console.WriteLine("5. Povratak na glavni izbornik");
            OdabirOpcijeIzbornika();
        }

        private void OdabirOpcijeIzbornika()
        {
            Console.WriteLine();
            switch (PomocnoRR.UcitajRasponBroja("Odaberite stavku izbornika", 1, 5))
            {
                case 1:
                    PrikaziRezervaciju();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnosNoveRezervacije();
                    PrikaziIzbornik();
                    break;
                case 3:
                    PromjeniPodatkeRezervacije();
                    PrikaziIzbornik();
                    break;
                case 4:
                    ObrisiRezervaciju();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.Clear();
                    break;
            }
        }

        public void PrikaziRezervaciju()
        {
            PrikaziRezervaciju(Rezervacije, "Popis rezervacija u aplikaciji");
        }

        public void PrikaziRezervaciju(List<Rezervacija> rezervacijeLista, string naslov)
        {
            Console.WriteLine("----------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(naslov);
            Console.ResetColor();
            Console.WriteLine("----------------");

            if (rezervacijeLista.Count == 0)
            {
                Console.WriteLine("Trenutno nema unesenih rezervacija.");
                return;
            }

            int rb = 0;
            foreach (var r in rezervacijeLista)
            {
                var gost = _obradaGost.Gosti.FirstOrDefault(g => g.Sifra == r.GostId);
                var stol = _obradaStol.Stolovi.FirstOrDefault(s => s.Sifra == r.StolId);

                Console.WriteLine($"{++rb}. Gost: {gost?.Ime} {gost?.Prezime}, Stol: {stol?.BrojStola}, Datum: {r.DatumVrijeme}, Broj osoba: {r.BrojOsoba}, Napomena: {r.Napomena}");
            }
        }

        private void UnosNoveRezervacije()
        {
            Console.WriteLine("***************");
            Console.WriteLine("Unesite tražene podatke o rezervaciji");

            if (_obradaGost.Gosti.Count == 0 || _obradaStol.Stolovi.Count == 0)
            {
                Console.WriteLine("Nema dostupnih gostiju ili stolova za rezervaciju. Molimo prvo unesite goste i stolove.");
                return;
            }

            _obradaGost.PrikaziGosta();
            int gostId = PomocnoRR.UcitajRasponBroja("Unesite redni broj gosta: ", 1, _obradaGost.Gosti.Count);
            int sifraGosta = _obradaGost.Gosti[gostId - 1].Sifra;

            _obradaStol.PrikaziStol();
            int stolId = PomocnoRR.UcitajRasponBroja("Unesite redni broj stola: ", 1, _obradaStol.Stolovi.Count);
            int sifraStola = _obradaStol.Stolovi[stolId - 1].Sifra;

            var novaRezervacija = new Rezervacija
            {
                GostId = sifraGosta,
                StolId = sifraStola,
                DatumVrijeme = PomocnoRR.UcitajDatumVrijeme("Unesi datum i vrijeme rezervacije (dd.MM.yyyy hh:mm): ", DateTime.Now),
                BrojOsoba = PomocnoRR.UcitajRasponBroja("Unesi broj osoba: ", 1, int.MaxValue),
                Napomena = PomocnoRR.UcitajString("Unesi napomenu (opcionalno): ", 200, false),
            };

            Rezervacije.Add(novaRezervacija);
            PotvrdaUnosa(novaRezervacija); // Pass the new reservation to the confirmation method
        }

        private bool PotvrdaUnosa(Rezervacija rezervacija) // Accept the reservation as a parameter
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

                // Remove the last added reservation if the user cancels
                Rezervacije.Remove(rezervacija);

                PrikaziIzbornik();
                return false;
            }
        }

        private void PromjeniPodatkeRezervacije()
        {
            PrikaziRezervaciju();
            if (Rezervacije.Count == 0) return; // No reservations to change

            int redniBroj = PomocnoRR.UcitajRasponBroja("Unesite redni broj rezervacije koju želite promijeniti: ", 1, Rezervacije.Count);
            var rezervacijaZaPromjenu = Rezervacije[redniBroj - 1];

            Console.WriteLine("Unesite nove podatke (ili pritisnite ENTER za preskakanje):");

            _obradaGost.PrikaziGosta();
            int gostId = PomocnoRR.UcitajBroj("Unesite redni broj gosta (ili ENTER za preskakanje): ");
            if (gostId != -1) // -1 indicates ENTER was pressed
            {
                rezervacijaZaPromjenu.GostId = _obradaGost.Gosti[gostId - 1].Sifra;
            }

            rezervacijaZaPromjenu.DatumVrijeme = PomocnoRR.UcitajDatumVrijeme("Unesi datum i vrijeme rezervacije (dd.MM.yyyy hh:mm) (ili ENTER za preskakanje): ", rezervacijaZaPromjenu.DatumVrijeme);
            rezervacijaZaPromjenu.BrojOsoba = PomocnoRR.UcitajRasponBroja("Unesi broj osoba (ili ENTER za preskakanje): ", 1, int.MaxValue, rezervacijaZaPromjenu.BrojOsoba);
            rezervacijaZaPromjenu.Napomena = PomocnoRR.UcitajString("Unesi napomenu (opcionalno): ", 200, true, rezervacijaZaPromjenu.Napomena); // Allow empty input

            PotvrdaUnosa(rezervacijaZaPromjenu);
        }


        private void ObrisiRezervaciju()
        {
            PrikaziRezervaciju();
            if (Rezervacije.Count == 0) return;

            int redniBroj = PomocnoRR.UcitajRasponBroja("Unesite redni broj rezervacije koju želite obrisati: ", 1, Rezervacije.Count);
            var rezervacijaZaBrisanje = Rezervacije[redniBroj - 1];

            Console.WriteLine($"Jeste li sigurni da želite obrisati rezervaciju za gosta {_obradaGost.Gosti.FirstOrDefault(g => g.Sifra == rezervacijaZaBrisanje.GostId)?.Ime} {_obradaGost.Gosti.FirstOrDefault(g => g.Sifra == rezervacijaZaBrisanje.GostId)?.Prezime}?");
            if (PomocnoRR.UcitajBool("Odgovorite sa DA ili NE: "))
            {
                Rezervacije.Remove(rezervacijaZaBrisanje);
                Console.WriteLine("Rezervacija je uspješno obrisana.");
            }
            else
            {
                Console.WriteLine("Odustali ste od brisanja rezervacije.");
            }
        }
    }
}
