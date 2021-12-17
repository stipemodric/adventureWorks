using AdventureWorks.Core.ViewModels.Grad;
using AdventureWorks.Models;
using System;
using System.Collections.Generic;
using System.Text;
using DrzavaEntity = AdventureWorks.Models.Drzava;

namespace AdventureWorks.Core.ViewModels.Drzava
{
    public class DrzavaAddViewModel
    {
        public string Naziv { get; set; }

        public DrzavaEntity ToEntity()
        {
            var entity = new DrzavaEntity();

            entity.Naziv = Naziv;

            return entity;
        }
    }
}
