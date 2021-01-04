// File:    Patient.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Patient

using System;
using System.ComponentModel.DataAnnotations.Schema;
using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Util;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Model.Accounts
{
    public class Patient : Account
    {
        public string ParentName { get; set; }
        public string PlaceOfBirth { get; set; }
        public string MunicipalityOfBirth { get; set; }
        public string StateOfBirth { get; set; }
        public string PlaceOfResidence { get; set; }
        public string MunicipalityOfResidence { get; set; }
        public string StateOfResidence { get; set; }
        public string Citizenship { get; set; }
        public string Nationality { get; set; }
        public string Profession { get; set; }
        public string EmploymentStatus { get; set; }
        public string MaritalStatus { get; set; }
        public string HealthInsuranceNumber { get; set; }
        public string FamilyDiseases { get; set; }
        public string PersonalDiseases { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }
        public bool Guest { get; set; }
        public bool IsMalicious { get; set; }
        public bool IsBlocked { get; set; }
        public bool EmailConfirmed { get; set; }
        [ForeignKey("Physician")] public string PhysicianSerialNumber { get; set; }
        public String ChosenPhysician { get; set; }

        public Patient() : base()
        {
        }

        public Patient(string serialNumber, string name, string surname) : base(serialNumber, name, surname)
        {
        }

        public Patient(string name, string surname, string id, DateTime dateOfBirth, string contact, string email,
            Address address, string parentName, string gender, string password, bool isGuest = false)
            : base(name, surname, id, dateOfBirth, contact, email, address, password)
        {
            ParentName = parentName;
            Gender = gender;
            Guest = isGuest;
            Password = password;
        }

        [JsonConstructor]
        public Patient(string serialNumber, string name, string surname, string id, DateTime dateOfBirth,
            string contact, string email, Address address, string parentName, string gender, string password,
            bool isGuest = false)
            : base(serialNumber, name, surname, id, dateOfBirth, contact, email, address, password)
        {
            ParentName = parentName;
            Gender = gender;
            Guest = isGuest;
            Password = password;
        }

        public Patient(string serialNumber, string name, string surname, string id, DateTime dateOfBirth,
            string contact, string email, Address address, string parentName, string placeOfBirth,
            string municipalityOfBirth, string stateOfBirth, String citizenship, string nationality, string profession,
            string placeOfResidence, string municipalityOfResidence, string stateOfResidence, string employmentStatus,
            string maritalStatus, string healthInsuranceNumber, string familyDiseases, string personalDiseases,
            string gender, string password, string image, bool isGuest = false)
            : base(serialNumber, name, surname, id, dateOfBirth, contact, email, address, password)
        {
            ParentName = parentName;
            Gender = gender;
            Guest = isGuest;
            Password = password;
            PlaceOfBirth = placeOfBirth;
            MunicipalityOfBirth = municipalityOfBirth;
            StateOfBirth = stateOfBirth;
            Citizenship = citizenship;
            Nationality = nationality;
            Profession = profession;
            PlaceOfResidence = placeOfResidence;
            MunicipalityOfResidence = municipalityOfResidence;
            StateOfResidence = stateOfResidence;
            EmploymentStatus = employmentStatus;
            MaritalStatus = maritalStatus;
            HealthInsuranceNumber = healthInsuranceNumber;
            FamilyDiseases = familyDiseases;
            PersonalDiseases = personalDiseases;
            Image = image;
        }

        public Patient(PatientDto patientDto) : base(patientDto.Name, patientDto.Surname, patientDto.Id,
            patientDto.DateOfBirth, patientDto.Contact, patientDto.Email,
            new Address(patientDto.Address), patientDto.Password)
        {
            ParentName = patientDto.ParentName;
            Gender = patientDto.Gender;
            Password = patientDto.Password;
            PlaceOfBirth = patientDto.PlaceOfBirth;
            MunicipalityOfBirth = patientDto.MunicipalityOfBirth;
            StateOfBirth = patientDto.StateOfBirth;
            Citizenship = patientDto.Citizenship;
            Nationality = patientDto.Nationality;
            Profession = patientDto.Profession;
            PlaceOfResidence = patientDto.PlaceOfResidence;
            MunicipalityOfResidence = patientDto.MunicipalityOfResidence;
            StateOfResidence = patientDto.StateOfResidence;
            EmploymentStatus = patientDto.EmploymentStatus;
            MaritalStatus = patientDto.MaritalStatus;
            HealthInsuranceNumber = patientDto.HealthInsuranceNumber;
            FamilyDiseases = patientDto.FamilyDiseases;
            PersonalDiseases = patientDto.PersonalDiseases;
            Image = patientDto.Image;
            Guest = patientDto.IsGuest;
            EmailConfirmed = patientDto.EmailConfirmed;
            ChosenPhysician = patientDto.ChosenDoctor;
        }
    }
}