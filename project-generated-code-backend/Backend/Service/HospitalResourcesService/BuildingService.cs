using health_clinic_class_diagram.Backend.Model.Hospital;
using health_clinic_class_diagram.Backend.Repository;
using System;
using System.Collections.Generic;

namespace health_clinic_class_diagram.Backend.Service.HospitalResourcesService
{
    public class BuildingService
    {
        public BuildingRepository buildingRepository;

        public BuildingService()
        {
            buildingRepository = new BuildingFileSystem();
        }

        public Building GetById()
        {
            throw new NotImplementedException();
        }

        public List<Building> GetAll()
        {
            return buildingRepository.GetAll();
        }

        public void EditBuilding(Building building)
        {
            throw new NotImplementedException();
        }

        public void NewBuilding(Building building)
        {
            buildingRepository.Save(building);
        }

        public void DeleteBuilding(Building building)
        {
            throw new NotImplementedException();
        }
    }
}
