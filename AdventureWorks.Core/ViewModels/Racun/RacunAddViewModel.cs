using AdventureWorks.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using RacunEntity = AdventureWorks.Models.Racun;

namespace AdventureWorks.Core.ViewModels.Racun
{
    public class RacunAddViewModel : IAddViewModel<RacunEntity>
    {
        public RacunEntity ToEntity()
        {
            throw new NotImplementedException();
        }
    }
}
