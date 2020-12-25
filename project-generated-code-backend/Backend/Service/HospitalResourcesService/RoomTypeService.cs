using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinicBackend.Backend.Service.HospitalResourcesService
{
    public class RoomTypeService
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public RoomTypeService()
        {
            _roomTypeRepository = new RoomTypeDatabaseSql();
        }

        public RoomTypeService(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        public RoomType GetById(string id)
        {
            return _roomTypeRepository.GetById(id);
        }

        public List<RoomType> GetByName(string name)
        {
            return _roomTypeRepository.GetByName(name);
        }

        public List<RoomType> GetAll()
        {
            return _roomTypeRepository.GetAll();
        }

        public void EditRoomType(RoomType roomType)
        {
            _roomTypeRepository.Update(roomType);
        }

        public void NewRoomType(RoomType roomType)
        {
            _roomTypeRepository.Save(roomType);
        }

        public void DeleteRoomType(RoomType roomType)
        {
            _roomTypeRepository.Delete(roomType.SerialNumber);
        }
    }
}
