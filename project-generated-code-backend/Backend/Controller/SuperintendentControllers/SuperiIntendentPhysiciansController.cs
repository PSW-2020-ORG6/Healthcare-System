using HealthClinic.Backend.Service.HospitalAccountsService;
using Model.Accounts;
using Model.Util;
using System.Collections.Generic;

namespace HealthClinic.Backend.Controller.SuperintendentControllers
{
    public class SuperiIntendentPhysiciansController
    {
        public PhysicianAccountService physiciansService;

        public SuperiIntendentPhysiciansController()
        {
            physiciansService = new PhysicianAccountService();
        }

        public List<Physician> GetAllPhysitians()
        {
            return physiciansService.GetAllPhysitians();
        }
        public void NewPhysician(Physician physician)
        {
            physiciansService.NewPhysician(physician);
        }

        public void EditPhysitian(Physician physician)
        {
            physiciansService.EditPhysician(physician);
        }

        public void DeletePhysitian(Physician physician)
        {
            physiciansService.DeletePhysician(physician);
        }

        public List<TimeInterval> GetAllVacations(Physician physicianDto)
        {
            return physiciansService.GetAllVacations(physicianDto);
        }

        public void AddVacation(TimeInterval timeInterval, Physician physicianDto)
        {
            physiciansService.AddVacation(timeInterval, physicianDto);
        }

        public void RemoveVacation(TimeInterval timeInterval, Physician physicianDto)
        {
            physiciansService.RemoveVacation(timeInterval, physicianDto);
        }

        public bool jmbgExists(string jmbg)
        {
            return physiciansService.jmbgExists(jmbg);
        }
    }
}
