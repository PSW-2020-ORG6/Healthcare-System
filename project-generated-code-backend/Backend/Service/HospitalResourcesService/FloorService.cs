﻿using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Service.HospitalResourcesService
{
    public class FloorService
    {
        private readonly IFloorRepository _floorRepository;

        public FloorService()
        {
            _floorRepository = new FloorDatabaseSql();
        }

        public FloorService(IFloorRepository floorRepository)
        {
            _floorRepository = floorRepository;
        }

        public Floor GetById(string id)
        {
            return _floorRepository.GetById(id);
        }

        public List<Floor> GetByName(string name)
        {
            return _floorRepository.GetByName(name);
        }

        public List<Floor> GetAll()
        {
            return _floorRepository.GetAll();
        }

        public void EditFloor(Floor floor)
        {
            _floorRepository.Update(floor);
        }

        public void NewFloor(Floor floor)
        {
            _floorRepository.Save(floor);
        }

        public void DeleteFloor(Floor floor)
        {
            _floorRepository.Delete(floor.SerialNumber);
        }
    }
}