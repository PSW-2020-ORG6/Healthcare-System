// File:    FollowUp.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class FollowUp

using Model.Accounts;
using Newtonsoft.Json;
using System;

namespace Model.MedicalExam
{
    public class FollowUp : AdditionalDocument
    {
        public Physitian Physitian { get; set; }

        public FollowUp(DateTime date, string notes, Physitian physitian) : base(date, notes)
        {
            Physitian = physitian;
        }

        [JsonConstructor]
        public FollowUp(string serialNumber, DateTime date, string notes, Physitian physitian) : base(serialNumber,
            date, notes)
        {
            Physitian = physitian;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is FollowUp other))
            {
                return false;
            }

            return base.Equals(obj) && Physitian.Equals(other.Physitian);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString() + "\nphysitian: " + Physitian.FullName;
        }
    }
}