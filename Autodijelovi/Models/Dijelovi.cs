using System;
using System.Collections.Generic;

#nullable disable

namespace Autodijelovi.Models
{
    public partial class Dijelovi
    {
        public Dijelovi()
        {
            ModeliRadnjas = new HashSet<ModeliRadnja>();
            StavkaNarudzbes = new HashSet<StavkaNarudzbe>();
        }

        public int IdDijela { get; set; }
        public string Sifra { get; set; }
        public string Naziv { get; set; }
        public string Proizvodac { get; set; }
        public string Cijena { get; set; }

        public virtual ICollection<ModeliRadnja> ModeliRadnjas { get; set; }
        public virtual ICollection<StavkaNarudzbe> StavkaNarudzbes { get; set; }
    }
}
