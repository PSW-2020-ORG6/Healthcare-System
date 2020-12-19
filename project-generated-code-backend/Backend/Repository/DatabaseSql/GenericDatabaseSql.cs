using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class GenericDatabaseSql<T> : IGenericRepository<T> where T : Entity
    {
        // private const string CONNECTION_STRING =
        //     "User ID =postgres;Password=super;Server=localhost;Port=5432;Database=healthcare-system-db;Integrated Security=true;Pooling=true;";
        // private const string CONNECTION_STRING =
        // "server=localhost;port=3306;database=newdb;user=root;password=root";

        protected HealthCareSystemDbContext dbContext;

        protected GenericDatabaseSql(HealthCareSystemDbContext context)
        {
            dbContext = context;
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