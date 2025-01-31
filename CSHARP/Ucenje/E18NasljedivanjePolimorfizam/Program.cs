using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.E18NasljedivanjePolimorfizam
{
    public class Program
    {
        public Program()
        {
            Console.WriteLine("E18");
        }

        // preopterećenje konstruktora

        public Program(string naslov):this()
        {
            Console.WriteLine(naslov);


            Smjer smjer = new(); // 1. poziv konstruktora klase Smjer

            smjer.Sifra = 1;
            smjer.Naziv = "Web programiranje";
            //smjer.VidimUPodKlasama = "ne vidim"; // protected svojstvo iz nadklase


            var s = new Smjer { Sifra=2, Naziv = "Programiranje" }; // 2. poziv konstruktora klase Smjer


            var s2 = new Smjer(3, "Serviser"); // 3. poziv konstruktora klase Smjer ali onaj s dva parametra


            Console.WriteLine(s2.Naziv);


            Polaznik polaznik = new Polaznik();

            string a = "AA";

            Console.WriteLine(a.GetHashCode());

            a = "bb";

            Console.WriteLine(a.GetHashCode());

            // razlog zasto su vrijednosti ispisa razlicite je taj sto je string immutable (nepromjenjiv)

            a = "AA" + a + "BB"; // ovo nije dobra praksa

            // dobra praska za rad s stringovima
            var sb = new StringBuilder();
            sb.Append("AA");

            Console.WriteLine($"vrijednost: {sb}, hashcode: {sb.GetHashCode()}" );

            sb.Clear().Append("bb");

            Console.WriteLine($"vrijednost: {sb}, hashcode: {sb.GetHashCode()}");

            Console.WriteLine(s2);
            Random r = new Random();

            for (int i = 0; i < 10; i++)
            {
                s = new Smjer(i+1,$"Naziv {r.Next(1,100)}");
                Console.WriteLine(s);
            }


            s = new() { Sifra=1, Naziv = "Web programiranje" };
            Console.WriteLine(s.GetHashCode());
            s2 = new() { Sifra=2, Naziv = "Web programiranje" };
            Console.WriteLine(s2.GetHashCode());
            Console.WriteLine(s.Equals(s2));


            //Entitet e = new(); // ne mozes instancirati apstraktnu klasu
            // e.Sifra = 1;

            // A sto ako bas zelim koristiti sve iz Entiteta?

            var e = new EntitetImpl();
            e.Sifra = 1;


            // Uskoro polimorfizam, jos malo pozornice

            Obrada[] obrade = new Obrada[4]; 

            obrade[0] = new ObradaUlazniRacun();
            obrade[1] = new ObradaUlazniRacun();
            obrade[2] = new ObradaIzlazniRacun();
            obrade[3] = new ObradaUlazniRacun();
            Console.WriteLine("****************************");
            ZavrsiPosao(obrade);


            Console.WriteLine("****************************");

            var smjerBaza = new edunova.Smjer() { Sifra=1,Naziv="Dizajn",Cijena=1.4m};

            Console.WriteLine(smjerBaza);

            Console.WriteLine(new edunova.Polaznik() { Ime="Pero", Sifra=1, Prezime="Peric"});

        }





        private void ZavrsiPosao(Obrada[] obrade)
        {
            // ovo je polimorfizam (viseoblicje)
            foreach (var o in obrade)
            {
                Console.WriteLine(o.GetType());
                Console.WriteLine(o.Opis());
                o.Obradi();
            }
        }

    }
}
