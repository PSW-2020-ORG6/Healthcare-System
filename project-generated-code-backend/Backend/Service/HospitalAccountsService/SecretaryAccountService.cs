﻿using Backend.Repository;
using Model.Accounts;
using System.Collections.Generic;

namespace HealthClinic.Backend.Service.HospitalAccountsService
{
    public class SecretaryAccountService
    {
        public ISecretaryRepository secretaryRepository;

        public SecretaryAccountService()
        {
            secretaryRepository = new SecretaryFileSystem();
        }

        public List<Secretary> GetAllSecretaries()
        {
            return secretaryRepository.GetAll();
        }

        internal void NewSecretary(Secretary secretary)
        {
            secretaryRepository.Save(secretary);
        }

        internal void EditSecretary(Secretary secretary)
        {
            secretaryRepository.Update(secretary);
        }

        internal void DeleteSecretaryById(string id)
        {
            secretaryRepository.Delete(id);
        }
        public void DeleteSecretary(Secretary secretary)
        {
            secretaryRepository.Delete(secretary.SerialNumber);
        }

        public bool jmbgExists(string jmbg)
        {
            bool exists = false;
            foreach (Secretary p in secretaryRepository.GetAll())
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
