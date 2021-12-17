﻿using System;
using System.Collections.Generic;

#nullable disable

namespace AdventureWorks.Models
{
    public partial class Drzava
    {
        public Drzava()
        {
            Grads = new HashSet<Grad>();
        }

        public int Iddrzava { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Grad> Grads { get; set; }
    }
}
