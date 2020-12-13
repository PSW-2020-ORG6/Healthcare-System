using HealthClinicBackend.Backend.Model.Util;
using System;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IGenericRepository<T> where T : Entity
    {
        List<T> GetAll();

        void Save(T newEntity);

        void Update(T updateEntity);

        void Delete(String id);

        T GetById(String id);

        T Instantiate(string objectStringFormat);
    }
}