using IntegrationAdapters.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Repositories
{
    public class ApiRepository : IApiRepository
    {
        public DbContextOptions<HealthCareSystemDbContext> options = new DbContextOptionsBuilder<HealthCareSystemDbContext>()
                .UseMySql(connectionString: "server=localhost;port=3306;database=newmydb;user=root;password=root")
                .Options;
        public readonly HealthCareSystemDbContext dbContext;

        public ApiRepository()
        {
            this.dbContext = new HealthCareSystemDbContext(options);
        }

        public bool RegisterHospitalOnPharmacy(Api api)
        {
            if (!IsPharmacyExistsOnHospital(api))
            {
                dbContext.Add<Api>(api);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsPharmacyExistsOnHospital(Api api)
        {
            List<Api> apis = dbContext.Apis.ToList();
            foreach (Api a in apis)
            {
                if (a.Key.Equals(api.Key)) return true;
            }
            return false;
        }
        public List<Api> GetAllApis()
        {
            return dbContext.Apis.ToList();
        }
        public string getApiKey(Api api)
        {
            return api.Key;
        }
        public Api getApiByKey(List<Api> apis, string key)
        {
            foreach (Api a in apis)
            {
                if (a.Key.Equals(key)) return a;
            }
            return null;
        }
    }
}
