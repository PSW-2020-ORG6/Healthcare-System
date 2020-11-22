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

        public ApiService(HealthCareSystemDbContext context)
        {
            this.apiRepository = new ApiRepository(context);
        }

        public bool RegisterHospitalOnPharmacy(Api api)
        {
            return apiRepository.RegisterHospitalOnPharmacy(api);
        }
    }
}
