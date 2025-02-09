using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.E20RestoranRezervacije.Models
{
    internal class Rezervacija : Entitet
    {
        public new int Sifra { get; set; } 
        public int GostId { get; set; }
        public Gost? Gost { get; set; }
        public int StolId { get; set; }
        public Stol? Stolovi { get; set; }
        public DateTime DatumVrijeme { get; set; }
        public int BrojOsoba { get; set; }
        public string? Napomena { get; set; } // Declare as nullable
        public virtual ICollection<Narudzba> Narudzba { get; set; } = new List<Narudzba>(); 

        public Rezervacija()
        {
            // Ensure non-nullable properties are initialized
            Napomena = string.Empty;
        }
    }
}
