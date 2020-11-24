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
    public class ReportRepository
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
        internal List<Report> GetAll()
        {
            return GetReports("Select * from reports");
        }

        internal List<Report> GetReports(String sqlDml)
        {
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<Report> resultList = new List<Report>();
            while (sqlReader.Read())
            {
                Report entity = new Report();
                entity.SerialNumber = (string)sqlReader[0];
                entity.Findings = (string)sqlReader[1];
                entity.PatientConditions = (string)sqlReader[2];
                entity.Patient = new Patient();
                entity.Patient.SerialNumber=(string)sqlReader[3];
                entity.Physitian = new Physitian();
                entity.Physitian.SerialNumber = (string)sqlReader[4];
                entity.ProcedureType = new ProcedureType();
                entity.ProcedureType.SerialNumber = (string)sqlReader[5];
                resultList.Add(entity);
            }
            connection.Close();
            foreach (Report report in resultList)
            {
                PatientRepository patientRepository = new PatientRepository();
                report.Patient = patientRepository.GetPatientById("Select * from patients where SerialNumber like '" + report.Patient.SerialNumber + "'");

                PhysitianRepository phisitionRepository = new PhysitianRepository();
                report.Physitian = phisitionRepository.GetPhysitianById("Select * from physitians where SerialNumber like '" + report.Physitian.SerialNumber + "'");

                report.ProcedureType =GetProcedureTypeById("Select * from proceduretypes where SerialNumber like '" + report.ProcedureType.SerialNumber + "'");

            }
            return resultList;
        }

        private ProcedureType GetProcedureTypeById(string sqlDml)
        {
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            ProcedureType procedure = new ProcedureType();
            sqlReader.Read();
            ProcedureType entity = new ProcedureType();
            entity.Name = (string)sqlReader[1];
            entity.Specialization = new Specialization();
            entity.Specialization.SerialNumber= GetSpecialization("Select Name from specializations where SerialNumber like '"+(string)sqlReader[2]+"'");
            connection.Close();
    
            return procedure;
        }

        private string GetSpecialization(string sqlDml)
        {
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            string procedure="";
            sqlReader.Read();
            procedure = (string)sqlReader[0];
            connection.Close();

            return procedure;
        }

        internal List<Report> GetReportsByProperty(string property, string value, bool not)
        {
            List<Report> reports = GetReports("Select * from reports");
            List<Report> resultList = new List<Report>();
            foreach (Report report in reports)
            {
                if (property.Equals("All")) {
                    if (!not)
                    {
                        if (report.Physitian.Name.Equals(value) || report.Physitian.Surname.Equals(value) || report.Patient.Name.Equals(value) || report.Patient.Name.Equals(value))
                            resultList.Add(report);
                    }
                    else
                    {
                        if (!report.Physitian.Name.Equals(value) || !report.Physitian.Surname.Equals(value) || !report.Patient.Name.Equals(value) || !report.Patient.Name.Equals(value))
                            resultList.Add(report);

                    }
                }
                else if (property.Equals("Patient reports"))
                {
                    if (!not && report.Patient.Name.Equals(value) || report.Patient.Name.Equals(value))
                        resultList.Add(report);
                    else if (not && !report.Patient.Name.Equals(value) || !report.Patient.Name.Equals(value))
                        resultList.Add(report);
                }
                else if(property.Equals("Doctor reports"))
                {
                    if (!not && report.Patient.Name.Equals(value) || report.Patient.Name.Equals(value))
                        resultList.Add(report);
                    else if (not && !report.Patient.Name.Equals(value) || !report.Patient.Name.Equals(value))
                        resultList.Add(report);
                }
                else if(property.Equals("Specialization reports"))
                {
                    if (!not && report.ProcedureType.Specialization.Equals(value) || report.ProcedureType.Specialization.Equals(value))
                        resultList.Add(report);
                    else if (not && !report.ProcedureType.Specialization.Equals(value) || !report.ProcedureType.Specialization.Equals(value))
                        resultList.Add(report);
                }
                else
                {
                    if (!not && report.ProcedureType.Name.Equals(value) || report.ProcedureType.Name.Equals(value))
                        resultList.Add(report);
                    else if (not && !report.ProcedureType.Name.Equals(value) || !report.ProcedureType.Name.Equals(value))
                        resultList.Add(report);
                }
            }
            return resultList;
        }

        private List<Report> GetReport(string v)
        {
            throw new NotImplementedException();
        }
    }
}
