using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.E19GSALE
{
    public class Program
    {

        public Program()
        {
            Console.WriteLine("E19");

            // problem nizova? Moramo znati velicinu niza prije nego sto ga kreiramo

            // tom problemu u C# se doskace s koristenje List
            // List koristi sintaksu parametriziranja, moramo shvatiti sto su Generic klase (generici)
            List<int> brojevi = new List<int>();

            brojevi.Add(1);
            brojevi.Add(7);

            var sb = new Random();
            for(int i = 0; i < 20; i++)
            {
                brojevi.Add(sb.Next(1, 100));
            }

            // trenutno u listi ima 22 broja
            Console.WriteLine(brojevi[6]);

            Console.WriteLine("*******************");
            foreach (var broj in brojevi)
            {
                Console.WriteLine(broj);
            }

           // brojevi.Add("a"); // nece raditi jer je lista tipizirana na int a ne za string

            List<string> imena = new List<string>();
            imena.Add("Ivan");
            imena.Add("Marko");

            Console.WriteLine(imena[1]);

            List<Smjer> smjerovi = new List<Smjer>();

            smjerovi.Add(new Smjer { Sifra = 1, Naziv = "Web programiranje" });
            smjerovi.Add(new () { Sifra = 2, Naziv = "Serviser" });

            var o = new Obrada<Smjer>();

            o.PredmetObrade = smjerovi[0];

            o.Posao();

            var op = new Obrada<Polaznik>();

            op.PredmetObrade = new Polaznik { Sifra = 7, Ime = "Ivan", Prezime = "Mrav" };

            op.Posao();

            //var os = new Obrada<string>(); // nece raditi jer string ne nasljeduje Entitet


            Console.WriteLine("*********************");
            foreach (var smjer in smjerovi)
            {
                Console.WriteLine(smjer.Naziv);
            }

            Console.WriteLine("***********************");

            smjerovi.Sort();

            foreach (var smjer in smjerovi)
            {
                
                Console.WriteLine(smjer.Naziv);
            }


            op.Job();



            Console.WriteLine(smjerovi[0]);

            Console.WriteLine(Zbroj(3,4));
            Console.WriteLine(Zbroj(1,1));

            // lambda izrazi =>
            var Zbroji = (int a, int b) => a + b;

            Console.WriteLine(Zbroji(3,4));

            var Algoritam = (int a, int b) =>
            {
                if (a > b)
                {
                    return true;
                }
                return false;
            };

            Console.WriteLine(Algoritam(7,7));


            var br = 6;
            if(br%2 == 0)
            {
                Console.WriteLine("Paran");
            }
            else
            {
                Console.WriteLine("Neparan");
            }

            var Paran = (int i) => i% 2 == 0;

            Console.WriteLine(Paran(6) ? "Paran" : "Neparan");



            // ekstenzije


            Console.WriteLine(smjerovi.FirstOrDefault());


            // smjerovi[0].FirstOrDefault(); ovo ne moe jer FirstOrDefault nije metoda nad Smjer

            //smjerovi[0].Ispis();

            var jedanSmjer = smjerovi[0];

            jedanSmjer.Ispis();

            var jedanPolaznik = op.PredmetObrade;

            jedanPolaznik.Ispis();


            op.Odradi();
            jedanSmjer.Odradi();


            // o osnovnim OOP principima pogledati https://github.com/tjakopec/OOP_JAVA_PHP_PYTHON_SWIFT


        }

        public int Zbroj(int a, int b)
        {
            return a + b;
        }

    }
}
