// File:    GenericRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface GenericRepository

using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Util;

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