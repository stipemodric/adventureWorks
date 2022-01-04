using AdventureWorks.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using KupacEntity = AdventureWorks.Models.Kupac;

namespace AdventureWorks.Core.ViewModels.Kupac
{
    public class KupacAddViewModel : IAddViewModel<KupacEntity>
    {
        public KupacEntity ToEntity()
        {
            throw new NotImplementedException();
        }
    }
}
