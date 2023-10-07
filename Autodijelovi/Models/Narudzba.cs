using System;
using System.Collections.Generic;

#nullable disable

namespace Autodijelovi.Models
{
    public partial class Narudzba
    {
        public Narudzba()
        {
            StavkaNarudzbes = new HashSet<StavkaNarudzbe>();
        }

        public int IdNarudzbe { get; set; }
        public DateTime DatumNarudzbe { get; set; }
        public int IdKupca { get; set; }

        public virtual Kupac IdKupcaNavigation { get; set; }
        public virtual ICollection<StavkaNarudzbe> StavkaNarudzbes { get; set; }
    }
}
