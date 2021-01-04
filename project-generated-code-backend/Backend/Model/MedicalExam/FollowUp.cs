// File:    FollowUp.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class FollowUp

using System;
using System.ComponentModel.DataAnnotations.Schema;
using HealthClinicBackend.Backend.Model.Accounts;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Model.MedicalExam
{
    public class FollowUp : AdditionalDocument
    {
        [ForeignKey("Physician")] public string PhysicianSerialNumber { get; set; }
        public Physician Physician { get; set; }

        public FollowUp() : base()
        {
        }

        public FollowUp(DateTime date, string notes, Physician physician) : base(date, notes)
        {
            Physician = physician;
        }

        [JsonConstructor]
        public FollowUp(string serialNumber, DateTime date, string notes, Physician physician) : base(serialNumber,
            date, notes)
        {
            Physician = physician;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is FollowUp other))
            {
                return false;
            }

            return base.Equals(obj) && Physician.Equals(other.Physician);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString() + "\nphysitian: " + Physician.Name + " " + Physician.Surname;
        }
    }
}