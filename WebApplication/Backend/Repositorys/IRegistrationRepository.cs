using Backend.Dto;
using Model.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Backend.Repositorys
{
    public interface IRegistrationRepository
    {
        public bool addPatient(Patient patient);
        public List<String> GetAllPatients();
        public String GetPatientId(string idd);
        public String GetPatientIdById(string patientId);
    }
}
