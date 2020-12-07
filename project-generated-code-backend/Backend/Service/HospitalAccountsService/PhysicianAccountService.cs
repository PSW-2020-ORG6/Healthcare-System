using Backend.Repository;
using Model.Accounts;
using Model.Util;
using System.Collections.Generic;

namespace HealthClinic.Backend.Service.HospitalAccountsService
{
    public class PhysicianAccountService
    {
        public IPhysitianRepository IPhysitianRepository;

        public PhysicianAccountService()
        {
            IPhysitianRepository = new PhysicianFileSystem();
        }

        internal List<TimeInterval> GetAllVacations(Physician physicianDto)
        {
            return IPhysitianRepository.GetById(physicianDto.SerialNumber).VacationTime;
        }

        internal void AddVacation(TimeInterval timeInterval, Physician physicianDto)
        {
            physicianDto.AddVacationTime(timeInterval);
            IPhysitianRepository.Update(physicianDto);
        }

        internal void RemoveVacation(TimeInterval timeInterval, Physician physicianDto)
        {
            physicianDto.RemoveVacationTime(timeInterval);
            IPhysitianRepository.Update(physicianDto);
        }

        internal void DeletePhysician(Physician physician)
        {
            IPhysitianRepository.Delete(physician.SerialNumber);
        }

        public List<Physician> GetAllPhysitians()
        {
            return IPhysitianRepository.GetAll();
        }

        internal void NewPhysician(Physician physician)
        {
            IPhysitianRepository.Save(physician);
        }

        internal void EditPhysician(Physician physician)
        {
            IPhysitianRepository.Update(physician);
        }

        internal void DeletePhysicianById(string id)
        {
            IPhysitianRepository.Delete(id);
        }

        public bool jmbgExists(string jmbg)
        {
            bool exists = false;
            foreach (Physician p in IPhysitianRepository.GetAll())
            {
                if (p.Id.Equals(jmbg))
                {
                    exists = true;
                }
            }
            return exists;
        }
    }
}
