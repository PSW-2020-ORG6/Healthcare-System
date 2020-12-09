using System.Collections.Generic;
using HealthClinicBackend.Backend.Service.HospitalAccountsService;
using Model.Accounts;
using Model.Util;

namespace HealthClinicBackend.Backend.Controller.SuperintendentControllers
{
    public class SuperintendentPhysiciansController
    {
        private readonly PhysicianAccountService _physiciansService;

        public SuperintendentPhysiciansController()
        {
            _physiciansService = new PhysicianAccountService();
        }

        public List<Physician> GetAllPhysicians()
        {
            return _physiciansService.GetAllPhysitians();
        }

        public void NewPhysician(Physician physician)
        {
            _physiciansService.NewPhysician(physician);
        }

        public void EditPhysician(Physician physician)
        {
            _physiciansService.EditPhysician(physician);
        }

        public void DeletePhysician(Physician physician)
        {
            _physiciansService.DeletePhysician(physician);
        }

        public List<TimeInterval> GetAllVacations(Physician physicianDto)
        {
            return _physiciansService.GetAllVacations(physicianDto);
        }

        public void AddVacation(TimeInterval timeInterval, Physician physicianDto)
        {
            _physiciansService.AddVacation(timeInterval, physicianDto);
        }

        public void RemoveVacation(TimeInterval timeInterval, Physician physicianDto)
        {
            _physiciansService.RemoveVacation(timeInterval, physicianDto);
        }

        public bool JmbgExists(string jmbg)
        {
            return _physiciansService.JmbgExists(jmbg);
        }
    }
}