// File:    PatientDTO.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class PatientDTO

using Model.Util;
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
        private Address address;
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
        private bool emailConfirmed;

        public PatientDTO() { }

        public PatientDTO(String serialNumber, String name, String surname, String id, DateTime dateOfBirth, String contact, String email, Address address,
                        String password, String parentName, String placeOfBirth, String municipalityOfBirth, String stateOfBirth, String citizenship, String nationality,
                        String profession, String placeOfResidence, String municipalityOfResidence, String stateOfResidence, String employmentStatus,
                        String maritalStatus, String gender, String healthInsuranceNumber, String familyDiseases, String personalDiseases, String image, bool guest, bool emailConfirmed)
        {
            this.serialNumber = serialNumber;
            this.name = name;
            this.surname = surname;
            this.id = id;
            this.dateOfBirth = dateOfBirth;
            this.contact = contact;
            this.email = email;
            this.address = address;
            this.password = password;
            this.parentName = parentName;
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
            this.gender = gender;
            this.healthInsuranceNumber = healthInsuranceNumber;
            this.familyDiseases = familyDiseases;
            this.personalDiseases = personalDiseases;
            this.image = image;
            this.guest = guest;
            this.emailConfirmed = emailConfirmed;
        }

        public string SerialNumber { get => serialNumber; set => serialNumber = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Id { get => id; set => id = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string Contact { get => contact; set => contact = value; }
        public string Email { get => email; set => email = value; }
        public Address Address { get => address; set => address = value; }
        public string Password { get => password; set => password = value; }
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
        public bool IsGuest { get => guest; set => guest = value; }
        public bool EmailConfirmed { get => emailConfirmed; set => emailConfirmed = value; }

        public bool AreRegistrationFieldsValid()
        {
            if (Name == null || Surname == null || ParentName == null || Id == null || DateOfBirth == null || PlaceOfBirth == null || MunicipalityOfBirth == null ||
                StateOfBirth == null || Nationality == null || Citizenship == null || Address == null || Address == null || PlaceOfResidence == null ||
                MunicipalityOfResidence == null || StateOfResidence == null || Profession == null || EmploymentStatus == null || MaritalStatus == null ||
                Contact == null || Email == null || Password == null || Gender == null || HealthInsuranceNumber == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}