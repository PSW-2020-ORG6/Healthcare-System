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
        private String address;
        private String placeOfResidence;
        private String municipalityOfResidence;
        private String stateOfResidence;
        //private String education;
        private String employmentStatus;
        private String maritalStatus;
        private String gender;
        private int healthInsuranceNumber;
        private String familyDiseases;
        private String personalDiseases;
        private String image;
        private bool guest;
        private string password;

        public Patient(string name, string surname, string id, DateTime dateOfBirth, string contact, string email, String address, string parentName, string gender, string password, bool isGuest = false)
            : base(Guid.NewGuid().ToString(), name, surname, id, dateOfBirth, contact, email, address, password)
        {
            this.parentName = parentName;
            this.gender = gender;
            this.Guest = isGuest;
            this.password = password;
        }
        [JsonConstructor]
        public Patient(string serialNumber, string name, string surname, string id, DateTime dateOfBirth, string contact, string email, String address, string parentName, string gender, string password, bool isGuest = false)
            : base(serialNumber, name, surname, id, dateOfBirth, contact, email, address, password)
        {
            this.parentName = parentName;
            this.gender = gender;
            this.Guest = isGuest;
            this.password = password;
        }
        [JsonConstructor]
        public Patient(PatientDTO patientDTO) : base(Guid.NewGuid().ToString(), patientDTO.Name, patientDTO.Surname, patientDTO.Id, patientDTO.DateOfBirth, patientDTO.Contact, patientDTO.Email, patientDTO.Addresss, patientDTO.Password)
        {
            this.parentName = patientDTO.ParentName;
            this.gender = patientDTO.Gender;
            //this.Guest = patientDTO.IsGuest;
            this.password = patientDTO.Password;
            Console.WriteLine(Guest);
        }


        public Patient(string serialNumber, string name, string surname, string id, DateTime dateOfBirth, string contact, string email, string address, string parentName, string placeOfBirth, string municipalityOfBirth, string stateOfBirth, String citizenship, string nationality, string profession, string placeOfResidence, string municipalityOfResidence, string stateOfResidence, string employmentStatus, string maritalStatus,int healthInsuranceNumber,string familyDiseases, string personalDiseases, string gender, string password, string image, bool isGuest = false)
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
        public Patient() : base(Guid.NewGuid().ToString()) { }
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
        public int HealthInsuranceNumber { get => healthInsuranceNumber; set => healthInsuranceNumber = value; }
        public string FamilyDiseases { get => familyDiseases; set => familyDiseases = value; }
        public string PersonalDiseases { get => personalDiseases; set => personalDiseases = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Image { get => image; set => image = value; }
        public bool Guest { get => guest; set => guest = value; }
        public string Password { get => password; set => password = value; }

        public override string ToString()
        {
            return base.ToString();
        }

    }

}