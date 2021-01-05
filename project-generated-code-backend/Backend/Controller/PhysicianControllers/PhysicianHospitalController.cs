using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.MedicalExam;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Service.HospitalAccountsService;

namespace HealthClinicBackend.Backend.Controller.PhysicianControllers
{
    public class PhysicianHospitalController
    {
        private readonly HospitalService _hospitalService;

        public PhysicianHospitalController(HospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        public List<DiagnosticType> GetDiagnosticTypes()
        {
            return _hospitalService.GetDiagnosticTypes();
        }

        public List<ProcedureType> GetProcedureTypes()
        {
            return _hospitalService.GetProcedureTypes();
        }
    }
}