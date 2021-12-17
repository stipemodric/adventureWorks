using System;
using System.Collections.Generic;

#nullable disable

namespace AdventureWorks.Models
{
    public partial class Proizvod
    {
        public Proizvod()
        {
            Stavkas = new HashSet<Stavka>();
        }

        public int Idproizvod { get; set; }
        public string Naziv { get; set; }
        public string BrojProizvoda { get; set; }
        public string Boja { get; set; }
        public short MinimalnaKolicinaNaSkladistu { get; set; }
        public decimal CijenaBezPdv { get; set; }
        public int? PotkategorijaId { get; set; }

        public virtual Potkategorija Potkategorija { get; set; }
        public virtual ICollection<Stavka> Stavkas { get; set; }
    }
}
