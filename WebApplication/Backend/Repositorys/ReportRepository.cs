using Model.Accounts;
using Model.MedicalExam;
using Model.Schedule;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys
{
    public class ReportRepository : IReportRepository
    {
        private MySqlConnection connection;
        public ReportRepository()
        {
            try
            {
                connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
            }
            catch (Exception e)
            {
            }
        }

        ///Tanja Drcelic RA124/2017 and Marija Vucetic RA157/2017
        /// <summary>
        ///Get reports from table
        ///</summary>
        ///<param name="sqlDml"> data manipulation language
        ///</param>
        ///<returns>
        ///list of reports
        ///</returns>
        private List<Report> GetReports(String sqlDml)
        {
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<Report> resultList = new List<Report>();
            while (sqlReader.Read())
            {
                Report entity = new Report();
                entity.SerialNumber =
                entity.Findings = (string)sqlReader[1];
                entity.PatientConditions = (string)sqlReader[2];
                entity.Patient = new Patient { SerialNumber = (string)sqlReader[3] };
                entity.Physitian = new Physitian { SerialNumber = (string)sqlReader[4] };
                entity.ProcedureType = new ProcedureType { SerialNumber = (string)sqlReader[5] };
                entity.Date = (DateTime)sqlReader[6];
                resultList.Add(entity);
            }
            connection.Close();
            foreach (Report report in resultList)
            {
                PatientRepository patientRepository = new PatientRepository();
                report.Patient = patientRepository.GetPatientById(report.Patient.SerialNumber);
                PhysitianRepository phisitionRepository = new PhysitianRepository();
                report.Physitian = phisitionRepository.GetPhysitianById(report.Physitian.SerialNumber);
                report.ProcedureType = GetProcedureTypeById("Select * from proceduretypes where SerialNumber like '" + report.ProcedureType.SerialNumber + "'");
            }
            return resultList;
        }

        ///Tanja Drcelic RA124/2017
        /// <summary>
        ///Get procedure type by id from table
        ///</summary>
        ///<param name="sqlDml"> data manipulation language
        ///</param>
        ///<returns>
        ///Procedure type
        ///</returns>
        private ProcedureType GetProcedureTypeById(string sqlDml)
        {
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            sqlReader.Read();
            ProcedureType entity = new ProcedureType();
            entity.SerialNumber = (string)sqlReader[0];
            entity.Name = (string)sqlReader[1];
            entity.Specialization = new Specialization();
            entity.Specialization = new Specialization { SerialNumber = (string)sqlReader[2] };
            connection.Close();
            entity.Specialization = GetSpecialization("Select * from specializations where SerialNumber like '" + entity.Specialization.SerialNumber + "'");
            return entity;
        }
        ///Tanja Drcelic RA124/2017
        /// <summary>
        ///Get specialization by id from table
        ///</summary>
        ///<param name="sqlDml"> data manipulation language
        ///</param>
        ///<returns>
        ///Physitian
        ///</returns>
        private Specialization GetSpecialization(string sqlDml)
        {
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            sqlReader.Read();
            Specialization specialization = new Specialization();
            specialization.SerialNumber = (string)sqlReader[0];
            specialization.Name = (string)sqlReader[2];
            connection.Close();
            return specialization;
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
            List<Report> reports = GetReports("Select * from reports  where Date between " + dateTimes);
            if (!not && property.Equals(SearchProperty.All))
                return GetReportssByAllProperties(value, reports);
            else if (not && property.Equals(SearchProperty.All))
                return GetRepportsByAllPropertiesNegation(value, reports);
            else if (!not && property.Equals(SearchProperty.Patient))
                return GetPrescriptionsByPatient(value, reports);
            else if (not && property.Equals(SearchProperty.Patient))
                return GetPrescriptionsByPatientNegation(value, reports);
            else if (!not && property.Equals(SearchProperty.Doctor))
                return GetPrescriptionsByPhysition(value, reports);
            else if (not && property.Equals(SearchProperty.Doctor))
                return GetPrescriptionsByPhysitionNegation(value, reports);
            else if (!not && property.Equals(SearchProperty.Specialist))
                return GetPrescriptionsBySpecialization(value, reports);
            else if (not && property.Equals(SearchProperty.Specialist))
                return GetPrescriptionsBySpecializationNegation(value, reports);
            else if (!not && property.Equals(SearchProperty.ProcedureType))
                return GetPrescriptionsByProedureType(value, reports);
            else
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
                if (!report.Physitian.Name.ToUpper().Contains(value.ToUpper()) && !report.Physitian.Surname.ToUpper().Contains(value.ToUpper()))
                    resultList.Add(report);
            }
            return resultList;
        }

        private List<Report> GetPrescriptionsByPhysition(string value, List<Report> reports)
        {
            List<Report> resultList = new List<Report>();
            foreach (Report report in reports)
            {
                if (report.Physitian.Name.ToUpper().Contains(value.ToUpper()) || report.Physitian.Surname.ToUpper().Contains(value.ToUpper()))
                    resultList.Add(report);
            }
            return resultList;
        }

        private List<Report> GetPrescriptionsByPatientNegation(string value, List<Report> reports)
        {
            List<Report> resultList = new List<Report>();
            foreach (Report report in reports)
            {
                if (!report.Patient.Name.ToUpper().Contains(value.ToUpper()) && !report.Patient.Surname.ToUpper().Contains(value.ToUpper()))
                    resultList.Add(report);
            }
            return resultList;
        }

        private List<Report> GetPrescriptionsByPatient(string value, List<Report> reports)
        {
            List<Report> resultList = new List<Report>();
            foreach (Report report in reports)
            {
                if (report.Patient.Name.ToUpper().Contains(value.ToUpper()) || report.Patient.Surname.ToUpper().Contains(value.ToUpper()))
                    resultList.Add(report);
            }
            return resultList;
        }
        private List<Report> GetReportssByAllProperties(string value, List<Report> reports)
        {
            List<Report> resultList = new List<Report>();
            foreach (Report report in reports)
            {
                if (report.Physitian.Name.ToUpper().Contains(value.ToUpper()) || report.Physitian.Surname.ToUpper().Contains(value.ToUpper()) || report.Patient.Name.ToUpper().Contains(value.ToUpper()) || report.Patient.Name.ToUpper().Contains(value.ToUpper()) || report.ProcedureType.Name.ToUpper().Contains(value.ToUpper()) || report.ProcedureType.Specialization.Name.ToUpper().Contains(value.ToUpper()))
                    resultList.Add(report);
            }
            return resultList;
        }

        private List<Report> GetRepportsByAllPropertiesNegation(string value, List<Report> reports)
        {
            List<Report> resultList = new List<Report>();
            foreach (Report report in reports)
            {
                if (!report.Physitian.Name.ToUpper().Contains(value.ToUpper()) && !report.Physitian.Surname.ToUpper().Contains(value.ToUpper()) && !report.Patient.Name.ToUpper().Contains(value.ToUpper()) && !report.Patient.Name.ToUpper().Contains(value.ToUpper()) && !report.ProcedureType.Name.ToUpper().Contains(value.ToUpper()) && !report.ProcedureType.Specialization.Name.ToUpper().Contains(value.ToUpper()))
                    resultList.Add(report);
            }
            return resultList;
        }
    }
}
