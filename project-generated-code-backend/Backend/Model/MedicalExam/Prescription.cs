// File:    Prescription.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Prescription

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Model.MedicalExam
{
    public class Prescription : AdditionalDocument
    {
        public virtual List<MedicineDosage> MedicineDosage { get; set; }

        public Prescription() : base()
        {
        }

        public Prescription(DateTime date, string notes) : base(date, notes)
        {
            MedicineDosage = new List<MedicineDosage>();
        }

        [JsonConstructor]
        public Prescription(String serialNumber, DateTime date, string notes) : base(serialNumber, date, notes)
        {
            MedicineDosage = new List<MedicineDosage>();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Prescription other))
            {
                return false;
            }

            if (MedicineDosage.Count != other.MedicineDosage.Count)
            {
                return false;
            }

            return MedicineDosage.All(m => other.MedicineDosage.Contains(m)) && base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            var ret = base.ToString();
            return MedicineDosage.Aggregate(ret, (current, m) => current + ("\nmedicine dosage: " + m.ToString()));
        }
    }
}