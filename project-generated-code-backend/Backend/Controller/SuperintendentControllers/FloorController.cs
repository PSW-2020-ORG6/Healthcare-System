using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Service.HospitalResourcesService;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinicBackend.Backend.Controller.SuperintendentControllers
{
    public class FloorController
    {
        public FloorService floorService;

        public FloorController()
        {
            floorService = new FloorService();
        }

        public Floor GetById(string id)
        {
            return floorService.GetById(id);
        }

        public List<Floor> GetByName(string name)
        {
            return floorService.GetByName(name);
        }

        public List<Floor> GetAll()
        {
            return floorService.GetAll();
        }

        public void EditFloor(Floor floor)
        {
            floorService.EditFloor(floor);
        }

        public void NewFloor(Floor floor)
        {
            floorService.NewFloor(floor);
        }

        public void DeleteFloor(Floor floor)
        {
            floorService.DeleteFloor(floor);
        }
    }
}
