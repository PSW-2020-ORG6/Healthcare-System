// File:    SpecialistReferral.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class SpecialistReferral

using Model.Accounts;
using Model.Schedule;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.MedicalExam
{
    public class SpecialistReferral : AdditionalDocument
    {
        [ForeignKey("ProcedureType")] public string ProcedureTypeSerialNumber { get; set; }
        public ProcedureType ProcedureType { get; set; }
        [ForeignKey("Physician")] public string PhysicianSerialNumber { get; set; }
        public Physician Physician { get; set; }

        public SpecialistReferral() : base()
        {
        }

        public SpecialistReferral(DateTime date, string notes, ProcedureType procedureType, Physician physician) :
            base(date, notes)
        {
            ProcedureType = procedureType;
            Physician = physician;
        }

        [JsonConstructor]
        public SpecialistReferral(String serialNumber, DateTime date, string notes, ProcedureType procedureType,
            Physician physician) : base(serialNumber, date, notes)
        {
            ProcedureType = procedureType;
            Physician = physician;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is SpecialistReferral other))
            {
                return false;
            }

            return SerialNumber.Equals(other.SerialNumber);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString() + "\nphysitian: " + Physician.FullName + "\nspecialization: " + ProcedureType;
        }
    }
}