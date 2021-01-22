using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Service.HospitalResourcesService;
using System;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Controller.SuperintendentControllers
{
    public class RenovationController
    {
        private RenovationService _renovationService;

        public RenovationController()
        {
            _renovationService = new RenovationService();
        }

        public RenovationController(RenovationService renovationService)
        {
            _renovationService = renovationService;
        }

        public Renovation GetById(String id)
        {
            throw new NotImplementedException();
        }

        public List<Renovation> GetAll()
        {
            return _renovationService.GetAll();
        }

        public void EditRenovation(Renovation renovation)
        {
            _renovationService.EditRenovation(renovation);
        }

        public void DeleteRenovation(Renovation renovation)
        {
            _renovationService.DeleteRenovation(renovation);
        }

        public void NewRenovation(Renovation renovation)
        {
            _renovationService.NewRenovation(renovation);
        }

        public void DeleteRenovationsWithRoom(Room room)
        {
            _renovationService.DeleteRenovationsWithRoom(room);
        }
    }
}