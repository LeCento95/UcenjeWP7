using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.E20RestoranRezervacije.Models
{
    internal class Jelovnik : Entitet
    {
        public new int Sifra { get; set; }
        public  string NazivJela { get; set; }
        public  string Kategorija { get; set; }
        public decimal Cijena { get; set; }

        public virtual ICollection<Narudzba> Narudzba { get; set; } = new List<Narudzba>();
        public object Naziv { get; internal set; }
        public object Opis { get; internal set; }
    }
}
