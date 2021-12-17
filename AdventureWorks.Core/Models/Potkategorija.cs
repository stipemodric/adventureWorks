using System;
using System.Collections.Generic;

#nullable disable

namespace AdventureWorks.Models
{
    public partial class Potkategorija
    {
        public Potkategorija()
        {
            Proizvods = new HashSet<Proizvod>();
        }

        public int Idpotkategorija { get; set; }
        public int KategorijaId { get; set; }
        public string Naziv { get; set; }

        public virtual Kategorija Kategorija { get; set; }
        public virtual ICollection<Proizvod> Proizvods { get; set; }
    }
}
