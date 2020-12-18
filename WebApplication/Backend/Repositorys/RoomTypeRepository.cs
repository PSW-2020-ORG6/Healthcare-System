using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using WebApplication.Backend.Repositorys.Interfaces;

namespace WebApplication.Backend.Repositorys
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly RoomTypeDatabaseSql _roomTypeRepository;

        public RoomTypeRepository()
        {
            _roomTypeRepository = new RoomTypeDatabaseSql();
        }

        public List<RoomType> GetAllGetRoomTypes()
        {
            return _roomTypeRepository.GetAll();
        }

        public RoomType GetRoomTypeBySerialNumber(string serialNumber)
        {
            return _roomTypeRepository.GetById(serialNumber);
        }
    }
}