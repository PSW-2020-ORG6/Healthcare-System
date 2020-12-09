using System.Collections.Generic;
using Backend.Repository;
using HealthClinicBackend.Backend.Model.Util;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class GenericDatabaseSql<T> : IGenericRepository<T> where T : Entity
    {
        private const string CONNECTION_STRING =
            "User ID =postgres;Password=super;Server=localhost;Port=5432;Database=healthcare-system-db;Integrated Security=true;Pooling=true;";

        public readonly HealthCareSystemDbContext dbContext;

        protected GenericDatabaseSql()
        {
            var options = new DbContextOptionsBuilder<HealthCareSystemDbContext>()
                .UseNpgsql(CONNECTION_STRING)
                .Options;
            dbContext = new HealthCareSystemDbContext(options);
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