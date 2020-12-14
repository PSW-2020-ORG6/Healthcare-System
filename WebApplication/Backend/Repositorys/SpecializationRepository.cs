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
            throw new System.NotImplementedException();
        }
    }
}