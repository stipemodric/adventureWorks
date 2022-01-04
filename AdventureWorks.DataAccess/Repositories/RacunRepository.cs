using AdventureWorks.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Core.ViewModels.Racun;

namespace AdventureWorks.DataAccess.Repositories
{
    public class RacunRepository : AuxiliaryRepository<RacunAddViewModel, Racun>
    {
        public RacunRepository(AdventureWorksOBPContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<Racun>> GetRacunDetailsByKupac(int kupacId, int? sortId)
        {
            try
            {
                var result = Fetch().Include(x => x.KreditnaKartica).Where(x => x.KupacId == kupacId);

                switch (sortId)
                {
                    case 1:
                        result = result.OrderBy(x => x.DatumIzdavanja);
                        break;
                    case 2:
                        result = result.OrderBy(x => x.KomercijalistId);
                        break;
                    case 3:
                        result = result.OrderBy(x => x.KreditnaKartica.Tip);
                        break;
                }

                return await result.ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
