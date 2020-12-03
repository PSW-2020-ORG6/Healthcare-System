// File:    SpecialistReferral.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class SpecialistReferral

using Model.Accounts;
using Model.Schedule;
using Newtonsoft.Json;
using System;

namespace Model.MedicalExam
{
    public class SpecialistReferral : AdditionalDocument
    {
        public ProcedureType ProcedureType { get; set; }
        public Physitian Physitian { get; set; }

        public SpecialistReferral(DateTime date, string notes, ProcedureType procedureType, Physitian physitian) :
            base(date, notes)
        {
            ProcedureType = procedureType;
            Physitian = physitian;
        }

        [JsonConstructor]
        public SpecialistReferral(String serialNumber, DateTime date, string notes, ProcedureType procedureType,
            Physitian physitian) : base(serialNumber, date, notes)
        {
            ProcedureType = procedureType;
            Physitian = physitian;
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
            return base.ToString() + "\nphysitian: " + Physitian.FullName + "\nspecialization: " + ProcedureType;
        }
    }
}