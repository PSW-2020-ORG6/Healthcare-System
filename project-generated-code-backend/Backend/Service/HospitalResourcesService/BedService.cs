using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Service.HospitalResourcesService
{
    public class BedService
    {
        private readonly IBedRepository _bedRepository;

        public BedService()
        {
            _bedRepository = new BedDatabaseSql();
        }

        public BedService(IBedRepository bedRepository)
        {
            _bedRepository = bedRepository;
        }

        public Bed GetById(string id)
        {
            return _bedRepository.GetById(id);
        }

        public List<Bed> GetByName(string name)
        {
            return _bedRepository.GetByName(name);
        }

        public List<Bed> GetByRoomSerialNumber(string roomSerialNumber)
        {
            return _bedRepository.GetByRoomSerialNumber(roomSerialNumber);
        }

        public List<Bed> GetAll()
        {
            return _bedRepository.GetAll();
        }

        public void EditBed(Bed bed)
        {
            _bedRepository.Update(bed);
        }

        public void NewBed(Bed bed)
        {
            _bedRepository.Save(bed);
        }

        public void DeleteBed(Bed bed)
        {
            _bedRepository.Delete(bed.SerialNumber);
        }
    }
}