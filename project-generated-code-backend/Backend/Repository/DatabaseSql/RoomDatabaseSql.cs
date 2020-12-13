﻿using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class RoomDatabaseSql : GenericDatabaseSql<Room>, IRoomRepository
    {
        public override List<Room> GetAll()
        {
            return dbContext.Room
                .Include(r => r.Floor)
                .Include(r => r.RoomType)
                .Include(r => r.Equipment)
                .Include(r => r.Beds)
                .ToList();
        }

        public override Room GetById(string id)
        {
            return GetAll().Where(r => r.Id.Equals(id)).ToList()[0];
        }

        public List<Room> GetByProcedureType(ProcedureType procedureType)
        {
            throw new System.NotImplementedException();
        }

        public List<Room> GetByRoomType(RoomType roomType)
        {
            return GetAll().Where(r => r.RoomType.Equals(roomType)).ToList();
        }

        public List<Room> GetByName(string name)
        {
            return GetAll().Where(r => r.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public List<Room> GetByFloorSerialNumber(string floorSerialNumber)
        {
            return GetAll().Where(r => r.FloorSerialNumber.Equals(floorSerialNumber)).ToList();
        }
    }
}