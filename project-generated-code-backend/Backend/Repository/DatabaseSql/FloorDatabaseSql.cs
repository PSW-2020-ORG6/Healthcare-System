﻿using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class FloorDatabaseSql : GenericDatabaseSql<Floor>, IFloorRepository
    {
        public FloorDatabaseSql() : base()
        {
        }

        public FloorDatabaseSql(HealthCareSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override List<Floor> GetAll()
        {
            return DbContext.Floor.ToList();
        }

        public override Floor GetById(string id)
        {
            return DbContext.Floor.Find(id);
        }


        public override void Save(Floor newEntity)
        {
            DbContext.Floor.Add(newEntity);
            DbContext.SaveChanges();
        }

        public override void Update(Floor updateEntity)
        {
            DbContext.Floor.Update(updateEntity);
            DbContext.SaveChanges();
        }

        public override void Delete(string id)
        {
            var floor = GetById(id);
            if (floor == null) return;
            DbContext.Floor.Remove(floor);
            DbContext.SaveChanges();
        }

        public List<Floor> GetByName(string name)
        {
            return GetAll().Where(f => f.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public override Floor GetBySerialNumber(string serialNumber)
        {
            return GetAll().Where(f => f.SerialNumber.Equals(serialNumber)).ToList()[0];
        }

        public List<Floor> GetByBuildingSerialNumber(string buildingSerialNumber)
        {
            return GetAll().Where(f => f.BuildingSerialNumber.Equals(buildingSerialNumber)).ToList();
        }
    }
}