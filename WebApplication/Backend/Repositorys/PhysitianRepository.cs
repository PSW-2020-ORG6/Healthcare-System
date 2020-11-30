using Model.Accounts;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Backend.Repositorys
{
    public class PhysitianRepository
    {
        private MySqlConnection connection;
        public PhysitianRepository()
        {
            connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=Tanjaa;password=TanjaaD");
        }
        ///Tanja Drcelic RA124/2017
        /// <summary>
        ///Get physitions from table
        ///</summary>
        ///<param name="sqlDml"> data manipulation language
        ///</param>
        ///<returns>
        ///list of physitions
        ///</returns>
        private List<Physitian> GetPhysitian(String sqlDml)
        {
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<Physitian> resultList = new List<Physitian>();
            while (sqlReader.Read())
            {
                Physitian entity = new Physitian();
                entity.SerialNumber= (string)sqlReader[0];
                entity.Name= (string)sqlReader[1];
                entity.Surname= (string)sqlReader[2];
                resultList.Add(entity);
            }
            connection.Close();
            return resultList;
        }
        ///Tanja Drcelic RA124/2017
        /// <summary>
        ///Get physition by id from table
        ///</summary>
        ///<param name="sqlDml"> data manipulation language
        ///</param>
        ///<returns>
        ///Physitian
        ///</returns>
        public Physitian GetPhysitianById(string id)
        {
            if (id != null) {
                List<Physitian> physitians = GetPhysitian("Select * from accounts where SerialNumber like '" + id + "'");
                if (physitians.Any())
                    return physitians[0];
         }
                return null;
        }
    }
}
