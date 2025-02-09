using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.E20RestoranRezervacije.Models
{
    internal class Narudzba : Entitet
    {
        public int Sifra { get; set; }
        public int RezervacijaId { get; set; }
        public Rezervacija? Rezervacija { get; set; }
        public int JeloId { get; set; }
        public Jelovnik? Jelo { get; set; }
        public int Kolicina { get; set; }
    }

    
}
