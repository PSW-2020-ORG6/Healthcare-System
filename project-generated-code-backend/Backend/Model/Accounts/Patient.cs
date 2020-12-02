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
        private String placeOfBirth;
        private String municipalityOfBirth;
        private String stateOfBirth;
        private String citizenship;
        private String nationality;
        private String profession;
        private String placeOfResidence;
        private String municipalityOfResidence;
        private String stateOfResidence;
        private String employmentStatus;
        private String maritalStatus;
        private String gender;
        private String healthInsuranceNumber;
        private String familyDiseases;
        private String personalDiseases;
        private String image;
        private bool guest;
        private bool emailConfirmed;

        public Patient(string name, string surname, string id, DateTime dateOfBirth, string contact, string email, Address address, string parentName, string gender, string password, bool isGuest = false)
            : base(Guid.NewGuid().ToString(), name, surname, id, dateOfBirth, contact, email, address, password)
        {
            this.parentName = parentName;
            this.gender = gender;
            this.Guest = isGuest;
            this.password = password;
        }
        [JsonConstructor]
        public Patient(string serialNumber, string name, string surname, string id, DateTime dateOfBirth, string contact, string email, Address address, string parentName, string gender, string password, bool isGuest = false)
            : base(serialNumber, name, surname, id, dateOfBirth, contact, email, address, password)
        {
            this.parentName = parentName;
            this.gender = gender;
            this.Guest = isGuest;
            this.password = password;
        }
        public Patient(string serialNumber, string name, string surname, string id, DateTime dateOfBirth, string contact, string email, Address address, string parentName, string placeOfBirth, string municipalityOfBirth, string stateOfBirth, String citizenship, string nationality, string profession, string placeOfResidence, string municipalityOfResidence, string stateOfResidence, string employmentStatus, string maritalStatus, string healthInsuranceNumber, string familyDiseases, string personalDiseases, string gender, string password, string image, bool isGuest = false)
            : base(serialNumber, name, surname, id, dateOfBirth, contact, email, address, password)
        {
            this.parentName = parentName;
            this.gender = gender;
            this.Guest = isGuest;
            this.password = password;
            this.placeOfBirth = placeOfBirth;
            this.municipalityOfBirth = municipalityOfBirth;
            this.stateOfBirth = stateOfBirth;
            this.citizenship = citizenship;
            this.nationality = nationality;
            this.profession = profession;
            this.placeOfResidence = placeOfResidence;
            this.municipalityOfResidence = municipalityOfResidence;
            this.stateOfResidence = stateOfResidence;
            this.employmentStatus = employmentStatus;
            this.maritalStatus = maritalStatus;
            this.healthInsuranceNumber = healthInsuranceNumber;
            this.familyDiseases = familyDiseases;
            this.personalDiseases = personalDiseases;
            this.image = image;
        }

        [JsonConstructor]
        public Patient(PatientDTO patientDTO) : base(Guid.NewGuid().ToString(), patientDTO.Name, patientDTO.Surname, patientDTO.Id, patientDTO.DateOfBirth, patientDTO.Contact, patientDTO.Email, patientDTO.Address/*new Address { Street = patientDTO.Address }*/, patientDTO.Password)
        {
            this.parentName = patientDTO.ParentName;
            this.gender = patientDTO.Gender;
            this.password = patientDTO.Password;
            this.placeOfBirth = patientDTO.PlaceOfBirth;
            this.municipalityOfBirth = patientDTO.MunicipalityOfBirth;
            this.stateOfBirth = patientDTO.StateOfBirth;
            this.citizenship = patientDTO.Citizenship;
            this.nationality = patientDTO.Nationality;
            this.profession = patientDTO.Profession;
            this.placeOfResidence = patientDTO.PlaceOfResidence;
            this.municipalityOfResidence = patientDTO.MunicipalityOfResidence;
            this.stateOfResidence = patientDTO.StateOfResidence;
            this.employmentStatus = patientDTO.EmploymentStatus;
            this.maritalStatus = patientDTO.MaritalStatus;
            this.healthInsuranceNumber = patientDTO.HealthInsuranceNumber;
            this.familyDiseases = patientDTO.FamilyDiseases;
            this.personalDiseases = patientDTO.PersonalDiseases;
            this.image = patientDTO.Image;
            this.guest = patientDTO.IsGuest;
            this.emailConfirmed = patientDTO.EmailConfirmed;
        }
        public Patient() : base() { }
        public Patient(string serialNumber, string name, string surname) : base() { }

        public string ParentName { get => parentName; set => parentName = value; }
        public string PlaceOfBirth { get => placeOfBirth; set => placeOfBirth = value; }
        public string MunicipalityOfBirth { get => municipalityOfBirth; set => municipalityOfBirth = value; }
        public string StateOfBirth { get => stateOfBirth; set => stateOfBirth = value; }
        public string PlaceOfResidence { get => placeOfResidence; set => placeOfResidence = value; }
        public string MunicipalityOfResidence { get => municipalityOfResidence; set => municipalityOfResidence = value; }
        public string StateOfResidence { get => stateOfResidence; set => stateOfResidence = value; }
        public string Citizenship { get => citizenship; set => citizenship = value; }
        public string Nationality { get => nationality; set => nationality = value; }
        public string Profession { get => profession; set => profession = value; }
        public string EmploymentStatus { get => employmentStatus; set => employmentStatus = value; }
        public string MaritalStatus { get => maritalStatus; set => maritalStatus = value; }
        public string HealthInsuranceNumber { get => healthInsuranceNumber; set => healthInsuranceNumber = value; }
        public string FamilyDiseases { get => familyDiseases; set => familyDiseases = value; }
        public string PersonalDiseases { get => personalDiseases; set => personalDiseases = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Image { get => image; set => image = value; }
        public bool Guest { get => guest; set => guest = value; }
        public bool EmailConfirmed { get => emailConfirmed; set => emailConfirmed = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }

}