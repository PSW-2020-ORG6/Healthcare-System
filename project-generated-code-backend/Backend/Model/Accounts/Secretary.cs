// File:    Secretary.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Secretary

using System;
using HealthClinicBackend.Backend.Model.Util;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Model.Accounts
{
    public class Secretary : Account
    {
        public Secretary() : base()
        {
        }

        public Secretary(string name, string surname, string id, DateTime dateOfBirth, string contact, string email,
            Address address, string password)
            : base(name, surname, id, dateOfBirth, contact, email, address, password)
        {
        }

        [JsonConstructor]
        public Secretary(String serialNumber, string name, string surname, string id, DateTime dateOfBirth,
            string contact, string email, Address address, string password)
            : base(serialNumber, name, surname, id, dateOfBirth, contact, email, address, password)
        {
        }
    }
}