﻿using Model.Accounts;
using Model.Util;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys.Interfaces
{
    public interface IPatientRepository
    {
        List<Patient> GetAllPatients();
        Patient GetPatientById(string id);
        List<Address> GetAddresses(string sqlDml);
        Address GetAddress(string adressId);
        Patient GetPatientBySerialNumber(string serialNumber);
    }
}
