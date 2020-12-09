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
        public Equipment GetById()
        {
            throw new NotImplementedException();
        }

        public List<Equipment> GetAll()
        {
            return equipmentService.GetAll();
        }

        public void EditEquipment(Equipment equipment)
        {
            throw new NotImplementedException();
        }

        public void NewEquipment(Equipment equipment)
        {
            equipmentService.NewEquipment(equipment);
        }

        public void DeleteEquipment(Equipment equipment)
        {
            throw new NotImplementedException();
        }

        public EquipmentService equipmentService;

        public EquipmentController()
        {
            equipmentService = new EquipmentService();
        }

    }
}