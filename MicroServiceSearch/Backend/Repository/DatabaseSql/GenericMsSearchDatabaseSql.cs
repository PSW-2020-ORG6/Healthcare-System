using System.Collections.Generic;
using MicroServiceAccount.Backend.Model.Util;
using MicroServiceSearch.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace MicroServiceSearch.Backend.Repository.DatabaseSql
{
    public class GenericMsSearchDatabaseSql<T> : IGenericMsSearchRepository<T> where T : Entity
    {
        private const string CONNECTION_STRING =
            "User ID =postgres;Password=root;Server=localhost;Port=5432;Database=healthcare-system-db;Integrated Security=true;Pooling=true;";

        protected readonly MsSearchDbContext DbContext;

        protected GenericMsSearchDatabaseSql()
        {
            var options = new DbContextOptionsBuilder<MsSearchDbContext>()
                .UseNpgsql(CONNECTION_STRING)
                .Options;
            DbContext = new MsSearchDbContext(options);
        }

        protected GenericMsSearchDatabaseSql(MsSearchDbContext context)
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