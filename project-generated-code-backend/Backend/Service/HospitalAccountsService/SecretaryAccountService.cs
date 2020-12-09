using System.Collections.Generic;
using System.Linq;
using Backend.Repository;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using Model.Accounts;

namespace HealthClinicBackend.Backend.Service.HospitalAccountsService
{
    public class SecretaryAccountService
    {
        private readonly ISecretaryRepository _secretaryRepository;

        public SecretaryAccountService()
        {
            _secretaryRepository = new SecretaryDatabaseSql();
        }

        public List<Secretary> GetAllSecretaries()
        {
            return _secretaryRepository.GetAll();
        }

        internal void NewSecretary(Secretary secretary)
        {
            _secretaryRepository.Save(secretary);
        }

        internal void EditSecretary(Secretary secretary)
        {
            _secretaryRepository.Update(secretary);
        }

        internal void DeleteSecretaryById(string id)
        {
            _secretaryRepository.Delete(id);
        }

        public void DeleteSecretary(Secretary secretary)
        {
            _secretaryRepository.Delete(secretary.SerialNumber);
        }

        public bool jmbgExists(string jmbg)
        {
            return _secretaryRepository.GetAll().Any(p => p.Id.Equals(jmbg));
        }
    }
}