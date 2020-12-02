using GraphicEditor.Repositories.Interfaces;
using Model.Accounts;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GraphicEditor.Repositories
{
    public class PhysitianRepository : IPhysitianRepository
    {
        private MySqlConnection connection;
        private AddressRepository addressRepository = new AddressRepository();
        private SpecializationRepository specializationRepository = new SpecializationRepository();
        private TimeIntervalRepository timeIntervalRepository = new TimeIntervalRepository();

        public PhysitianRepository()
        {
            connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
        }

        private List<Physitian> GetPhysitians(String query)
        {
            connection.Close();
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(query, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<Physitian> resultList = new List<Physitian>();
            while (sqlReader.Read())
            {
                Physitian entity = new Physitian();
                entity.SerialNumber = (string)sqlReader[0];
                entity.Name = (string)sqlReader[1];
                entity.Surname = (string)sqlReader[2];
                entity.FullName = entity.Name + " " + entity.Surname;
                entity.Id = (string)sqlReader[3];
                entity.DateOfBirth = (DateTime)sqlReader[4];
                entity.Contact = (string)sqlReader[5];
                entity.Email = (string)sqlReader[6];
                entity.Address = addressRepository.GetAddressBySerialNumber((string)sqlReader[7]);
                entity.Password = (string)sqlReader[8];
                entity.Specialization = specializationRepository.GetSpecializationsBySerialNumber((string)sqlReader[9]);
                entity.VacationTime = timeIntervalRepository.GetTimeIntervalsById((string)sqlReader[10]);
                entity.WorkSchedule = timeIntervalRepository.GetTimeIntervalById((string)sqlReader[11]);
                entity.AllSpecializations = specializationRepository.GetSpecializationsNameBySerialNumber((string)sqlReader[12]);
                entity.AddressSerialNumber = (string)sqlReader[13];
                resultList.Add(entity);
            }
            connection.Close();
            return resultList;
        }

        public List<Physitian> GetAllPhysitians()
        {
            try
            {
                return GetPhysitians("Select * from physitians");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Physitian> GetPhysitiansByName(string name)
        {
            try
            {
                return GetPhysitians("Select * from physitians where Name like '%" + name + "%'");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Physitian> GetPhysitiansByFullName(string fullName)
        {
            try
            {
                return GetPhysitians("Select * from physitians where FullName like '%" + fullName + "%'");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Physitian GetPhysitianBySerialNumber(string serialNumber)
        {
            try
            {
                return GetPhysitians("Select * from physitians where SerialNumber='" + serialNumber + "'")[0];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public Physitian GetPhysitianById(string id)
        {
            try
            {
                return GetPhysitians("Select * from physitians where Id='" + id + "'")[0];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

    }
}
