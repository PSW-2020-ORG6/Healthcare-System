using System;
using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.MedicalExam;
using HealthClinicBackend.Backend.Repository.DatabaseSql;

namespace WebApplication.Backend.Repositorys
{
    public class ReportRepository : IReportRepository
    {
        private readonly ReportDatabaseSql _reportRepository;

        public ReportRepository()
        {
            _reportRepository = new ReportDatabaseSql();
        }

        ///Tanja Drcelic RA124/2017
        /// <summary>
        ///Create sqlDml for get reports
        ///</summary>
        ///<param name="property"> search by property
        ///<param name="value"> search value
        ///<param name="dateTimes"> search by date times
        ///<param name="not"> search for negation
        ///</param>
        ///<returns>
        ///list of reports
        ///</returns>
        public List<Report> GetReportsByProperty(SearchProperty property, string value, string dateTimes, bool not)
        {
            // TODO: parse dates
            DateTime start = DateTime.MinValue;
            DateTime end = DateTime.MaxValue;

            List<Report> reports = _reportRepository.GetAll()
                .Where(r => r.Date <= end)
                .Where(r => r.Date >= start)
                .ToList();

            if (!not && property.Equals(SearchProperty.All))
                return GetReportssByAllProperties(value, reports);
            if (not && property.Equals(SearchProperty.All))
                return GetRepportsByAllPropertiesNegation(value, reports);
            if (!not && property.Equals(SearchProperty.Patient))
                return GetPrescriptionsByPatient(value, reports);
            if (not && property.Equals(SearchProperty.Patient))
                return GetPrescriptionsByPatientNegation(value, reports);
            if (!not && property.Equals(SearchProperty.Doctor))
                return GetPrescriptionsByPhysition(value, reports);
            if (not && property.Equals(SearchProperty.Doctor))
                return GetPrescriptionsByPhysitionNegation(value, reports);
            if (!not && property.Equals(SearchProperty.Specialist))
                return GetPrescriptionsBySpecialization(value, reports);
            if (not && property.Equals(SearchProperty.Specialist))
                return GetPrescriptionsBySpecializationNegation(value, reports);
            if (!not && property.Equals(SearchProperty.ProcedureType))
                return GetPrescriptionsByProedureType(value, reports);
            return GetPrescriptionsByProedureTypeNegation(value, reports);
        }

        private List<Report> GetPrescriptionsBySpecializationNegation(string value, List<Report> reports)
        {
            List<Report> resultList = new List<Report>();
            foreach (Report report in reports)
            {
                if (!report.ProcedureType.Specialization.Name.ToUpper().Contains(value.ToUpper()))
                    resultList.Add(report);
            }

            return resultList;
        }

        private List<Report> GetPrescriptionsByProedureTypeNegation(string value, List<Report> reports)
        {
            List<Report> resultList = new List<Report>();
            foreach (Report report in reports)
            {
                if (!report.ProcedureType.Name.ToUpper().Contains(value.ToUpper()))
                    resultList.Add(report);
            }

            return resultList;
        }

        private List<Report> GetPrescriptionsByProedureType(string value, List<Report> reports)
        {
            List<Report> resultList = new List<Report>();
            foreach (Report report in reports)
            {
                if (report.ProcedureType.Name.ToUpper().Contains(value.ToUpper()))
                    resultList.Add(report);
            }

            return resultList;
        }

        private List<Report> GetPrescriptionsBySpecialization(string value, List<Report> reports)
        {
            List<Report> resultList = new List<Report>();
            foreach (Report report in reports)
            {
                if (report.ProcedureType.Specialization.Name.ToUpper().Contains(value.ToUpper()))
                    resultList.Add(report);
            }

            return resultList;
        }

        private List<Report> GetPrescriptionsByPhysitionNegation(string value, List<Report> reports)
        {
            List<Report> resultList = new List<Report>();
            foreach (Report report in reports)
            {
                if (!report.Physician.Name.ToUpper().Contains(value.ToUpper()) &&
                    !report.Physician.Surname.ToUpper().Contains(value.ToUpper()))
                    resultList.Add(report);
            }

            return resultList;
        }

        private List<Report> GetPrescriptionsByPhysition(string value, List<Report> reports)
        {
            List<Report> resultList = new List<Report>();
            foreach (Report report in reports)
            {
                if (report.Physician.Name.ToUpper().Contains(value.ToUpper()) ||
                    report.Physician.Surname.ToUpper().Contains(value.ToUpper()))
                    resultList.Add(report);
            }

            return resultList;
        }

        private List<Report> GetPrescriptionsByPatientNegation(string value, List<Report> reports)
        {
            List<Report> resultList = new List<Report>();
            foreach (Report report in reports)
            {
                if (!report.Patient.Name.ToUpper().Contains(value.ToUpper()) &&
                    !report.Patient.Surname.ToUpper().Contains(value.ToUpper()))
                    resultList.Add(report);
            }

            return resultList;
        }

        private List<Report> GetPrescriptionsByPatient(string value, List<Report> reports)
        {
            List<Report> resultList = new List<Report>();
            foreach (Report report in reports)
            {
                if (report.Patient.Name.ToUpper().Contains(value.ToUpper()) ||
                    report.Patient.Surname.ToUpper().Contains(value.ToUpper()))
                    resultList.Add(report);
            }

            return resultList;
        }

        private List<Report> GetReportssByAllProperties(string value, List<Report> reports)
        {
            List<Report> resultList = new List<Report>();
            foreach (Report report in reports)
            {
                if (report.Physician.Name.ToUpper().Contains(value.ToUpper()) ||
                    report.Physician.Surname.ToUpper().Contains(value.ToUpper()) ||
                    report.Patient.Name.ToUpper().Contains(value.ToUpper()) ||
                    report.Patient.Name.ToUpper().Contains(value.ToUpper()) ||
                    report.ProcedureType.Name.ToUpper().Contains(value.ToUpper()) || report.ProcedureType.Specialization
                        .Name.ToUpper().Contains(value.ToUpper()))
                    resultList.Add(report);
            }

            return resultList;
        }

        private List<Report> GetRepportsByAllPropertiesNegation(string value, List<Report> reports)
        {
            List<Report> resultList = new List<Report>();
            foreach (Report report in reports)
            {
                if (!report.Physician.Name.ToUpper().Contains(value.ToUpper()) &&
                    !report.Physician.Surname.ToUpper().Contains(value.ToUpper()) &&
                    !report.Patient.Name.ToUpper().Contains(value.ToUpper()) &&
                    !report.Patient.Name.ToUpper().Contains(value.ToUpper()) &&
                    !report.ProcedureType.Name.ToUpper().Contains(value.ToUpper()) && !report.ProcedureType
                        .Specialization.Name.ToUpper().Contains(value.ToUpper()))
                    resultList.Add(report);
            }

            return resultList;
        }
    }
}