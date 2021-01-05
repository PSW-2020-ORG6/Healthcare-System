// File:    EquipmentService.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class EquipmentService

using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Service.HospitalResourcesService
{
    public class EquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentService(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
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