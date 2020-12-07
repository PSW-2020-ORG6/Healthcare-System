﻿using System.Collections.Generic;
using System.Linq;
using Backend.Repository;
using Microsoft.EntityFrameworkCore;
using Model.Hospital;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class EquipmentDatabaseSql: GenericDatabaseSql<Equipment>, IEquipmentRepository
    {
        public override List<Equipment> GetAll()
        {
            return dbContext.Equipment
                .Include(e => e.Building)
                .Include(e => e.Floor)
                .Include(e => e.Room)
                .ToList();
        }
    }
}