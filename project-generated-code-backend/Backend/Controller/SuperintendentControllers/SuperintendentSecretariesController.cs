﻿using System.Collections.Generic;
using HealthClinicBackend.Backend.Service.HospitalAccountsService;
using Model.Accounts;

namespace HealthClinicBackend.Backend.Controller.SuperintendentControllers
{
    public class SuperintendentSecretariesController
    {
        private readonly SecretaryAccountService _secretaryService;

        public SuperintendentSecretariesController()
        {
            _secretaryService = new SecretaryAccountService();
        }

        public List<Secretary> GetAllSecretaries()
        {
            return _secretaryService.GetAllSecretaries();
        }
        public void NewSecretary(Secretary secretary)
        {
            _secretaryService.NewSecretary(secretary);
        }

        public void EditSecretary(Secretary secretary)
        {
            _secretaryService.EditSecretary(secretary);
        }

        public void DeleteSecretary(Secretary secretary)
        {
            _secretaryService.DeleteSecretary(secretary);
        }

        public bool JmbgExists(string jmbg)
        {
            return _secretaryService.jmbgExists(jmbg);
        }
    }
}
