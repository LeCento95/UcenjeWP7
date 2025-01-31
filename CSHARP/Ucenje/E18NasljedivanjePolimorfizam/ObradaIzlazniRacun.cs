using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.E18NasljedivanjePolimorfizam
{
    public class ObradaIzlazniRacun : Obrada
    {
        public override void Obradi()
        {
            Console.WriteLine("nazovi covjeka da li mu se moze poslati racun");
            Console.WriteLine("azuriraj si primanja na datum valute");
        }

        public override string Opis()
        {
            return "Obrada izlaznog racuna";
        }
    }
}
