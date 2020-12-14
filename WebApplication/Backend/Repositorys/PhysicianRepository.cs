using Model.Accounts;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using WebApplication.Backend.Repositorys.Interfaces;

namespace WebApplication.Backend.Repositorys
{
    public class PhysicianRepository : IPhysicianRepository
    {
        private readonly PhysicianDatabaseSql _physicianRepository;

        public PhysicianRepository()
        {
            _physicianRepository = new PhysicianDatabaseSql();
        }
        
        public List<Physician> GetAllPhysitians()
        {
            return _physicianRepository.GetAll();
        }

        public List<Physician> GetPhysiciansByName(string name)
        {
            return _physicianRepository.GetByName(name);
        }

        public List<Physician> GetPhysiciansByFullName(string fullName)
        {
            // TODO: this is not a property you should search for
            return new List<Physician>();
        }

        public Physician GetPhysicianById(string id)
        {
            return _physicianRepository.GetById(id);
        }

        public Physician GetPhysicianBySpecialization(string specializationName, string physicianId)
        {
            return _physicianRepository.GetByJmbg(physicianId);
        }

        public List<Physician> GetAllPhysicians()
        {
            throw new NotImplementedException();
        }

        public Physician GetPhysicianBySerialNumber(string serialNumber)
        {
            throw new NotImplementedException();
        }

        List<Physician> IPhysicianRepository.GetPhysicianBySpecialization(string specializationName, string physicianId)
        {
            throw new NotImplementedException();
        }
    }
}