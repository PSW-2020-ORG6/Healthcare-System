// File:    RenovationService.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class RenovationService

using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Service.HospitalResourcesService
{
    public class RenovationService
    {
        private readonly IRenovationRepository _renovationRepository;

        public RenovationService(IRenovationRepository renovationRepository)
        {
            _renovationRepository = renovationRepository;
        }

        public Renovation GetById(String id)
        {
            throw new NotImplementedException();
        }

        public List<Renovation> GetAll()
        {
            return _renovationRepository.GetAll();
        }

        public void EditRenovation(Renovation renovation)
        {
            _renovationRepository.Update(renovation);
        }

        public void DeleteRenovation(Renovation renovation)
        {
            _renovationRepository.Delete(renovation.SerialNumber);
        }

        public void NewRenovation(Renovation renovation)
        {
            _renovationRepository.Save(renovation);
        }

        public void DeleteRenovationsWithRoom(Room room)
        {
            foreach (Renovation r in _renovationRepository.GetAll())
            {
                if (r.Room.SerialNumber.Equals(room.SerialNumber))
                {
                    _renovationRepository.Delete(r.SerialNumber);
                }
            }
        }
    }
}