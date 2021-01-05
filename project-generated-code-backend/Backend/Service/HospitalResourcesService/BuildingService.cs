using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Service.HospitalResourcesService
{
    public class BuildingService
    {
        private readonly IBuildingRepository _buildingRepository;

        public BuildingService(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public Building GetById()
        {
            throw new NotImplementedException();
        }

        public List<Building> GetAll()
        {
            return _buildingRepository.GetAll();
        }

        public void EditBuilding(Building building)
        {
            throw new NotImplementedException();
        }

        public void NewBuilding(Building building)
        {
            _buildingRepository.Save(building);
        }

        public void DeleteBuilding(Building building)
        {
            throw new NotImplementedException();
        }
    }
}