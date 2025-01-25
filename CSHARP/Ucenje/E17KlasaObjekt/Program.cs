using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.E17KlasaObjekt
{
    public class Program
    {
        
        // 5. vrsta metode je konstruktor
        public Program()
        {
            Console.WriteLine("E17");

            // Objekt je pojavnost/instanca klase --> Ovo naučiti napamet
            // Osoba (primjetiti veliko slovo O) je klasa
            // osoba (primjetiti malo slovo o) je objekt, instanca, varijabla
            Osoba osoba = new Osoba(); // kreiranje objekta klase Osoba

            osoba.Sifra = 1;
            osoba.Ime = "Pero"; // pozvao si setter (učahurivanje)
            osoba.Prezime = "Perić";
            osoba.DatumRodjenja = new DateTime(2000, 1, 1);

            Console.WriteLine(osoba.Ime); // pozvao si getter (izčahurivanje)

            Osoba[] osobe = new Osoba[3];

            osobe[0] = osoba;

            
            // upoznati se s kraćom sintaksom za inicijalizaciju objekta
            osobe[1] = new Osoba { Ime = "Ana", Prezime = "Zimska" };
            
            Console.WriteLine(osobe[1].Ime);

            Console.WriteLine("*********************");
            foreach (Osoba vo in osobe) // vo mi glumi varijabla osoba
            {
                Console.WriteLine(vo?.Ime ?? "Nije postavljeno"); // ovdje ? znaci da ako je null da ne pukne, ?? je null coalescing operator, ako je o null ispisi Nije postavljeno
            }

            Console.WriteLine("*********************");            
            Console.WriteLine(osoba.Moje); // izvana se može samo čitati, a u klasi se postavljati
            Console.WriteLine(osoba.ImePrezime()); // na objektu osoba zovem metodu ImePrezime
            Console.WriteLine(osoba.Moje);
            //osoba.Hello(); // ovo ne mogu
            Osoba.Hello(); //ovo mogu jer je static

            // ispisi Ana Zimska
            Console.WriteLine(osobe[1].ImePrezime());

            //ne treba pisati s desne strane jer piše s lijeve (Mjesto)
            Mjesto mjesto = new() { Naziv = "Osijek", PostanskiBroj = "3100" };

            osoba.Mjesto = mjesto;

            //ispisati Osijek
            Console.WriteLine(osoba.Mjesto.Naziv);

            //ne treba pisati s lijeve strane ako pise s desne (Mjesto)
            var m = new Mjesto { Naziv = "Zagreb", PostanskiBroj = "10000" }; // () nakon imena klase može se izostaviti

            osobe[1].Mjesto = m;

            //ispisati Zagreb
            Console.WriteLine(osobe[1].Mjesto.Naziv);


            osobe[2] = new()
            {
                Ime = "Ivo",
                Mjesto = new()
                {
                    Naziv = "Split"
                }
            };

            //ispisati Split
            Console.WriteLine(osobe[2].Mjesto.Naziv);

            // Primjer koristenja klasa iz SDK-a

            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(random.Next(1, 10));
            }


            // da ne pišem svaki puta osoba[2] mogu koristiti varijablu o
            var o = osobe[2];

            o.Mjesto.Zupanija = new Zupanija
            {
                Naziv = "Splitsko-dalmatinska",
                Zupan = new()
                {
                    Ime = "Marko",
                    Mjesto = new()
                    {
                        Naziv = "Sinj"
                    }
                }
            };

            // ispisati Sinj, krenemo od o
            Console.WriteLine(o.Mjesto.Zupanija.Zupan.Mjesto.Naziv);


            // In the Program constructor, add the following code to create an instance of Polaznik
            Polaznik polaznik = new()
            {
                Naziv = "Web programiranje",
                Trajanje = 225,
                Cijena = 1254.99m,
                Vaucer = true,
                IzvodiseOd = new DateTime(2024, 9, 7, 17, 0, 0)
            };

            // Example usage of the polaznik instance
            Console.WriteLine($"Naziv: {polaznik.Naziv}, Trajanje: {polaznik.Trajanje}, Cijena: {polaznik.Cijena}, Vaucer: {polaznik.Vaucer}, IzvodiseOd: {polaznik.IzvodiseOd}");

        }

        public class Polaznik
        {
            public string Naziv { get; set; }
            public int Trajanje { get; set; }
            public decimal Cijena { get; set; }
            public bool Vaucer { get; set; }
            public DateTime IzvodiseOd { get; set; }
        }
    }
}
    


           



        
    

