using Model.Accounts;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Backend.Repositorys
{
    public class PatientRepository
    {
        ///Tanja Drcelic RA124/2017
        /// <summary>
        ///Get all patients from patients table
        ///</summary>
        ///<returns>
        ///true if sucessful,else false
        ///</returns>
        ///<exception>
        ///if any exception occurs method will return null
        ///</exception>
        internal List<Patient> GetAllPatients()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");

                string sql1 = "Select * from patients";
                conn.Open();
                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                MySqlDataReader rdr = cmd1.ExecuteReader();
                List<Patient> resultList = new List<Patient>();
                while (rdr.Read())
                {
                    Patient entity = new Patient();
                    entity.Id = (string)rdr[3];
                    entity.Name = (string)rdr[1];
                    entity.Surname = (string)rdr[2];
                    entity.ParentName = (string)rdr[7];
                    entity.SerialNumber = (string)rdr[0];
                    entity.DateOfBirth = (DateTime)rdr[4];
                    entity.Contact = (string)rdr[5];
                    entity.Email = (string)rdr[6];
                    entity.Gender = (string)rdr[8];
                    entity.Guest = (Boolean)rdr[9];
                    entity.Password = (string)rdr[10];
                    resultList.Add(entity);

                }
                conn.Close();
                return resultList;
            }catch(Exception e)
            {
                return null;
            }
        }
    }
}
