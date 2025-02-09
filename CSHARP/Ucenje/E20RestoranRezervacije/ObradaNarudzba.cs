using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ucenje.E20KonzolnaAplikacija; // Assuming PomocnoRR is here
using Ucenje.E20RestoranRezervacije.Models;

namespace Ucenje.E20RestoranRezervacije
{
    internal class ObradaNarudzba
    {
        public List<Narudzba> Narudzbe { get; set; }
        private ObradaRezervacija _obradaRezervacija;
        private ObradaJelovnik _obradaJelovnik;

        public ObradaNarudzba(ObradaRezervacija obradaRezervacija, ObradaJelovnik obradaJelovnik)
        {
            Narudzbe = new List<Narudzba>();
            _obradaRezervacija = obradaRezervacija;
            _obradaJelovnik = obradaJelovnik;
            if (PomocnoRR.DEV)
            {
                UcitajTestnePodatke();
            }
        }

        public ObradaNarudzba()
        {
        }

        private void UcitajTestnePodatke()
        {
            // Example test data (improve as needed)
            for (int i = 0; i < 5; i++)
            {
                if (_obradaRezervacija.Rezervacije.Count > 0 && _obradaJelovnik.Jela.Count > 0)
                {
                    Narudzbe.Add(new Narudzba
                    {
                        RezervacijaId = _obradaRezervacija.Rezervacije[i % _obradaRezervacija.Rezervacije.Count].Sifra,
                        JeloId = _obradaJelovnik.Jela[i % _obradaJelovnik.Jela.Count].Sifra,
                        Kolicina = Faker.RandomNumber.Next(1, 5)
                    });
                }
            }
        }

        public void PrikaziIzbornik()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Izbornik za rad s narudžbama");
            Console.ResetColor();
            Console.WriteLine("-------------------------");
            Console.WriteLine("1. Pregled svih narudžbi");
            Console.WriteLine("2. Unos nove narudžbe");
            Console.WriteLine("3. Promjena podataka postojeće narudžbe");
            Console.WriteLine("4. Brisanje narudžbe");
            Console.WriteLine("5. Povratak na glavni izbornik");
            OdabirOpcijeIzbornika();
        }

        private void OdabirOpcijeIzbornika()
        {
            Console.WriteLine();
            switch (PomocnoRR.UcitajRasponBroja("Odaberite stavku izbornika", 1, 5))
            {
                case 1:
                    PrikaziNarudzbu();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnosNoveNarudzbe();
                    PrikaziIzbornik();
                    break;
                case 3:
                    PromjeniPodatkeNarudzbe();
                    PrikaziIzbornik();
                    break;
                case 4:
                    ObrisiNarudzbu();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.Clear();
                    break;
            }
        }


        public void PrikaziNarudzbu()
        {
            PrikaziNarudzbu(Narudzbe, "Popis narudžbi u aplikaciji");
        }

        public void PrikaziNarudzbu(List<Narudzba> narudzbeLista, string naslov)
        {
            Console.WriteLine("----------------");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(naslov);
            Console.ResetColor();
            Console.WriteLine("----------------");

            if (narudzbeLista.Count == 0)
            {
                Console.WriteLine("Trenutno nema unesenih narudžbi.");
                return;
            }

            int rb = 0;
            foreach (var n in narudzbeLista)
            {
                var rezervacija = _obradaRezervacija.Rezervacije.FirstOrDefault(r => r.Sifra == n.RezervacijaId);
                var jelo = _obradaJelovnik.Jela.FirstOrDefault(j => j.Sifra == n.JeloId);

                Console.WriteLine($"{++rb}. Rezervacija: {rezervacija?.Sifra}, Jelo: {jelo?.Naziv}, Količina: {n.Kolicina}");
            }
        }

        private void UnosNoveNarudzbe()
        {
            Console.WriteLine("***************");
            Console.WriteLine("Unesite tražene podatke o narudžbi");

            if (_obradaRezervacija.Rezervacije.Count == 0 || _obradaJelovnik.Jela.Count == 0)
            {
                Console.WriteLine("Nema dostupnih rezervacija ili jela za narudžbu. Molimo prvo unesite rezervacije i jela.");
                return;
            }

            _obradaRezervacija.PrikaziRezervaciju(); // Display available reservations
            int rezervacijaId = PomocnoRR.UcitajRasponBroja("Unesite redni broj rezervacije: ", 1, _obradaRezervacija.Rezervacije.Count);
            int sifraRezervacije = _obradaRezervacija.Rezervacije[rezervacijaId - 1].Sifra;

            _obradaJelovnik.PrikaziJelo(); // Display available menu items
            int jeloId = PomocnoRR.UcitajRasponBroja("Unesite redni broj jela: ", 1, _obradaJelovnik.Jela.Count);
            int sifraJela = _obradaJelovnik.Jela[jeloId - 1].Sifra;


            Narudzbe.Add(new()
            {
                RezervacijaId = sifraRezervacije,
                JeloId = sifraJela,
                Kolicina = PomocnoRR.UcitajRasponBroja("Unesi količinu: ", 1, int.MaxValue),
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
                ObradaNarudzba obradaNarudzba = new ObradaNarudzba(new ObradaRezervacija(new ObradaGost(), new ObradaStol()), new ObradaJelovnik()); // Potential issue - see below
                obradaNarudzba.Resetirajunesenepodatke();
                obradaNarudzba.PrikaziIzbornik();
                return false;
            }
        }

        private void Resetirajunesenepodatke()
        {
            if (Narudzbe.Count > 0)
            {
                Narudzbe.RemoveAt(Narudzbe.Count - 1);
            }
        }


        private void PromjeniPodatkeNarudzbe()
        {
            PrikaziNarudzbu();
            if (Narudzbe.Count == 0) return;

            int redniBroj = PomocnoRR.UcitajRasponBroja("Unesite redni broj narudžbe koju želite promijeniti: ", 1, Narudzbe.Count);
            var narudzbaZaPromjenu = Narudzbe[redniBroj - 1];

            Console.WriteLine("Unesite nove podatke (ili pritisnite ENTER za preskakanje):");

            _obradaRezervacija.PrikaziRezervaciju();
            int rezervacijaId = PomocnoRR.UcitajBroj("Unesite redni broj rezervacije (ili ENTER za preskakanje): ");
            if (rezervacijaId != -1)
            {
                narudzbaZaPromjenu.RezervacijaId = _obradaRezervacija.Rezervacije[rezervacijaId - 1].Sifra;
            }

            _obradaJelovnik.PrikaziJelo();
            int jeloId = PomocnoRR.UcitajBroj("Unesite redni broj jela (ili ENTER za preskakanje): ");
            if (jeloId != -1)
            {
                narudzbaZaPromjenu.JeloId = _obradaJelovnik.Jela[jeloId - 1].Sifra;
            }

            narudzbaZaPromjenu.Kolicina = PomocnoRR.UcitajRasponBroja("Unesite količinu (ili ENTER za preskakanje): ", 1, int.MaxValue, narudzbaZaPromjenu.Kolicina);

            PotvrdaUnosa();
        }

        private void ObrisiNarudzbu()
        {
            PrikaziNarudzbu();
            if (Narudzbe.Count == 0) return;

            int redniBroj = PomocnoRR.UcitajRasponBroja("Unesite redni broj narudžbe koju želite obrisati: ", 1, Narudzbe.Count);
            var narudzbaZaBrisanje = Narudzbe[redniBroj - 1];

            Console.WriteLine($"Jeste li sigurni da želite obrisati narudžbu za rezervaciju {narudzbaZaBrisanje.RezervacijaId}?");
            if (PomocnoRR.UcitajBool("Odgovorite sa DA ili NE: "))
            {
                Narudzbe.Remove(narudzbaZaBrisanje);
                Console.WriteLine("Narudžba je uspješno obrisana.");
            }
            else
            {
                Console.WriteLine("Odustali ste od brisanja narudžbe.");
            }
        }
    }
}
    
