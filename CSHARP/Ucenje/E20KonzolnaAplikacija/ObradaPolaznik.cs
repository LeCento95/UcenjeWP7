﻿using System.Security.Cryptography;
using Ucenje.E20KonzolnaAplikacija.Model;

namespace Ucenje.E20KonzolnaAplikacija
{
    internal class ObradaPolaznik
    {

        public List<Polaznik>  Polaznici { get; set; }

        public ObradaPolaznik() 
        { 
            Polaznici = new List<Polaznik>();
            if (PomocnoRR.DEV)
            {
                UcitajTestnePodatke();
            }
        }

        private void UcitajTestnePodatke()
        {
            for(int i = 0; i < 10; i++)
            {
                Polaznici.Add(new()
                {
                    Ime = Faker.Name.First(),
                    Prezime = Faker.Name.Last()
                });
            }
        }

        public void PrikaziIzbornik()
        {
            Console.WriteLine("Izbornik za rad s polaznicima");
            Console.WriteLine("1. Pregled svih polaznika");
            Console.WriteLine("2. Unos novog polaznika");
            Console.WriteLine("3. Promjena podataka postojećeg polaznika");
            Console.WriteLine("4. Brisanje polaznika");
            Console.WriteLine("5. Povratak na glavni izbornik");
            OdabirOpcijeIzbornika();
        }

        private void OdabirOpcijeIzbornika()
        {
           switch(PomocnoRR.UcitajRasponBroja("Odaberite stavku izbornika", 1, 5))
            {
                case 1:
                    PrikaziPolaznike();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnosNovogPolaznika();
                    PrikaziIzbornik();
                    break;
                case 3:
                    PromjeniPodatakPolaznika();
                    PrikaziIzbornik();
                    break;
                case 4:
                    ObrisiPolaznika();
                    PrikaziIzbornik();
                    break;
                case 5:                    
                    Console.Clear();
                    break;
            }
        }

        private void ObrisiPolaznika()
        {
            PrikaziPolaznike();
            var odabrani = Polaznici[
                PomocnoRR.UcitajRasponBroja("Odaberi redni broj polaznika za brisanje",
                1, Polaznici.Count) - 1
                ];
            if (PomocnoRR.UcitajBool("Sigurno obrisati " + odabrani.Ime + " " + odabrani.Prezime + "? (DA/NE)", "da"))
            {
                Polaznici.Remove(odabrani);
            }
        }

        private void PromjeniPodatakPolaznika()
        {
            PrikaziPolaznike();
            var odabrani = Polaznici[
                PomocnoRR.UcitajRasponBroja("Odaberi redni broj polaznika za promjenu",
                1,Polaznici.Count)-1
                ];
            odabrani.Sifra = PomocnoRR.UcitajRasponBroja("Unesi šifru polaznika", 1, int.MaxValue);
            odabrani.Ime = PomocnoRR.UcitajString(odabrani.Ime,"Unesi ime polaznika", 50, true);
            odabrani.Prezime = PomocnoRR.UcitajString("Unesi prezime polaznika", 50, true);
            odabrani.Email = PomocnoRR.UcitajString("Unesi email polaznika", 50, true);
            odabrani.OIB = PomocnoRR.UcitajString("Unesi OIB polaznika", 50, true);
        }

        public void PrikaziPolaznike()
        {
            PrikaziPolaznike(Polaznici, "Popis polaznika u aplikaciji");
        }

        public void PrikaziPolaznike(List<Polaznik> lista, string naslov)
        {
            Console.WriteLine("*****************************");
            Console.WriteLine(naslov);
            int rb = 0;
            foreach (var p in lista)
            {
                Console.WriteLine(++rb + ". " + p.Ime + " " + p.Prezime); // prepisati metodu toString
            }
            Console.WriteLine("****************************");
        }

        public void UnosNovogPolaznika()
        {
            Console.WriteLine("***************************");
            Console.WriteLine("Unesite tražene podatke o polazniku");
            Polaznici.Add(new()
            {
                Sifra = PomocnoRR.UcitajRasponBroja("Unesi šifru polaznika", 1, int.MaxValue),
                Ime = PomocnoRR.UcitajString("Unesi ime polaznika", 50, true),
                Prezime = PomocnoRR.UcitajString("Unesi prezime polaznika", 50, true),
                Email = PomocnoRR.UcitajString("Unesi email polaznika", 50, true),
                OIB = PomocnoRR.UcitajString("Unesi OIB polaznika", 50, true)
            });
        }
    }
}
