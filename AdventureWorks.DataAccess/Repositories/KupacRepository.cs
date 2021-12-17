using AdventureWorks.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.DataAccess.Repositories
{
    public class KupacRepository : AuxiliaryRepository<Kupac>
    {
        public KupacRepository(AdventureWorksOBPContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<Kupac>> GetKupacsByGrad(int gradId)
        {
            try
            {
                return await Fetch().Where(x => x.GradId == gradId).ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
