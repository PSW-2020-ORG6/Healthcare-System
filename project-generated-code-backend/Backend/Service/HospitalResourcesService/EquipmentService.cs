// File:    EquipmentService.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class EquipmentService

using System;
using System.Collections.Generic;
using Backend.Repository;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using Model.Hospital;

namespace HealthClinicBackend.Backend.Service.HospitalResourcesService
{
    public class EquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentService()
        {
            _equipmentRepository = new EquipmentDatabaseSql();
        }

        public Equipment GetById()
        {
            throw new NotImplementedException();
        }

        public List<Equipment> GetAll()
        {
            return _equipmentRepository.GetAll();
        }

        public void EditEquipment(Equipment equipment)
        {
            throw new NotImplementedException();
        }

        public void NewEquipment(Equipment equipment)
        {
            _equipmentRepository.Save(equipment);
        }

        public void DeleteEquipment(Equipment equipment)
        {
            throw new NotImplementedException();
        }
    }
}