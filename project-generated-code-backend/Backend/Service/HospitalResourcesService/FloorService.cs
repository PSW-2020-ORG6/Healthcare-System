using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Service.HospitalResourcesService
{
    public class FloorService
    {
        private readonly IFloorRepository _floorRepository;

        public FloorService(IFloorRepository floorRepository)
        {
            _floorRepository = floorRepository;
        }

        public Floor GetById()
        {
            throw new NotImplementedException();
        }

        public List<Floor> GetAll()
        {
            return _floorRepository.GetAll();
        }

        public void EditFloor(Floor floor)
        {
            throw new NotImplementedException();
        }

        public void NewFloor(Floor floor)
        {
            _floorRepository.Save(floor);
        }

        public void DeleteFloor(Floor floor)
        {
            throw new NotImplementedException();
        }
    }
}