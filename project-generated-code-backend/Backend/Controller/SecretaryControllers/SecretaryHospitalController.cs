// File:    SecretaryHospitalController.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class SecretaryHospitalController

using Backend.Service.HospitalAccountsService;
using Backend.Service.HospitalResourcesService;
using health_clinic_class_diagram.Backend.Service.HospitalAccountsService;
using HealthClinic.Backend.Service.HospitalAccountsService;
using Model.Accounts;
using Model.Hospital;
using Model.Schedule;
using Model.Util;
using System.Collections.Generic;

namespace Backend.Controller.SecretaryControllers
{
    public class SecretaryHospitalController
    {
        public HospitalService hospitalService;
        public RoomService roomService;
        public PhysicianAccountService physicianService;
        public PatientAccountsService patientAccountsService;

        public SecretaryHospitalController()
        {
            hospitalService = new HospitalService();
            roomService = new RoomService();
            physicianService = new PhysicianAccountService();
            patientAccountsService = new PatientAccountsService();
        }

        public List<Patient> GetAllPatients()
        {
            return patientAccountsService.getAllPatients();
        }

        public List<Physitian> GetAllPhysitians()
        {
            return physicianService.GetAllPhysitians();
        }

        public List<Room> GetAllRooms()
        {
            return roomService.GetAll();
        }

        public List<Country> GetAllCountries()
        {
            return hospitalService.getAllCountries();
        }

        public List<ProcedureType> GetAllProcedureTypes()
        {
            return hospitalService.GetAllProcedureTypes();
        }
    }
}