using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;
using System;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Service.HospitalResourcesService
{
    public class BuildingService
    {
        private readonly IBuildingRepository _buildingRepository;

        public BuildingService()
        {
            _buildingRepository = new BuildingDatabaseSql();
        }

        public BuildingService(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public Building GetById(string id)
        {
            return _buildingRepository.GetById(id);
        }

        public List<Building> GetAll()
        {
            return _buildingRepository.GetAll();
        }

        public List<Building> GetByName(string name)
        {
            return _buildingRepository.GetByName(name);
        }

        public void EditBuilding(Building building)
        {
            _buildingRepository.Update(building);
        }

        public void NewBuilding(Building building)
        {
            _buildingRepository.Save(building);
        }

        public void DeleteBuilding(Building building)
        {
            _buildingRepository.Delete(building.SerialNumber);
        }
    }
}