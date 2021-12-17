using AdventureWorks.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorks.DataAccess.Repositories
{
    public class GradRepository : AuxiliaryRepository<Grad>
    {
        public GradRepository(AdventureWorksOBPContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<Grad>> GetGradoviByDrzava(int? drzavaId)
        {
            try 
            {
                if (drzavaId != null)
                {
                    return await Fetch().Where(x => x.DrzavaId == drzavaId).ToListAsync();
                } 
                else
                {
                    return await Fetch().ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
