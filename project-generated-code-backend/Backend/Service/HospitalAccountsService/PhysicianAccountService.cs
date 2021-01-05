using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Service.HospitalAccountsService
{
    public class PhysicianAccountService
    {
        private readonly IPhysicianRepository _physicianRepository;

        public PhysicianAccountService(IPhysicianRepository physicianRepository)
        {
            _physicianRepository = physicianRepository;
        }

        internal List<TimeInterval> GetAllVacations(Physician physicianDto)
        {
            return _physicianRepository.GetById(physicianDto.SerialNumber).VacationTime;
        }

        internal void AddVacation(TimeInterval timeInterval, Physician physicianDto)
        {
            physicianDto.AddVacationTime(timeInterval);
            _physicianRepository.Update(physicianDto);
        }

        internal void RemoveVacation(TimeInterval timeInterval, Physician physicianDto)
        {
            physicianDto.RemoveVacationTime(timeInterval);
            _physicianRepository.Update(physicianDto);
        }

        internal void DeletePhysician(Physician physician)
        {
            _physicianRepository.Delete(physician.SerialNumber);
        }

        public List<Physician> GetAllPhysicians()
        {
            return _physicianRepository.GetAll();
        }

        internal void NewPhysician(Physician physician)
        {
            _physicianRepository.Save(physician);
        }

        internal void EditPhysician(Physician physician)
        {
            _physicianRepository.Update(physician);
        }

        internal void DeletePhysicianById(string id)
        {
            _physicianRepository.Delete(id);
        }

        public bool JmbgExists(string jmbg)
        {
            return _physicianRepository.GetAll().Any(p => p.Id.Equals(jmbg));
        }
    }
}