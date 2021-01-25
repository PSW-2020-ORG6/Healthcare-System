using HealthClinicBackend.Backend.Model.Util;
using Newtonsoft.Json;
using System;

namespace HealthClinicBackend.Backend.Model.Accounts
{
    public class Admin : Account
    {

        public Admin() { }
        public Admin(string name, string surname, string id, DateTime dateOfBirth, string contact, string email,
            Address address, string password)
            : base(name, surname, id, dateOfBirth, contact, email, address, password)
        {

        }

        [JsonConstructor]
        public Admin(string serialNumber, string name, string surname, string id, DateTime dateOfBirth, string contact, string email,
        Address address, string password, bool isAdmin = true)
        : base(serialNumber, name, surname, id, dateOfBirth, contact, email, address, password, isAdmin)
        {

        }

    }
}
