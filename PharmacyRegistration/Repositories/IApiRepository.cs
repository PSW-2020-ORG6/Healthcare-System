using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyRegistration.Models;

namespace PharmacyRegistration.Repositories
{
    public interface IApiRepository
    {
        public bool RegisterHospitalOnPharmacy(Api api);
        public List<Api> GetAllApis();
        public string getApiKey(Api api);
        public Api getApiByKey(List<Api> apis, string key);
    }
}
