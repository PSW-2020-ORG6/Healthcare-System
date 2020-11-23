using Backend.Dto;
//using Backend.Repository;
using Model.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Backend.Repositorys;

namespace WebApplication.Backend.Services
{
    public class RegistrationService
    {
        private RegistrationRepository registrationRepository;
        private IRegistrationRepository iregistrationRepository = new RegistrationRepository();
        public RegistrationService()
        {
            this.registrationRepository = new RegistrationRepository();
        }

        public RegistrationService(IRegistrationRepository iregistrationRepository)
        {
            this.iregistrationRepository = iregistrationRepository;
        }

        public bool RegisterPatient(Patient patientDTO)
        {
            /*if (!IsJMBGValid(patientDTO.Id) && IsGuest(patientDTO.Id))
            {
                Patient p = GetExistingPatient(patientDTO.Id);
                if (p == null)
                {
                    return;
                }
                else
                {
                    Patient newPatient = new Patient(patientDTO);
                    newPatient.SerialNumber = p.SerialNumber;
                    //patientRepository.Update(newPatient);
                }
            }*/
            if (IsJMBGValid(patientDTO.Id))
            {
                return iregistrationRepository.addPatient(patientDTO);
            }
            else
            {
                return false;
            }
        }

        public bool IsGuest(String jmbg)
        {
            /*List<Patient> patients = registrationRepository.GetAllPatients();
            foreach (Patient p in patients)
            {
                if (p.Id.Equals(jmbg))
                {
                    if (p.Guest)
                    {
                        return true;
                    }
                }
            }*/
            return false;
        }

        public bool IsJMBGValid(String jmbg)
        {
            String id = iregistrationRepository.GetPatientIdById(jmbg);

            //List<String> patients = iregistrationRepository.GetAllPatients();
            //foreach (String id in patients)
            //{
                if (id ==  "" || id == null)
                {
                    return true;
                }
            //} 
            return false;
        }

        public Patient GetExistingPatient(String jmbg)
        {
            /*List<Patient> patients = patientRepository.GetAllPatients();
            foreach (Patient p in patients)
            {
                if (p.Id.Equals(jmbg))
                {
                    return p;
                }
            }*/
            return null;
        }
    }
}
