using AdventureWorks.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks.DataAccess.Repositories
{
    public class DrzavaRepository
    {
        private AdventureWorksOBPContext _context;
        public DrzavaRepository(AdventureWorksOBPContext context)
        {
            _context = context;
        }
    }
}
