using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;

namespace WebApplication.Backend.Repositorys
{
    public class BuildingRepository : IGenericRepository<Building>
    {
        private readonly BuildingDatabaseSql _buildingRepository;

        public BuildingRepository()
        {
            _buildingRepository = new BuildingDatabaseSql();
        }

        public List<Building> GetAllBuildings()
        {
            return _buildingRepository.GetAll();
        }

        public List<Building> GetBuildingsByName(string name)
        {
            return _buildingRepository.GetByName(name);
        }

        public Building GetBuildingBySerialNumber(string serialNumber)
        {
            return _buildingRepository.GetById(serialNumber);
        }

        public List<Building> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save(Building newEntity)
        {
            throw new NotImplementedException();
        }

        public void Update(Building updateEntity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Building GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Building Instantiate(string objectStringFormat)
        {
            throw new NotImplementedException();
        }
    }
}