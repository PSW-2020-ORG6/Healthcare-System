using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Service.HospitalResourcesService;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Controller.SuperintendentControllers
{
    public class BuildingController
    {
        public BuildingService buildingService;

        public BuildingController()
        {
            buildingService = new BuildingService();
        }

        public Building GetById(string id)
        {
            return buildingService.GetById(id);
        }

        public Building GetBySerialNumber(string serialNumber)
        {
            return buildingService.GetBySerialNumber(serialNumber);
        }

        public List<Building> GetByName(string name)
        {
            return buildingService.GetByName(name);
        }

        public List<Building> GetAll()
        {
            return buildingService.GetAll();
        }

        public void EditBuilding(Building building)
        {
            buildingService.EditBuilding(building);
        }

        public void NewBuilding(Building building)
        {
            buildingService.NewBuilding(building);
        }

        public void DeleteBuilding(Building building)
        {
            buildingService.DeleteBuilding(building);
        }
    }
}
