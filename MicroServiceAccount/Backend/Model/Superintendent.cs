// File:    Superintendent.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Superintendent

using System;
using MicroServiceAccount.Backend.Model.Util;
using Newtonsoft.Json;

namespace MicroServiceAccount.Backend.Model.Accounts
{
    public class Superintendent : Account
    {

        public Superintendent(string name, string surname, string id, DateTime dateOfBirth, string contact, string email, Address address, string password)
            : base(name, surname, id, dateOfBirth, contact, email, address, password)
        {

        }

        [JsonConstructor]
        public Superintendent(String serialNumber, string name, string surname, string id, DateTime dateOfBirth, string contact, string email, Address address, string password)
            : base(serialNumber, name, surname, id, dateOfBirth, contact, email, address, password)
        {

        }
    }
}