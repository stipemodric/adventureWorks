using System;
using System.Collections.Generic;

#nullable disable

namespace AdventureWorks.Models
{
    public partial class Kategorija
    {
        public Kategorija()
        {
            Potkategorijas = new HashSet<Potkategorija>();
        }

        public int Idkategorija { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Potkategorija> Potkategorijas { get; set; }
    }
}
