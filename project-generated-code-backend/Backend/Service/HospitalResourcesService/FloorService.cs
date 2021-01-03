using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Service.HospitalResourcesService
{
    public class FloorService
    {
        private readonly IFloorRepository _floorRepository;

        public FloorService()
        {
            _floorRepository = new FloorDatabaseSql();
        }

        public FloorService(IFloorRepository floorRepository)
        {
            this._floorRepository = floorRepository;
        }

        public Floor GetById(string id)
        {
            return _floorRepository.GetById(id);
        }

        public Floor GetBySerialNumber(string serialNumber)
        {
            return _floorRepository.GetBySerialNumber(serialNumber);
        }

        public List<Floor> GetByName(string name)
        {
            return _floorRepository.GetByName(name);
        }

        public List<Floor> GetAll()
        {
            return _floorRepository.GetAll();
        }

        public void EditFloor(Floor floor)
        {
            _floorRepository.Update(floor);
        }

        public void NewFloor(Floor floor)
        {
            _floorRepository.Save(floor);
        }

        public void DeleteFloor(Floor floor)
        {
            _floorRepository.Delete(floor.SerialNumber);
        }
    }
}