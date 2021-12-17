using AdventureWorks.Models;
using System;
using System.Collections.Generic;
using System.Text;
using GradEntity = AdventureWorks.Models.Grad;

namespace AdventureWorks.Core.ViewModels.Grad
{
    public class GradAddViewModel
    {
        public string Naziv { get; set; }
        public int DrzavaId { get; set; }
        public GradEntity ToEntity()
        {
            return new GradEntity
            {
                Naziv = Naziv,
                DrzavaId = DrzavaId
            };
        }
    }
}
