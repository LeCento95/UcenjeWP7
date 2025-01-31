using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{
    internal class Vjezba07
    {
        public static void Izvedi()
        {
            //Console.WriteLine("07");

            int i = 2, j = 3; // Deklaracija i inicijalizacija varijabli i i j
            
            int k = i + j;    // Zbrajanje (i) i (j) i spremanje rezultata u k (k = 5)
            
            k = i - j;        // Oduzimanje (j) od (i) i spremanje rezultata u k (k = -1)
           
            k = i * j;        // Množenje (i) i (j) i spremanje rezultata u k (k = 6)
            
            double t = k / j; // Dijeljenje (k) s (j) i spremanje rezultata u t (t = 2).
                              // Važno je da je t double jer dijelomo cijele brojeve, a rezultat može biti decimalni broj.
            
            bool b = k == j; // Usporedba (k) i (j) i spremanje rezultata u b (b = false)
           
            b = k > j;       // Usporedba k i j po "veće od", rezultat (false) se sprema u b
            
            b = k != j;      // Usporedba k i j po nejednakosti, rezultat (true) se sprema u b
           
            bool p = true; b = false; // Deklaracija i inicijalizacija logičkih varijabli p i b. b je predefiniran na false
            
            b = p & b;      // Logičku AND operator. p & b = true & false = false. Rezultat se sprema u b.
            
            b = p && b;     // Kratki spoj logički AND operator. p && b = true && false = false.
                            // rezultat se sprema u b. Razlika između & i && je u tome što && ne evaluira drugi operand ako je prvi operand false.
                            // U ovom slučaju, budući da je p true, b se evaluira. Da je p false, b se ne bi ni pogledao.
            Console.WriteLine("i={0}, k{1}", i, k);
        }


    }
}
