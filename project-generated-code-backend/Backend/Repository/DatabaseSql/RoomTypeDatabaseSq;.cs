﻿using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class RoomTypeDatabaseSql : GenericDatabaseSql<RoomType>, IRoomTypeRepository
    {
        public RoomTypeDatabaseSql(HealthCareSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override List<RoomType> GetAll()
        {
            return DbContext.RoomType.ToList();
        }
    }
}