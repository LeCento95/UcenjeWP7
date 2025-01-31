using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.E18NasljedivanjePolimorfizam
{
    public class ObradaUlazniRacun : Obrada
    {
        public override void Obradi()
        {
            Console.WriteLine("Moram provjeriti da li je iznos dobar");
            Console.WriteLine("Provjeravam imam li novaca");
            Console.WriteLine("Placam prema dobivenim podacima");
        }

        public override string Opis()
        {
            return "Obrada ulaznog racuna";
        }
    }
}
