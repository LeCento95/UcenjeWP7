using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.E20RestoranRezervacije.Models
{
    internal class Gost : Entitet, IComparable<Gost>
    {
        public new int Sifra { get; set; }
        public string? Ime { get; set; } = "";
        public string? Prezime { get; set; } = "";
        public string? BrojTelefona { get; set; } = "";
        public string? Email { get; set; } = "";

        public virtual ICollection<Rezervacija> Rezervacije { get; set; } = new List<Rezervacija>();

        public int CompareTo(Gost? other)
        {
            if (other == null) return 1;
            return Prezime?.CompareTo(other.Prezime) ?? 1;
        }

        public override string ToString()
        {
            return $"{Ime} {Prezime}, {BrojTelefona}, {Email}";
        }
    }
}
