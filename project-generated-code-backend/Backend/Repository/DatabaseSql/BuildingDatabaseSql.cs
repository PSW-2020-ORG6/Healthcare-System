﻿using System.Collections.Generic;
using System.Linq;
using health_clinic_class_diagram.Backend.Model.Hospital;
using health_clinic_class_diagram.Backend.Repository;
using Microsoft.EntityFrameworkCore;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class BuildingDatabaseSql: GenericDatabaseSql<Building>, IBuildingRepository
    {
        public override List<Building> GetAll()
        {
            return dbContext.Building
                .Include(b => b.Floors)
                .ToList();
        }
    }
}