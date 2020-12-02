using Model.Accounts;
using MySql.Data.MySqlClient;
using System;

namespace WebApplication.Backend.Repositorys
{
    /// <summary>
    /// This class does connection with MySQL database patient and address tables
    /// </summary>
    public class RegistrationRepository : IRegistrationRepository
    {
        private MySqlConnection connection;
        public RegistrationRepository()
        {
            try
            {
                connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
            }
            catch (Exception e)
            {
            }
        }

        ////Aleksandra Milijevic RA 22/2017
        /// <summary>
        ///Adds new row into patient table
        ///</summary>
        ///<returns>
        ///true if sucessful,else false
        ///</returns>
        ///<param name="patient"> Patient type object
        ///</param>
        public bool AddPatient(Patient patient)
        {
            connection.Open();
            string[] dateString = patient.DateOfBirth.ToString().Split(" ");
            string[] partsOfDate = dateString[0].Split("/");
            string sqlDml1 = "INSERT into addresses (SerialNumber,Street)VALUES('" + patient.Address.SerialNumber + " ','" + patient.Address.Street + "')";
            MySqlCommand sqlCommand1 = new MySqlCommand(sqlDml1, connection);
            sqlCommand1.ExecuteNonQuery();
            if (patient.Guest)
            {
                string sqlDml = "INSERT into patients (Id,SerialNumber,Name,Surname,DateOfBirth,Contact,Email,AddressSerialNumber,Password,ParentName,PlaceOfBirth,MunicipalityOfBirth,StateOfBirth,PlaceOfResidence,MunicipalityOfResidence,StateOfResidence,Citizenship,Nationality,Profession,EmploymentStatus,MaritalStatus,HealthInsuranceNumber,FamilyDiseases,PersonalDiseases,Gender,Image,Guest,EmailConfirmed)  VALUES('" + patient.Id + "','" + patient.SerialNumber + "','" + patient.Name + "','" + patient.Surname + "','" + partsOfDate[2] + "-" + partsOfDate[0] + "-" + partsOfDate[1] + "T" + dateString[1]
                           + " ','" + patient.Contact + " ','" + patient.Email + " ','" + patient.Address.SerialNumber + " ','" + patient.Password + " ','" + patient.ParentName + " ','" + patient.PlaceOfBirth
                           + "','" + patient.MunicipalityOfBirth + " ','" + patient.StateOfBirth + " ','" + patient.PlaceOfResidence + " ','" + patient.MunicipalityOfResidence + " ','" + patient.StateOfResidence + " ','" + patient.Citizenship + " ','" + patient.Nationality + " ','" +
                            patient.Profession + " ','" + patient.EmploymentStatus + " ','" + patient.MaritalStatus + " ','" +
                             patient.HealthInsuranceNumber + " ','" + patient.FamilyDiseases + " ','" + patient.PersonalDiseases + " ','" + patient.Gender + " ','" + patient.Image + " ','" + 0 + " ','" + 0 + "')";
                MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
                sqlCommand.ExecuteNonQuery();
            }
            else
            {
                string sqlDml = "INSERT into patients (Id,SerialNumber,Name,Surname,DateOfBirth,Contact,Email,AddressSerialNumber,Password,ParentName,PlaceOfBirth,MunicipalityOfBirth,StateOfBirth,PlaceOfResidence,MunicipalityOfResidence,StateOfResidence,Citizenship,Nationality,Profession,EmploymentStatus,MaritalStatus,HealthInsuranceNumber,FamilyDiseases,PersonalDiseases,Gender,Image,Guest,EmailConfirmed)  VALUES('" + patient.Id + "','" + patient.SerialNumber + "','" + patient.Name + "','" + patient.Surname + "','" + partsOfDate[2] + "-" + partsOfDate[0] + "-" + partsOfDate[1] + "T" + dateString[1]
                           + " ','" + patient.Contact + " ','" + patient.Email + " ','" + patient.Address.SerialNumber + " ','" + patient.Password + " ','" + patient.ParentName + " ','" + patient.PlaceOfBirth
                           + "','" + patient.MunicipalityOfBirth + " ','" + patient.StateOfBirth + " ','" + patient.PlaceOfResidence + " ','" + patient.MunicipalityOfResidence + " ','" + patient.StateOfResidence + " ','" + patient.Citizenship + " ','" + patient.Nationality + " ','" +
                            patient.Profession + " ','" + patient.EmploymentStatus + " ','" + patient.MaritalStatus + " ','" +
                             patient.HealthInsuranceNumber + " ','" + patient.FamilyDiseases + " ','" + patient.PersonalDiseases + " ','" + patient.Gender + " ','" + patient.Image + " ','" + 1 + " ','" + 0 + "')";
                MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
                sqlCommand.ExecuteNonQuery();
            }
            connection.Close();

            return true;
        }

        ///Aleksandra Milijevic RA 22/2017
        /// <summary>
        ///Get id from feedbacks table
        ///</summary>
        ///<param name="sqlDml"> data manipulation language
        ///</param>
        ///<returns>
        ///id if exists,else false
        ///</returns>
        public String GetPatientId(string sqlDml)
        {
            connection.Open();
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

        public bool IsPatientIdValid(string patientId)
        {
            string id = GetPatientId("Select id from patients where id=" + patientId);
            if (id == "" || id == null)
            {
                return true;
            }
            return false;
        }

        ////Aleksandra Milijevic RA 22/2017
        /// <summary>
        ///Update row into patient table
        ///</summary>
        ///<returns>
        ///true if sucessful,else false
        ///</returns>
        ///<param name="patientId"> String type object
        ///</param>
        public bool ConfirmEmailUpdate(string patientId)
        {
            connection.Open();
            string sqlDml = "UPDATE patients SET EmailConfirmed = '1' WHERE (Id = '" + patientId + "')";
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
            return true;
        }

    }
}
