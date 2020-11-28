// File:    Account.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Account

using Backend.Model.Util;
using Model.Util;
using System;

namespace Model.Accounts
{
    public abstract class Account : Entity
    {
        protected String name;
        protected String surname;
        protected String id;
        protected DateTime dateOfBirth;
        protected String contact;
        protected String email;
        protected Address address;
        protected String password;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string FullName { get => name + " " + surname; }

        public string Id { get => id; set => id = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string Contact { get => contact; set => contact = value; }
        public string Email { get => email; set => email = value; }
        public virtual Address Address { get => address; set => address = value; }

        public String Password { get => password; }

        public Account(String serialNumber, string name, string surname, string id, DateTime dateOfBirth, string contact, string email, Address address, String password) : base(serialNumber)
        {
            this.name = name;
            this.surname = surname;
            this.id = id;
            this.dateOfBirth = dateOfBirth;
            this.contact = contact;
            this.email = email;
            this.address = address;
            this.password = password;
        }
        public Account(String serialNumber, string name, string surname, string id, DateTime dateOfBirth, string contact, string email) : base(serialNumber)
        {
            this.name = name;
            this.surname = surname;
            this.id = id;
            this.dateOfBirth = dateOfBirth;
            this.contact = contact;
            this.email = email;

        }
        public Account(String serialNumber, string name, string surname, string id) : base(serialNumber)
        {
            this.name = name;
            this.surname = surname;
            this.id = id;
        }
        public Account() { }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Account other = obj as Account;

            if (other == null)
            {
                return false;
            }

            return this.Id.Equals(other.Id);
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}