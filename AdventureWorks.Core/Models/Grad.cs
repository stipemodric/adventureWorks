using System;
using System.Collections.Generic;

#nullable disable

namespace AdventureWorks.Models
{
    public partial class Grad
    {
        public Grad()
        {
            Kupacs = new HashSet<Kupac>();
        }

        public int Idgrad { get; set; }
        public string Naziv { get; set; }
        public int? DrzavaId { get; set; }

        public virtual Drzava Drzava { get; set; }
        public virtual ICollection<Kupac> Kupacs { get; set; }
    }
}
