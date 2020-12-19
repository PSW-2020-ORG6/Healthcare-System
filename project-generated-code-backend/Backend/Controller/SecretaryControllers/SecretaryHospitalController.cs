// File:    SecretaryHospitalController.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class SecretaryHospitalController

using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Service.HospitalAccountsService;
using HealthClinicBackend.Backend.Service.HospitalResourcesService;
using Model.Accounts;

namespace HealthClinicBackend.Backend.Controller.SecretaryControllers
{
    public class SecretaryHospitalController
    {
        private readonly HospitalService _hospitalService;
        private readonly RoomService _roomService;
        private readonly PhysicianAccountService _physicianService;
        private readonly PatientAccountsService _patientAccountsService;

        public SecretaryHospitalController(PhysicianAccountService physicianAccountService)
        {
            _hospitalService = new HospitalService();
            _roomService = new RoomService();
            _physicianService = physicianAccountService;
            _patientAccountsService = new PatientAccountsService();
        }

        public List<Patient> GetAllPatients()
        {
            return _patientAccountsService.getAllPatients();
        }

        public List<Physician> GetAllPhysicians()
        {
            return _physicianService.GetAllPhysitians();
        }

        public List<Room> GetAllRooms()
        {
            return _roomService.GetAll();
        }

        public List<Country> GetAllCountries()
        {
            return _hospitalService.GetAllCountries();
        }

        public List<ProcedureType> GetAllProcedureTypes()
        {
            return _hospitalService.GetAllProcedureTypes();
        }
    }
}