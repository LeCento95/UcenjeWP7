using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{
    internal class E06Nizovi
    {
        public static void Izvedi()
        {
            //motivacija: Treba pohraniti prosječne temperature u 12 mjeseci

            // krivi pristup
            int sijecanj, veljaca, ozujak, /* .. */ prosinac; // NE RADITI 12 varijabli


            // end. Arrays
            // još na HR polja
            // uglata zagrada Alt Gr + F, zatvoreno je Alt Gr + G


            // jednodimenzionalni niz
            int[] temp = new int[12]; // gglavni problem nizova je što u trenutku kreiranja moraš znati koliko elemenata

            // niz ima index i vrijednost
            temp[0] = -1; //siječanj
            temp[1] = 1; //veljača
            //...
            temp[11] = 4; // prosinac

            Console.WriteLine(temp[0]);
            Console.WriteLine(temp);
            // ispisivanje svih elemenata niza
            Console.WriteLine(string.Join(",", temp));

            // dvodimenzionalni niz - tablica
            int[,] tablica =
            {
                { 1, 2, 3,2,2,2,2,2},
                { 4, 5, 6,2,2,2,2,2},
                { 7, 8, 9,2,2,2,2,2}
            };


            // ispišite broj 6
            Console.WriteLine(tablica[1,2]);


            // trodimenzionalni niz - kocka
            int[,,] kocka = new int [10,10,10];

            kocka[5, 5, 5] = 27;

            Console.WriteLine(kocka[5, 5, 5]);

            // četverodimezionalni niz - tesaarect 

            // multiverse
            int[,,,,,,,] multiverse;

            // zašto nam je bitan jednodimenzionalni niz

            string grad = "NajXbolji grad       je Osijek";

            // ispiši slovo j
            // string je niz znakova

            Console.WriteLine(grad[3]);

            char znak = 'A';

            // ispišite zadnji znak
            Console.WriteLine(grad[grad.Length-1]);
            Console.WriteLine(grad.Length);


        }


    }
    }
