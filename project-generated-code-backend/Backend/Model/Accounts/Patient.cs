// File:    Patient.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Patient

using Backend.Dto;
using Model.Util;
using Newtonsoft.Json;
using System;

namespace Model.Accounts
{
    public class Patient : Account
    {

        private String parentName;
        private String gender;
        private bool guest;

        public Patient(string name, string surname, string id, DateTime dateOfBirth, string contact, string email, Address address, string parentName, string gender, string password, bool isGuest = false)
            : base(Guid.NewGuid().ToString(), name, surname, id, dateOfBirth, contact, email, address,password)
        {
            this.parentName = parentName;
            this.gender = gender;
            this.Guest = isGuest;
        }

        [JsonConstructor]
        public Patient(string serialNumber, string name, string surname, string id, DateTime dateOfBirth, string contact, string email, Address address, string parentName, string gender, string password, bool isGuest = false)
            : base(serialNumber, name, surname, id, dateOfBirth, contact, email, address,password)
        {
            this.parentName = parentName;
            this.gender = gender;
            this.Guest = isGuest;
        }

        public Patient(PatientDTO patientDTO) : base(Guid.NewGuid().ToString(), patientDTO.Name, patientDTO.Surname, patientDTO.Id, patientDTO.DateOfBirth, patientDTO.Contact, patientDTO.Email, patientDTO.Address,patientDTO.Password)
        {
            this.parentName = patientDTO.ParentName;
            this.gender = patientDTO.Gender;
            this.Guest = patientDTO.IsGuest;
            Console.WriteLine(Guest);
        }

        public string ParentName { get => parentName; }
        public string Gender { get => gender; }
        public bool Guest { get => guest; set => guest = value; }

        public override string ToString()
        {
            return base.ToString();
        }

    }

}