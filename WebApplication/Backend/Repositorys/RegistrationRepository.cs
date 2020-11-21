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
                connection = new MySqlConnection("server=localhost;port=3306;database=mydb3;user=root;password=root");
                connection.Open();
            }
            catch (Exception e)
            {
            }
        }

        public bool addPatient(Patient patient)
        {
            string[] dateString = patient.DateOfBirth.ToString().Split(" ");
            string[] partsOfDate = dateString[0].Split("/");
           //string partsOfDate = patient.DateOfBirth.ToString();
            /*string sqlDml = "INSERT INTO patients (text,approved,date,patientid,serialnumber)  VALUES('" + feedback.Text + "','" + 0 + "','" + partsOfDate[2] + "-" + partsOfDate[1] + "-" + partsOfDate[0] + "T" + dateString[1]
                        + "','" + feedback.PatientId + " ','" + feedback.SerialNumber + "')";*/
            string sqlDml = "INSERT INTO patients (SerialNumber, name,surname, parentName, id, dateOfBirth, placeOfBirth, municipalityOfBirth, stateOfBirth, nationality, citizenship, address, placeOfResidence, municipalityOfResidence, stateOfResidence, profession, employmentStatus, maritalStatus, contact,email, password, gender, healthInsuranceNumber, familyDiseases, personalDiseases, guest)  VALUES('" + patient.SerialNumber + "','" + patient.Name + "','" + patient.Surname + "','" + patient.ParentName + "','" + patient.Id + "','" + partsOfDate[2] + "-" + partsOfDate[0] + "-" + partsOfDate[1] + "T" + dateString[1]
                       + "','" + patient.PlaceOfBirth
                       + "','" + patient.MunicipalityOfBirth + " ','" + patient.StateOfBirth + " ','" + patient.Nationality + " ','" + patient.Citizenship + " ','" + patient.Addresss + " ','" + 
                       patient.PlaceOfResidence + " ','" + patient.MunicipalityOfResidence + " ','" + patient.StateOfResidence + " ','" + patient.Profession + " ','" + patient.EmploymentStatus + " ','" + patient.MaritalStatus + " ','" + patient.Contact + " ','"
                       + patient.Email + " ','" + patient.Password + " ','" + patient.Gender + " ','" + patient.HealthInsuranceNumber + " ','" + patient.FamilyDiseases + " ','" + patient.PersonalDiseases + " ','" + 1 + "')";

            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            sqlCommand.ExecuteNonQuery();
            connection.Close();

            return true;
        }
    }
}
