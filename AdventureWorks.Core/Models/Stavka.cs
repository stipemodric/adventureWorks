using System;
using System.Collections.Generic;

#nullable disable

namespace AdventureWorks.Models
{
    public partial class Stavka
    {
        public int Idstavka { get; set; }
        public int RacunId { get; set; }
        public short Kolicina { get; set; }
        public int ProizvodId { get; set; }
        public decimal CijenaPoKomadu { get; set; }
        public decimal PopustUpostocima { get; set; }
        public decimal UkupnaCijena { get; set; }

        public virtual Proizvod Proizvod { get; set; }
        public virtual Racun Racun { get; set; }
    }
}
