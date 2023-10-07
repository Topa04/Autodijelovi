using System;
using System.Collections.Generic;

#nullable disable

namespace Autodijelovi.Models
{
    public partial class Modeli
    {
        public Modeli()
        {
            ModeliRadnjas = new HashSet<ModeliRadnja>();
        }

        public int IdModela { get; set; }
        public string NazivModela { get; set; }
        public string GodinaProizvodnje { get; set; }
        public string Pogon { get; set; }
        public string Gorivo { get; set; }
        public string SnagaMotora { get; set; }
        public string Kubikaža { get; set; }

        public virtual ICollection<ModeliRadnja> ModeliRadnjas { get; set; }
    }
}
