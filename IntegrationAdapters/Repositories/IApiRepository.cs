using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinicBackend.Backend.Model.PharmacySupport;
using HealthClinicBackend.Backend.Repository.Generic;
using IntegrationAdapters.Models;

namespace IntegrationAdapters.Repositories
{
    public interface IApiRepository: IGenericRepository<Api>
    {
        public bool RegisterHospitalOnPharmacy(Api api);
        public List<Api> GetAllApis();
        public string getApiKey(Api api);
        public Api getApiByKey(List<Api> apis, string key);
    }
}
