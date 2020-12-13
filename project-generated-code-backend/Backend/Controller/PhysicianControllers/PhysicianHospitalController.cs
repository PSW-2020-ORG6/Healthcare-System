﻿using HealthClinicBackend.Backend.Model.MedicalExam;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Service.HospitalAccountsService;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Controller.PhysicianControllers
{
    public class PhysicianHospitalController
    {
        private readonly HospitalService _hospitalService;

        public PhysicianHospitalController()
        {
            this._hospitalService = new HospitalService();
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
