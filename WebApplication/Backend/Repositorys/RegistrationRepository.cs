using Backend.Dto;
using Model.Accounts;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Backend.Repositorys
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private MySqlConnection connection;
        public RegistrationRepository()
        {
            try
            {
                connection = new MySqlConnection("server=localhost;port=3306;database=mydb4;user=root;password=root");
                connection.Open();
            }
            catch (Exception e)
            {
            }
        }

        public bool addPatient(Patient patient)
        {
            connection = new MySqlConnection("server=localhost;port=3306;database=mydb4;user=root;password=root");
            connection.Open();
            string[] dateString = patient.DateOfBirth.ToString().Split(" ");
            string[] partsOfDate = dateString[0].Split("/");
           //string partsOfDate = patient.DateOfBirth.ToString();
            /*string sqlDml = "INSERT INTO patients (text,approved,date,patientid,serialnumber)  VALUES('" + feedback.Text + "','" + 0 + "','" + partsOfDate[2] + "-" + partsOfDate[1] + "-" + partsOfDate[0] + "T" + dateString[1]
                        + "','" + feedback.PatientId + " ','" + feedback.SerialNumber + "')";*/
            string sqlDml = "INSERT INTO patients (SerialNumber, name,surname, parentName, id, dateOfBirth, placeOfBirth, municipalityOfBirth, stateOfBirth, nationality, citizenship, address, placeOfResidence, municipalityOfResidence, stateOfResidence, profession, employmentStatus, maritalStatus, contact,email, password, gender, healthInsuranceNumber, familyDiseases, personalDiseases,image, guest)  VALUES('" + patient.SerialNumber + "','" + patient.Name + "','" + patient.Surname + "','" + patient.ParentName + "','" + patient.Id + "','" + partsOfDate[2] + "-" + partsOfDate[0] + "-" + partsOfDate[1] + "T" + dateString[1]
                       + "','" + patient.PlaceOfBirth
                       + "','" + patient.MunicipalityOfBirth + " ','" + patient.StateOfBirth + " ','" + patient.Nationality + " ','" + patient.Citizenship + " ','" + patient.Address + " ','" + 
                       patient.PlaceOfResidence + " ','" + patient.MunicipalityOfResidence + " ','" + patient.StateOfResidence + " ','" + patient.Profession + " ','" + patient.EmploymentStatus + " ','" + patient.MaritalStatus + " ','" + patient.Contact + " ','"
                       + patient.Email + " ','" + patient.Password + " ','" + patient.Gender + " ','" + patient.HealthInsuranceNumber + " ','" + patient.FamilyDiseases + " ','" + patient.PersonalDiseases + " ','" + patient.Image + " ','" + 1 + "')";

            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            sqlCommand.ExecuteNonQuery();
            connection.Close();

            return true;
        }

        internal List<string> GetPatients(String sqlDml)
        {
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            //List<Patient> resultList = new List<Patient>();
            List<string> resultList = new List<string>();
            while (sqlReader.Read())
            {
                //Patient entity = new Patient();
                string id = (string)sqlReader[0]; 
                //entity.Id = (string)sqlReader[0];
                //entity.Name = (string)sqlReader[2];
                //entity.Surname = (string)sqlReader[3];
                //entity.ParentName = (string)sqlReader[7];
                //entity.SerialNumber = (string)sqlReader[0];
                //entity.DateOfBirth = (DateTime)sqlReader[4];
                //entity.Contact = (string)sqlReader[5];
                //entity.Email = (string)sqlReader[6];
                //entity.Gender = (string)sqlReader[8];
                //entity.Guest = (Boolean)sqlReader[9];
                //entity.Password = (string)sqlReader[10];
                //resultList.Add(entity);
                resultList.Add(id);

            }
            connection.Close();
            return resultList;
        }

        public String GetPatientId(string sqlDml)
        {
            //string sqlDml = "Select id from patients where id=" + patientId;

            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            string id = "";
            while (sqlReader.Read())
            {
                id = (string)sqlReader[0];

            }
            connection.Close();
            return id;
        }

        public String GetPatientIdById(string patientId)
        {
            return GetPatientId("Select id from patients where id=" + patientId);
        }

        ///Tanja Drcelic RA124/2017 and Aleksandra Milijevic RA 22/2017
        /// <summary>
        ///Get patients from patients table
        ///</summary>
        ///<returns>
        ///list of all patients
        ///</returns>
        public List<String> GetAllPatients()
        {
            return GetPatients("Select id from patients");
        }

    }
}
