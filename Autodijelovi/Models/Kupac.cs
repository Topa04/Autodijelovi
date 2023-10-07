using System;
using System.Collections.Generic;

#nullable disable

namespace Autodijelovi.Models
{
    public partial class Kupac
    {
        public Kupac()
        {
            Narudzbas = new HashSet<Narudzba>();
        }

        public int IdKupca { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string Grad { get; set; }
        public string Kontakt { get; set; }
        public string BrojKartice { get; set; }

        public virtual ICollection<Narudzba> Narudzbas { get; set; }
    }
}
