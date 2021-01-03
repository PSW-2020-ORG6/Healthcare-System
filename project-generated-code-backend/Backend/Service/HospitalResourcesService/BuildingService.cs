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
        private readonly IFloorRepository _floorRepository;

        public BuildingService()
        {
            _buildingRepository = new BuildingDatabaseSql();
            _floorRepository = new FloorDatabaseSql();
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

        public Building GetBySerialNumber(string serialNumber)
        {
            return _buildingRepository.GetBySerialNumber(serialNumber);
        }

        public void EditBuilding(Building building)
        {
            foreach (Floor floor in _floorRepository.GetByBuildingSerialNumber(building.SerialNumber))
                _floorRepository.Update(floor);
            _buildingRepository.Update(building);
        }

        public void NewBuilding(Building building)
        {
            _buildingRepository.Save(building);
        }

        public void DeleteBuilding(Building building)
        {
            foreach (Floor floor in _floorRepository.GetByBuildingSerialNumber(building.SerialNumber))
                _floorRepository.Delete(floor.SerialNumber);
            _buildingRepository.Delete(building.SerialNumber);
        }
    }
}