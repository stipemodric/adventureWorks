using System;
using System.Collections.Generic;

#nullable disable

namespace AdventureWorks.Models
{
    public partial class Kupac
    {
        public Kupac()
        {
            Racuns = new HashSet<Racun>();
        }

        public int Idkupac { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public int? GradId { get; set; }

        public virtual Grad Grad { get; set; }
        public virtual ICollection<Racun> Racuns { get; set; }
    }
}
