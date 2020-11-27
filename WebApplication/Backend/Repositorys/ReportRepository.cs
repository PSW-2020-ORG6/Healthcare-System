using Model.Accounts;
using Model.MedicalExam;
using Model.Schedule;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Backend.Repositorys
{
    public class ReportRepository: IReportRepository
    {
        private MySqlConnection connection;
        public ReportRepository()
        {
            try
            {
                connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=Tanjaa;password=TanjaaD");
                connection.Open();
            }
            catch (Exception e)
            {
            }
        }

        public List<Report> GetReports(String sqlDml)
        {
            connection.Close();
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
                entity.Patient=new Patient { SerialNumber = (string)sqlReader[3] };
                entity.Physitian=new Physitian { SerialNumber = (string)sqlReader[4] };
                entity.ProcedureType=new ProcedureType { SerialNumber = (string)sqlReader[5]};
                entity.Date=(DateTime)sqlReader[6];
                resultList.Add(entity);
            }
            connection.Close();
            foreach (Report report in resultList)
            {
                PatientRepository patientRepository = new PatientRepository(connection);
                report.Patient = patientRepository.GetPatientById("Select * from patients where SerialNumber like '" + report.Patient.SerialNumber + "'");

                PhysitianRepository phisitionRepository = new PhysitianRepository(connection);
                report.Physitian = phisitionRepository.GetPhysitianById("Select * from accounts where SerialNumber like '" + report.Physitian.SerialNumber + "'");

                report.ProcedureType=GetProcedureTypeById("Select * from proceduretypes where SerialNumber like '" + report.ProcedureType.SerialNumber + "'");

            }
            return resultList;
        }

        public ProcedureType GetProcedureTypeById(string sqlDml)
        {
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            sqlReader.Read();
            ProcedureType entity = new ProcedureType();
            entity.SerialNumber = (string)sqlReader[0];
            entity.Name = (string)sqlReader[1];
            entity.Specialization = new Specialization();
            entity.Specialization= new Specialization { SerialNumber = (string)sqlReader[2] };
            connection.Close();
            entity.Specialization = GetSpecialization("Select * from specializations where SerialNumber like '" + entity.Specialization.SerialNumber + "'");
            return entity;
        }

        public Specialization GetSpecialization(string sqlDml)
        {
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            sqlReader.Read();
            Specialization specialization = new Specialization();
            specialization.SerialNumber= (string)sqlReader[0];
            specialization.Name= (string)sqlReader[2];
            connection.Close();

            return specialization;
        }

        public List<Report> GetReportsByProperty(string property, string value, string dateTimes, bool not)
        {
            List<Report> reports = GetReports("Select * from reports  where Date between " + dateTimes);
            if (not)
                return Negation(property, value, reports);
            return Regular(property, value, reports);
        }

        private List<Report> Negation(string property, string value, List<Report> reports)
        {
            List<Report> resultList = new List<Report>();
            foreach (Report report in reports)
            {
                if (property.Equals("All"))
                {
                    if (!report.Physitian.Name.ToUpper().Contains(value.ToUpper()) && !report.Physitian.Surname.ToUpper().Contains(value.ToUpper()) && !report.Patient.Name.ToUpper().Contains(value.ToUpper()) && !report.Patient.Name.ToUpper().Contains(value.ToUpper()) && !report.ProcedureType.Name.ToUpper().Contains(value.ToUpper()) && !report.ProcedureType.Specialization.Name.ToUpper().Contains(value.ToUpper()))
                        resultList.Add(report);
                }
                else if (property.Equals("Patient reports"))
                {
                    if (!report.Patient.Name.ToUpper().Contains(value.ToUpper()) && !report.Patient.Surname.ToUpper().Contains(value.ToUpper()))
                        resultList.Add(report);
                }
                else if (property.Equals("Doctor reports"))
                {
                    if (!report.Physitian.Name.ToUpper().Contains(value.ToUpper()) && !report.Physitian.Surname.ToUpper().Contains(value.ToUpper()))
                        resultList.Add(report);
                }
                else if (property.Equals("Specialist reports"))
                {
                    if (!report.ProcedureType.Specialization.Name.ToUpper().Contains(value.ToUpper()))
                        resultList.Add(report);
                }
                else if (!report.ProcedureType.Name.ToUpper().Contains(value.ToUpper()))
                    resultList.Add(report);
            }
            return resultList;
        }
        private List<Report> Regular(string property, string value, List<Report> reports)
        {
            List<Report> resultList = new List<Report>();
            foreach (Report report in reports)
            {
                if (property.Equals("All"))
                {
                    if (report.Physitian.Name.ToUpper().Contains(value.ToUpper()) || report.Physitian.Surname.ToUpper().Contains(value.ToUpper()) || report.Patient.Name.ToUpper().Contains(value.ToUpper()) || report.Patient.Name.ToUpper().Contains(value.ToUpper()) || report.ProcedureType.Name.ToUpper().Contains(value.ToUpper()) || report.ProcedureType.Specialization.Name.ToUpper().Contains(value.ToUpper()))
                        resultList.Add(report);
                }
                else if (property.Equals("Patient reports"))
                {
                    if (report.Patient.Name.ToUpper().Contains(value.ToUpper()) || report.Patient.Surname.ToUpper().Contains(value.ToUpper()))
                        resultList.Add(report);
                }
                else if (property.Equals("Doctor reports"))
                {
                    if (report.Physitian.Name.ToUpper().Contains(value.ToUpper()) || report.Physitian.Surname.ToUpper().Contains(value.ToUpper()))
                        resultList.Add(report);
                }
                else if (property.Equals("Specialist reports"))
                {
                    if (report.ProcedureType.Specialization.Name.ToUpper().Contains(value.ToUpper()))
                        resultList.Add(report);
                }
                else if (report.ProcedureType.Name.ToUpper().Contains(value.ToUpper()))
                    resultList.Add(report);
            }
            return resultList;
        }
    }
}
