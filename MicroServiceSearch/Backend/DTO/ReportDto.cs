using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServiceSearch.Backend.Dto
{
    public class ReportDto
    {
        public string ProcedureType { get; set; }
        public string Patient { get; set; }
        public string Physician { get; set; }
        public string Specialization { get; set; }
        public string Date { get; set; }

        public ReportDto(DateTime date,string patient,string physician)
        {
            Date = date.ToString("dddd, MMMM dd yyyy");
            Patient = patient;
            Physician = physician;
        }

        public bool EqualsReport(ReportDto rsecond)
        {
            return rsecond.Patient.Equals(Patient) && rsecond.Physician.Equals(Physician) 
                && rsecond.Specialization.Equals(Specialization) && rsecond.Date.Equals(Date)
                && rsecond.ProcedureType.Equals(ProcedureType);
        }

        public bool NotInResult(List<ReportDto> reports)
        {
                foreach (ReportDto r in reports)
                    if (EqualsReport(r))
                        return false;
                return true;
        }

        public bool ProcedureTypeContains(string procedureType)
        {
            return ProcedureType.ToUpper().Contains(procedureType.ToUpper());
        }

        public bool PhysicianContains(string physician)
        {
            return Physician.ToUpper().Contains(physician.ToUpper());
        }

        public bool PatientContains(string patient)
        {
            return Patient.ToUpper().Contains(patient.ToUpper());
        }

        public bool SpecializationContains(string specialization)
        {
            return Specialization.ToUpper().Contains(specialization.ToUpper());
        }

        public bool AllContains(string value)
        {
            return ProcedureTypeContains(value) || PhysicianContains(value) ||
                    PatientContains(value) || SpecializationContains(value);
        }
    }
}
