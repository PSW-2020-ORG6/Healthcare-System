using health_clinic_class_diagram.Backend.Model.Hospital;
using health_clinic_class_diagram.Backend.Repository;
using System;
using System.Collections.Generic;

namespace health_clinic_class_diagram.Backend.Service.HospitalResourcesService
{
    public class FloorService
    {
        public FloorRepository floorRepository;

        public FloorService()
        {
            floorRepository = new FloorFileSystem();
        }

        public Floor GetById()
        {
            throw new NotImplementedException();
        }

        public List<Floor> GetAll()
        {
            return floorRepository.GetAll();
        }

        public void EditFloor(Floor floor)
        {
            throw new NotImplementedException();
        }

        public void NewFloor(Floor floor)
        {
            floorRepository.Save(floor);
        }

        public void DeleteFloor(Floor floor)
        {
            throw new NotImplementedException();
        }
    }
}
