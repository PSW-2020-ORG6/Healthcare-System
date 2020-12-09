// File:    AdditionalDocument.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class AdditionalDocument

using System;
using HealthClinicBackend.Backend.Model.Util;

namespace HealthClinicBackend.Backend.Model.MedicalExam
{
    public abstract class AdditionalDocument : Entity
    {
        public DateTime Date { get; set; }
        public string Notes { get; set; }

        protected AdditionalDocument() : base()
        {
        }

        protected AdditionalDocument(String serialNumber) : base(serialNumber)
        {
        }

        protected AdditionalDocument(DateTime date, string notes) : base()
        {
            Date = date;
            Notes = notes;
        }

        protected AdditionalDocument(String serialNumber, DateTime date, string notes) : base(serialNumber)
        {
            Date = date;
            Notes = notes;
        }

        public override bool Equals(object obj)
        {
            return obj is AdditionalDocument other && SerialNumber.Equals(other.SerialNumber);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "date: " + Date.ToString("dd.MM.yyyy.") + "\nnotes: " + Notes;
        }
    }
}