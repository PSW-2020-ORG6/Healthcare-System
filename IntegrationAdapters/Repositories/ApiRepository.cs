using IntegrationAdapters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Repositories
{
    public class ApiRepository
    {
        public readonly MyDbContext dbContext;

        public ApiRepository(MyDbContext context)
        {
            this.dbContext = context;
        }

        public bool RegisterHospitalOnPharmacy(Api api)
        {
            if (!IsPharmacyExistsOnHospital(api))
            {
                dbContext.Add<Api>(api);
                dbContext.SaveChanges();
                return true;
            } else
            {
                return false;
            }
        }

        public bool IsPharmacyExistsOnHospital(Api api)
        {
            List<Api> apis = dbContext.Apis.ToList();
            foreach (Api a in apis) {
                if (a.Key.Equals(api.Key)) return true;
            }
            return false;
        }
    }
}
