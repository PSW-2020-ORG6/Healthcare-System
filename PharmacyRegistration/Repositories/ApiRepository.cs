﻿using PharmacyRegistration.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyRegistration.Repositories
{
    public class ApiRepository : IApiRepository
    {
        public DbContextOptions<IAHealthCareSystemDbContext> options = new DbContextOptionsBuilder<IAHealthCareSystemDbContext>()
                .UseNpgsql(connectionString: "server=localhost;port=5432;database=newmydb;User ID=postgres;password=super")
                .Options;
        public readonly IAHealthCareSystemDbContext dbContext;

        public ApiRepository()
        {
            this.dbContext = new IAHealthCareSystemDbContext(options);
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
