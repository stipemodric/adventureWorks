using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks.Core.Contracts
{
    public interface IAddViewModel<TEntity> where TEntity : class, new()
    {
        TEntity ToEntity();
    }
}
