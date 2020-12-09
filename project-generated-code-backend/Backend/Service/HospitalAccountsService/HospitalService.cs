// File:    HospitalService.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class HospitalService

using System.Collections.Generic;
using Backend.Repository;
using HCI_SIMS_PROJEKAT.Backend.Repository;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using Model.MedicalExam;
using Model.Schedule;
using Model.Util;

namespace HealthClinicBackend.Backend.Service.HospitalAccountsService
{
    //TODO: REFAKTORISATI samo geteri za country, procedure type, room type... (stvari koje idu u CB)
    // Dodati PhysitianAccountsService i SecretaryAccountsService 
    public class HospitalService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IProcedureTypeRepository _procedureTypeRepository;
        private readonly IDiagnosticTypeRepository _diagnosticTypeRepository;

        public HospitalService()
        {
            _countryRepository = new CountryDatabaseSql();
            _procedureTypeRepository = new ProcedureTypeDatabaseSql();
            _diagnosticTypeRepository = new DiagnosticTypeDatabaseSql();
        }

        internal List<ProcedureType> GetAllProcedureTypes()
        {
            return _procedureTypeRepository.GetAll();
        }

        internal List<Country> GetAllCountries()
        {
            return _countryRepository.GetAll();
        }

        public List<ProcedureType> GetProcedureTypes()
        {
            return _procedureTypeRepository.GetAll();
        }

        public List<DiagnosticType> GetDiagnosticTypes()
        {
            return _diagnosticTypeRepository.GetAll();
        }
    }
}