using Model.Accounts;
using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using WebApplication.Backend.Repositorys.Interfaces;

namespace WebApplication.Backend.Repositorys
{
    public class PhysitianRepository : IPhysitianRepository
    {
        private readonly PhysicianDatabaseSql _physicianRepository;

        public PhysitianRepository()
        {
            _physicianRepository = new PhysicianDatabaseSql();
        }
        
        public List<Physician> GetAllPhysitians()
        {
            return _physicianRepository.GetAll();
        }

        public List<Physician> GetPhysitiansByName(string name)
        {
            return _physicianRepository.GetByName(name);
        }

        public List<Physician> GetPhysitiansByFullName(string fullName)
        {
            // TODO: this is not a property you should search for
            return new List<Physician>();
        }

        public Physician GetPhysitianBySerialNumber(string serialNumber)
        {
            return _physicianRepository.GetById(serialNumber);
        }

        public Physician GetPhysitianById(string id)
        {
            return _physicianRepository.GetByJmbg(id);
        }
    }
}