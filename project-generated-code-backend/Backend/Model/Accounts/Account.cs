// File:    Account.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Account

using System;
using System.ComponentModel.DataAnnotations.Schema;
using HealthClinicBackend.Backend.Model.Util;

namespace HealthClinicBackend.Backend.Model.Accounts
{
    public abstract class Account : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        [ForeignKey("Address")] public string AddressSerialNumber { get; set; }
        public virtual Address Address { get; set; }
        public String Password { get; set; }
        public Account(String serialNumber, string name, string surname, string id, DateTime dateOfBirth,
            string contact, string email, Address address, String password) : base(serialNumber)
        {
            Name = name;
            Surname = surname;
            Id = id;
            DateOfBirth = dateOfBirth;
            Contact = contact;
            Email = email;
            Address = address;
            Password = password;
        }

        public Account(string name, string surname, string id, DateTime dateOfBirth,
            string contact, string email, Address address, String password) : base()
        {
            Name = name;
            Surname = surname;
            Id = id;
            DateOfBirth = dateOfBirth;
            Contact = contact;
            Email = email;
            Address = address;
            Password = password;
        }

        public Account(String serialNumber, string name, string surname, string id, DateTime dateOfBirth,
            string contact, string email) : base(serialNumber)
        {
            Name = name;
            Surname = surname;
            Id = id;
            DateOfBirth = dateOfBirth;
            Contact = contact;
            Email = email;
        }

        public Account(String serialNumber, string name, string surname, string id) : base(serialNumber)
        {
            Name = name;
            Surname = surname;
            Id = id;
        }

        public Account(string name, string surname) : base()
        {
            Name = name;
            Surname = surname;
        }

        public Account(string serialNumber, string name, string surname) : base(serialNumber)
        {
            Name = name;
            Surname = surname;
        }

        public Account() : base()
        {
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Account other = obj as Account;
            return other != null && Id.Equals(other.Id);
        }

        public bool AreCredentialsValid(string id, string password)
        {
            return Id.Equals(id) && Password.Equals(password);
        }
    }
}