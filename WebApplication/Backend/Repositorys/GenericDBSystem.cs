using Backend.Model.Util;
using Backend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApplication.Backend.Repositorys
{
    public abstract class GenericDBSystem<T> : GenericRepository<T> where T : Entity
    {
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(string id)
        {
            throw new NotImplementedException();
        }

        public T Instantiate(string objectStringFormat)
        {
            throw new NotImplementedException();
        }

        public void Save(T newEntity)
        {
            throw new NotImplementedException();
        }

        public void Update(T updateEntity)
        {
            throw new NotImplementedException();
        }
    }
}
