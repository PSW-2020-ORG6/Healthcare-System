using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Accounts;

namespace WebApplication.Backend.Services
{
    public interface IRegistrationService
    {
        public bool RegisterPatient(Patient patient);

        public bool ConfirmEmailUpdate(string id);
        public List<FamilyDoctorDto> GetAllPhysicians();
    }
}