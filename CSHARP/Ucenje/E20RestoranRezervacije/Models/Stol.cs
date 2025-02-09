using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.E20RestoranRezervacije.Models
{
    internal class Stol : Entitet
    {
        public new int Sifra { get; set; }
        public int BrojStola { get; set; }
        public int Kapacitet { get; set; }
        public string Lokacija { get; set; } = string.Empty;

        public virtual ICollection<Rezervacija> Rezervacija { get; set; } = new List<Rezervacija>();
    }
}
