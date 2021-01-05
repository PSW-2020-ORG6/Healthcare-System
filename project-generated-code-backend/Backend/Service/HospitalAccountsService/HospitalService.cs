// File:    HospitalService.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class HospitalService

using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.MedicalExam;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Service.HospitalAccountsService
{
    public class HospitalService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IProcedureTypeRepository _procedureTypeRepository;
        private readonly IDiagnosticTypeRepository _diagnosticTypeRepository;

        public HospitalService(ICountryRepository countryRepository, IProcedureTypeRepository procedureTypeRepository,
            IDiagnosticTypeRepository diagnosticTypeRepository)
        {
            _countryRepository = countryRepository;
            _procedureTypeRepository = procedureTypeRepository;
            _diagnosticTypeRepository = diagnosticTypeRepository;
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