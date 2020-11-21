// File:    PatientDTO.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class PatientDTO

//using Model.Util;
using System;

namespace Backend.Dto
{
    public class PatientDTO
    {
        private String name;
        private String surname;
        private String parentName;
        private String id;
        private DateTime dateOfBirth;
        private String placeOfBirth;
        private String municipalityOfBirth;
        private String stateOfBirth;
        private String nationality;
        private String citizenship;
        private String address;
        private String placeOfResidence;
        private String municipalityOfResidence;
        private String stateOfResidence;
        private String profession;
        private String employmentStatus;
        private String maritalStatus;
        private String contact;
        private String email;
        private String gender;
        private int healthInsuranceNumber;
        private String familyDiseases;
        private String personalDiseases;
        private string password;
        private bool isGuest;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string ParentName { get => parentName; set => parentName = value; }
        public string Id { get => id; set => id = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string PlaceOfBirth { get => placeOfBirth; set => placeOfBirth = value; }
        public string MunicipalityOfBirth { get => municipalityOfBirth; set => municipalityOfBirth = value; }
        public string StateOfBirth { get => stateOfBirth; set => stateOfBirth = value; }
        public string Nationality { get => nationality; set => nationality = value; }
        public string Citizenship { get => citizenship; set => citizenship = value; }
        public string Addresss { get => address; set => address = value; }
        public string PlaceOfResidence { get => placeOfResidence; set => placeOfResidence = value; }
        public string MunicipalityOfResidence { get => municipalityOfResidence; set => municipalityOfResidence = value; }
        public string StateOfResidence { get => stateOfResidence; set => stateOfResidence = value; }
        public string Profession { get => profession; set => profession = value; }
        public string EmploymentStatus { get => employmentStatus; set => employmentStatus = value; }
        public string MaritalStatus { get => maritalStatus; set => maritalStatus = value; }
        public string Contact { get => contact; set => contact = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Gender { get => gender; set => gender = value; }
        public int HealthInsuranceNumber { get => healthInsuranceNumber; set => healthInsuranceNumber = value; }
        public string FamilyDiseases { get => familyDiseases; set => familyDiseases = value; }
        public string PersonalDiseases { get => personalDiseases; set => personalDiseases = value; }
        public bool IsGuest { get => isGuest; set => isGuest = value; }
    }
}