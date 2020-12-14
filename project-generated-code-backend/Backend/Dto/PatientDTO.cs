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
    

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Id { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Contact { get; set; }

        public string Email { get; set; }

        public Address Address { get; set; }

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
    }
}