using AdventureWorks.Core.Contracts;
using AdventureWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.DataAccess.Repositories
{
    public abstract class AuxiliaryRepository<TAddViewModel, TEntity> 
        where TEntity : class, new()
        where TAddViewModel : IAddViewModel<TEntity>
    {
        protected AdventureWorksOBPContext _context;
        public AuxiliaryRepository(AdventureWorksOBPContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> Fetch()
        {
            try
            {
                return _context.Set<TEntity>();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public virtual async Task<int> Post(TAddViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new NullReferenceException("Model je null");
            }

            try
            {
                var entity = viewModel.ToEntity();

                _context.Set<TEntity>().Add(entity);

                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<int> Put(int entityId)
        {
            try
            {
                _context.Update(entityId);

                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<int> Delete(int entityId)
        {
            try
            {
                _context.Remove(entityId);

                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
