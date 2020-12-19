﻿using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class RejectionDatabaseSql : GenericDatabaseSql<Rejection>, IRejectionRepository
    {
        public RejectionDatabaseSql(HealthCareSystemDbContext context) : base(context)
        {
        }

        public override List<Rejection> GetAll()
        {
            return dbContext.Rejection.ToList();
        }

        public override void Save(Rejection newEntity)
        {
            dbContext.Rejection.Add(newEntity);
            dbContext.SaveChanges();
        }

        public override void Delete(string id)
        {
            var rejection = dbContext.Rejection.Find(id);
            if (rejection == null) return;
            dbContext.Rejection.Remove(rejection);
            dbContext.SaveChanges();
        }

        public override void Update(Rejection updateEntity)
        {
            dbContext.Rejection.Update(updateEntity);
            dbContext.SaveChanges();
        }

        public override Rejection GetById(string id)
        {
            return dbContext.Rejection.Find(id);
        }
    }
}