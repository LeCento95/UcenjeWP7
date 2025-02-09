using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.E20RestoranRezervacije.Models
{
    internal abstract class Entitet
    {
        public int? Sifra { get; set; }

        public override string ToString()
        {
            return Sifra?.ToString() ?? "null";
        }
    }
}
