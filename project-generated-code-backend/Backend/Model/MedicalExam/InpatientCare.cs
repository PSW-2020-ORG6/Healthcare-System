// File:    InpatientCare.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class InpatientCare

using Backend.Model.Util;
using Model.Accounts;
using Newtonsoft.Json;
using System;

namespace Model.MedicalExam
{
    public class InpatientCare : Entity
    {
        public DateTime DateOfAdmission { get; set; }
        public DateTime DateOfDischarge { get; set; }
        public Physitian Physitian { get; set; }
        public Patient Patient { get; set; }

        public InpatientCare(DateTime dateOfAdmition, DateTime dateOfDischarge, Physitian physitian,
            Patient patient) : base()
        {
            DateOfAdmission = dateOfAdmition;
            DateOfDischarge = dateOfDischarge;
            Physitian = physitian;
            Patient = patient;
        }

        [JsonConstructor]
        public InpatientCare(String serialNumber, DateTime dateOfAdmition, DateTime dateOfDischarge,
            Physitian physitian, Patient patient) : base(serialNumber)
        {
            DateOfAdmission = dateOfAdmition;
            DateOfDischarge = dateOfDischarge;
            Physitian = physitian;
            Patient = patient;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is InpatientCare other))
            {
                return false;
            }

            return DateOfAdmission.Equals(other.DateOfAdmission) && DateOfDischarge.Equals(other.DateOfDischarge) &&
                   Patient.Equals(other.Patient) && Physitian.Equals(other.Physitian);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "patient: " + Patient.FullName + "\nphysitian: " + Physitian.FullName + "\ndate of admition:" +
                   DateOfAdmission.ToString("dd.MM.yyyy.") + "\ndate of discharge:" +
                   DateOfDischarge.ToString("dd.MM.yyyy.");
        }
    }
}