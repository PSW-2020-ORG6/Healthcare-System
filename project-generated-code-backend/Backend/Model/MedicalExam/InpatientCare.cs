// File:    InpatientCare.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class InpatientCare

using System;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Util;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Model.MedicalExam
{
    public class InpatientCare : Entity
    {
        public DateTime DateOfAdmission { get; set; }
        public DateTime DateOfDischarge { get; set; }
        public Physician Physician { get; set; }
        public Patient Patient { get; set; }

        public InpatientCare(DateTime dateOfAdmition, DateTime dateOfDischarge, Physician physician,
            Patient patient) : base()
        {
            DateOfAdmission = dateOfAdmition;
            DateOfDischarge = dateOfDischarge;
            Physician = physician;
            Patient = patient;
        }

        [JsonConstructor]
        public InpatientCare(String serialNumber, DateTime dateOfAdmition, DateTime dateOfDischarge,
            Physician physician, Patient patient) : base(serialNumber)
        {
            DateOfAdmission = dateOfAdmition;
            DateOfDischarge = dateOfDischarge;
            Physician = physician;
            Patient = patient;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is InpatientCare other))
            {
                return false;
            }

            return DateOfAdmission.Equals(other.DateOfAdmission) && DateOfDischarge.Equals(other.DateOfDischarge) &&
                   Patient.Equals(other.Patient) && Physician.Equals(other.Physician);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "patient: " + Patient.Name + " " + Patient.Surname + "\nphysitian: " + Physician.Name + " " + Physician.Surname + "\ndate of admition:" +
                   DateOfAdmission.ToString("dd.MM.yyyy.") + "\ndate of discharge:" +
                   DateOfDischarge.ToString("dd.MM.yyyy.");
        }
    }
}