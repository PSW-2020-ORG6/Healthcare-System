﻿using System.Collections.Generic;
using MicroServiceAccount.Backend.Model.Util;
using MicroServiceAppointment.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace MicroServiceAppointment.Backend.Repository.DatabaseSql
{
    public class GenericMsAppointmentDatabaseSql<T> : IGenericMsAppointmentRepository<T> where T : Entity
    {
        private const string CONNECTION_STRING =
            "User ID =postgres;Password=super;Server=localhost;Port=5432;Database=healthcare-system-db;Integrated Security=true;Pooling=true;";

        protected readonly MsAppointmentDbContext DbContext;

        protected GenericMsAppointmentDatabaseSql()
        {
            var options = new DbContextOptionsBuilder<MsAppointmentDbContext>()
                .UseNpgsql(CONNECTION_STRING)
                .Options;
            DbContext = new MsAppointmentDbContext(options);
        }

        protected GenericMsAppointmentDatabaseSql(MsAppointmentDbContext context)
        {
            DbContext = context;
        }

        public virtual List<T> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public virtual void Save(T newEntity)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Update(T updateEntity)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public virtual T GetById(string id)
        {
            throw new System.NotImplementedException();
        }

        public virtual T Instantiate(string objectStringFormat)
        {
            throw new System.NotImplementedException();
        }
    }
}