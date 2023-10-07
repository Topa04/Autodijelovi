using System;
using System.Collections.Generic;

#nullable disable

namespace Autodijelovi.Models
{
    public partial class ModeliRadnja
    {
        public int IdVeze { get; set; }
        public int IdRadnje { get; set; }
        public int IdModela { get; set; }
        public int IdDijela { get; set; }

        public virtual Dijelovi IdDijelaNavigation { get; set; }
        public virtual Modeli IdModelaNavigation { get; set; }
        public virtual Radnja IdRadnjeNavigation { get; set; }
    }
}
