// File:    EquipmentControler.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class EquipmentControler

using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Service.HospitalResourcesService;

namespace HealthClinicBackend.Backend.Controller.SuperintendentControllers
{
    public class EquipmentController
    {
        private readonly EquipmentService _equipmentService;

        public EquipmentController(EquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        public Equipment GetById()
        {
            throw new NotImplementedException();
        }

        public List<Equipment> GetAll()
        {
            return _equipmentService.GetAll();
        }

        public void EditEquipment(Equipment equipment)
        {
            throw new NotImplementedException();
        }

        public void NewEquipment(Equipment equipment)
        {
            _equipmentService.NewEquipment(equipment);
        }

        public void DeleteEquipment(Equipment equipment)
        {
            throw new NotImplementedException();
        }
    }
}