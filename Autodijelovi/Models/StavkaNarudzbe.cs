using System;
using System.Collections.Generic;

#nullable disable

namespace Autodijelovi.Models
{
    public partial class StavkaNarudzbe
    {
        public int IdStavke { get; set; }
        public int Kolicina { get; set; }
        public decimal Cijena { get; set; }
        public int IdDijela { get; set; }
        public int IdNarudzbe { get; set; }

        public virtual Dijelovi IdDijelaNavigation { get; set; }
        public virtual Narudzba IdNarudzbeNavigation { get; set; }
    }
}
