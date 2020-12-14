// File:    EquipmentControler.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class EquipmentControler

using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Service.HospitalResourcesService;
using System;
using System.Collections.Generic;

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
            _equipmentService.EditEquipment(equipment);
        }

        public void NewEquipment(Equipment equipment)
        {
            _equipmentService.NewEquipment(equipment);
        }

        public void DeleteEquipment(Equipment equipment)
        {
            _equipmentService.DeleteEquipment(equipment);
        }

        public List<Equipment> GetByName(string name)
        {
            return _equipmentService.GetByName(name);
        }
    }
}