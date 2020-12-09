// File:    GenericFileRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class GenericFileRepository

using System;
using System.Collections.Generic;
using System.IO;
using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.Generic;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Repository.FileSystem
{
    public abstract class GenericFileSystem<T> : IGenericRepository<T> where T : Entity
    {
        protected String path;

        public void Delete(String id)
        {
            List<T> entities = GetAll();
            T entity = GetById(id);
            bool b = entities.Remove(entity);
            if (!b) Console.WriteLine("Nije pronadjen entitet za brisanje");
            SaveAll(entities);
        }

        public List<T> GetAll()
        {
            List<T> entities = new List<T>();
            String[] lines = File.ReadAllLines(path);
            foreach (String line in lines)
            {
                entities.Add(Instantiate(line));
            }
            return entities;
        }

        public T GetById(String id)
        {
            foreach (T entity in GetAll())
            {
                if (entity.SerialNumber.Equals(id))
                {
                    return entity;
                }
            }
            return null;
        }

        public void Save(T newEntity)
        {
            List<T> entities = GetAll();
            entities.Add(newEntity);
            SaveAll(entities);
        }

        public void Update(T updateEntity)
        {
            Delete(updateEntity.SerialNumber);
            Save(updateEntity);
        }

        public abstract T Instantiate(string objectStringFormat);

        private void SaveAll(List<T> entities)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            StreamWriter sw = new StreamWriter(path);
            JsonWriter writer = new JsonTextWriter(sw);
            foreach (T e in entities)
            {
                serializer.Serialize(writer, e);
                writer.WriteRaw("\n");
            }
            sw.Close();
            writer.Close();
        }
    }
}