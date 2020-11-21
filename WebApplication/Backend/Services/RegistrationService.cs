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
        public RegistrationService()
        {
            this.registrationRepository = new RegistrationRepository();
        }

        public void RegisterPatient(Patient patientDTO)
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
            }
            else if (IsJMBGValid(patientDTO.Id))
            {
                //patientRepository.Save(new Patient(patientDTO));
            }
            else
            {
                return;
            }*/
            registrationRepository.addPatient(patientDTO);
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

        private bool IsJMBGValid(String jmbg)
        {
            /*List<Patient> patients = patientRepository.GetAllPatients();
            foreach (Patient p in patients)
            {
                if (p.Id == jmbg)
                {
                    return false;
                }
            }*/
            return true;
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
