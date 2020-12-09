using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using WebApplication.Backend.Repositorys.Interfaces;

namespace WebApplication.Backend.Repositorys
{
    public class SpecializationRepository : ISpecializationRepository
    {
        private readonly SpecializationDatabaseSql _specializationRepository;

        public SpecializationRepository()
        {
            _specializationRepository = new SpecializationDatabaseSql();
        }

        public List<Specialization> GetSpecializationsBySerialNumber(string serialNumber)
        {
            return new List<Specialization>();
        }
        public List<Specialization> GetSpecializationsByPhysicianSerialNumber(string serialNumber)
        {
            try
            {
                return GetSpecializations("Select * from specialization where PhysicianSerialNumber like '" + serialNumber + "'");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public string GetSpecializationsNameBySerialNumber(string serialNumber)
        {
            return _specializationRepository.GetById(serialNumber).Name;
        }

        public Specialization GetSpecializationBySerialNumber(string serialNumber)
        {
            return _specializationRepository.GetById(serialNumber);
        }
       
        public List<Specialization> GetSpecializationByName(string name)
        {
            return _specializationRepository.GetByName(name);
        }
        public List<Specialization> GetAllSpecializations()
        {
            try
            {
                return GetSpecializations("Select * from specialization");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}