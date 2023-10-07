using System;
using System.Collections.Generic;

#nullable disable

namespace Autodijelovi.Models
{
    public partial class Radnja
    {
        public Radnja()
        {
            ModeliRadnjas = new HashSet<ModeliRadnja>();
        }

        public int IdRadnje { get; set; }
        public string NazivRadnje { get; set; }
        public string Grad { get; set; }
        public string Adresa { get; set; }
        public string KontaktTel { get; set; }
        public string EMail { get; set; }

        public virtual ICollection<ModeliRadnja> ModeliRadnjas { get; set; }
    }
}
