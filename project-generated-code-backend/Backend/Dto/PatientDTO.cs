// File:    PatientDTO.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class PatientDTO

using System;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Util;

namespace HealthClinicBackend.Backend.Dto
{
    public class PatientDto
    {
        public PatientDto()
        {
        }

        public PatientDto(Patient patient)
        {
            Id = patient.Id;
            Name = patient.Name;
            Surname = patient.Surname;
            DateOfBirth = patient.DateOfBirth;
            Contact = patient.Contact;
            Email = patient.Email;
            Address = new AddressDto(patient.Address);
            Password = patient.Password;
            ParentName = patient.ParentName;
            PlaceOfBirth = patient.PlaceOfBirth;
            MunicipalityOfBirth = patient.MunicipalityOfBirth;
            StateOfBirth = patient.StateOfBirth;
            PlaceOfResidence = patient.PlaceOfResidence;
            MunicipalityOfResidence = patient.MunicipalityOfResidence;
            StateOfResidence = patient.StateOfResidence;
            Citizenship = patient.Citizenship;
            Nationality = patient.Nationality;
            Profession = patient.Profession;
            EmploymentStatus = patient.EmploymentStatus;
            MaritalStatus = patient.MaritalStatus;
            HealthInsuranceNumber = patient.HealthInsuranceNumber;
            FamilyDiseases = patient.FamilyDiseases;
            PersonalDiseases = patient.PersonalDiseases;
            Gender = patient.Gender;
            Image = patient.Image;
            IsGuest = patient.Guest;
            EmailConfirmed = patient.EmailConfirmed;
            ChosenDoctor = patient.ChosenPhysician;
        }



        public string Name { get; set; }

        public string Surname { get; set; }

        public string Id { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Contact { get; set; }

        public string Email { get; set; }

        public AddressDto Address { get; set; }

        public string Password { get; set; }

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

        public bool IsGuest { get; set; }

        public bool EmailConfirmed { get; set; }

        public string ChosenDoctor { get; set; }

        public bool AreRegistrationFieldsValid()
        {
            return Name != null && Surname != null && ParentName != null && Id != null && DateOfBirth != null &&
                   PlaceOfBirth != null && MunicipalityOfBirth != null && StateOfBirth != null && Nationality != null &&
                   Citizenship != null && Address != null && Address != null && PlaceOfResidence != null &&
                   MunicipalityOfResidence != null && StateOfResidence != null && Profession != null &&
                   EmploymentStatus != null && MaritalStatus != null && Contact != null && Email != null &&
                   Password != null && Gender != null && HealthInsuranceNumber != null;
        }

        public PatientDto ConvertToPatientDTO(Patient patient)
        {
            PatientDto patientDto = new PatientDto(patient);
            return patientDto;
        }
    }
}