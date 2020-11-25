using Backend.Service.HospitalAccountsService;
using Model.MedicalExam;
using Model.Schedule;
using System.Collections.Generic;

namespace health_clinic_class_diagram.Backend.Controller.PhysitianControllers
{
    public class PhysitianHospitalController
    {
        private HospitalService hospitalService;

        public PhysitianHospitalController()
        {
            this.hospitalService = new HospitalService();
        }

        public List<DiagnosticType> GetDiagnosticTypes()
        {
            return hospitalService.GetDiagnosticTypes();
        }

        public List<ProcedureType> GetProcedureTypes()
        {
            return hospitalService.GetProcedureTypes();
        }
    }
}
