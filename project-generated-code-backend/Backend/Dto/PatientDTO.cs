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
        private String serialNumber;
        private String name;
        private String surname;
        private String id;
        private DateTime dateOfBirth;
        private String contact;
        private String email;
        private String address;
        private String password;
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

        public PatientDTO() { }

        //public string SerialNumber { get => serialNumber; set => serialNumber = value; }
        //public string Name { get => name; set => name = value; }
        //public string Surname { get => surname; set => surname = value; }
        //public string ParentName { get => parentName; set => parentName = value; }
        //public string Id { get => id; set => id = value; }
        //public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        //public string PlaceOfBirth { get => placeOfBirth; set => placeOfBirth = value; }
        //public string MunicipalityOfBirth { get => municipalityOfBirth; set => municipalityOfBirth = value; }
        //public string StateOfBirth { get => stateOfBirth; set => stateOfBirth = value; }
        //public string Nationality { get => nationality; set => nationality = value; }
        //public string Citizenship { get => citizenship; set => citizenship = value; }
        //public string Address { get => address; set => address = value; }
        //public string PlaceOfResidence { get => placeOfResidence; set => placeOfResidence = value; }
        //public string MunicipalityOfResidence { get => municipalityOfResidence; set => municipalityOfResidence = value; }
        //public string StateOfResidence { get => stateOfResidence; set => stateOfResidence = value; }
        //public string Profession { get => profession; set => profession = value; }
        //public string EmploymentStatus { get => employmentStatus; set => employmentStatus = value; }
        //public string MaritalStatus { get => maritalStatus; set => maritalStatus = value; }
        //public string Contact { get => contact; set => contact = value; }
        //public string Email { get => email; set => email = value; }
        //public string Password { get => password; set => password = value; }
        //public string Gender { get => gender; set => gender = value; }
        //public int HealthInsuranceNumber { get => healthInsuranceNumber; set => healthInsuranceNumber = value; }
        //public string FamilyDiseases { get => familyDiseases; set => familyDiseases = value; }
        //public string PersonalDiseases { get => personalDiseases; set => personalDiseases = value; }
        //public string Image { get => image; set => image = value; }
        //public bool Guest { get => guest; set => guest = value; }

        public string SerialNumber { get => serialNumber; set => serialNumber = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Id { get => id; set => id = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string Contact { get => contact; set => contact = value; }
        public string Email { get => email; set => email = value; }
        public string Address { get => address; set => address = value; }
        public String Password { get => password; set => password = value; }
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

        public bool IsCorrectName()
        {
            if (Name == null)
                return false;
            return true;
        }

        public bool IsCorrectSurname()
        {
            if (Surname == null)
                return false;
            return true;
        }
        public bool IsCorrectParentName()
        {
            if (ParentName == null)
                return false;
            return true;
        }
        public bool IsCorrectId()
        {
            if (Id == null)
                return false;
            return true;
        }
        public bool IsCorrectDateOfBirth()
        {
            if (DateOfBirth == null)
                return false;
            return true;
        }
        public bool IsCorrectPlaceOfBirth()
        {
            if (PlaceOfBirth == null)
                return false;
            return true;
        }
        public bool IsCorrectMunicipalityOfBirth()
        {
            if (MunicipalityOfBirth == null)
                return false;
            return true;
        }
        public bool IsCorrectStateOfBirth()
        {
            if (StateOfBirth == null)
                return false;
            return true;
        }
        public bool IsCorrectNationality()
        {
            if (Nationality == null)
                return false;
            return true;
        }
        public bool IsCorrectCitizenship()
        {
            if (Citizenship == null)
                return false;
            return true;
        }
        public bool IsCorrectAddress()
        {
            if (Address == null)
                return false;
            return true;
        }
        public bool IsCorrectPlaceOfResidence()
        {
            if (PlaceOfResidence == null)
                return false;
            return true;
        }
        public bool IsCorrectMunicipalityOfResidence()
        {
            if (MunicipalityOfResidence == null)
                return false;
            return true;
        }
        public bool IsCorrectStateOfResidence()
        {
            if (StateOfResidence == null)
                return false;
            return true;
        }
        public bool IsCorrectProfession()
        {
            if (Profession == null)
                return false;
            return true;
        }
        public bool IsCorrectEmploymentStatus()
        {
            if (EmploymentStatus == null)
                return false;
            return true;
        }
        public bool IsCorrectMaritalStatus()
        {
            if (MaritalStatus == null)
                return false;
            return true;
        }
        public bool IsCorrectContact()
        {
            if (Contact == null)
                return false;
            return true;
        }
        public bool IsCorrectEmail()
        {
            if (Email == null)
                return false;
            return true;
        }
        public bool IsCorrectPassword()
        {
            if (Password == null)
                return false;
            return true;
        }
        public bool IsCorrectGender()
        {
            if (Gender == null)
                return false;
            return true;
        }
        public bool IsCorrectHealthInsuranceNumber()
        {
            if (HealthInsuranceNumber == null)
                return false;
            return true;
        }
        public bool IsCorrectFamilyDiseases()
        {
            if (FamilyDiseases == null)
                return false;
            return true;
        }
        public bool IsCorrectPersonalDiseases()
        {
            if (PersonalDiseases == null)
                return false;
            return true;
        }
    }
}