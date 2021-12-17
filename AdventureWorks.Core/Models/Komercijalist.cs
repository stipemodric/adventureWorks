using System;
using System.Collections.Generic;

#nullable disable

namespace AdventureWorks.Models
{
    public partial class Komercijalist
    {
        public Komercijalist()
        {
            Racuns = new HashSet<Racun>();
        }

        public int Idkomercijalist { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public bool? StalniZaposlenik { get; set; }

        public virtual ICollection<Racun> Racuns { get; set; }
    }
}
