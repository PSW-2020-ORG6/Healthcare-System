using MicroServiceAccount.Backend.Model.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServiceAccount.Backend.Model
{
    public class Admin : Account
    {

        public Admin() { }
        public Admin(string name, string surname, string id, DateTime dateOfBirth, string contact, string email,
            Address address, string password)
            : base(name, surname, id, dateOfBirth, contact, email, address, password)
        {

        }
        public Admin(String serialNumber, string email, string password, bool isAdmin)
        {
            SerialNumber = serialNumber;
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
        }
        [JsonConstructor]
        public Admin(string serialNumber, string name, string surname, string id, DateTime dateOfBirth, string contact, string email,
            Address address, string password)
            : base(serialNumber, name, surname, id, dateOfBirth, contact, email, address, password)
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
