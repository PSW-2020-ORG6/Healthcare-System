using IntegrationAdapters.Models;
using IntegrationAdapters.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Services
{
    public class ApiService
    {
        private ApiRepository apiRepository;

        public ApiService()
        {
            this.apiRepository = new ApiRepository();
        }

        public bool RegisterHospitalOnPharmacy(Api api)
        {
            return apiRepository.RegisterHospitalOnPharmacy(api);
        }

        public List<Api> GetAllApis()
        {
            return apiRepository.GetAllApis();
        }

        public string getApiKey(Api api)
        {
            return apiRepository.getApiKey(api);
        }

        public Api getApiByKey(List<Api> apis, string key)
        {
            return apiRepository.getApiByKey(apis, key);
        }

        public bool IsPharmacyExistsOnHospital(Api api)
        {
            return apiRepository.IsPharmacyExistsOnHospital(api);
        }
    }
}
