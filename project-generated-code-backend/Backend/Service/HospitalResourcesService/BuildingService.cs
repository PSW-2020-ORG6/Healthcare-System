using System;
using System.Collections.Generic;
using health_clinic_class_diagram.Backend.Repository;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;

namespace HealthClinicBackend.Backend.Service.HospitalResourcesService
{
    public class BuildingService
    {
        private readonly IBuildingRepository _buildingRepository;

        public BuildingService()
        {
            _buildingRepository = new BuildingDatabaseSql();
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