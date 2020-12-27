using IntegrationAdapters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Repositories
{
    interface ITenderRepository
    {
        public bool AddTender(Tender tender);
        public List<Tender> GetAllTenders();
    }
}
