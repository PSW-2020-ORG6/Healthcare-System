// File:    DiagnosticReferral.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class DiagnosticReferral

using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Model.MedicalExam
{
    public class DiagnosticReferral : AdditionalDocument
    {
        [ForeignKey("DiagnosticType")] public string DiagnosticTypeSerialNumber { get; set; }
        public DiagnosticType DiagnosticType { get; set; }

        public DiagnosticReferral() : base()
        {
        }

        public DiagnosticReferral(DateTime date, string notes, DiagnosticType diagnosticType) : base(
            Guid.NewGuid().ToString(), date, notes)
        {
            DiagnosticType = diagnosticType;
        }

        [JsonConstructor]
        public DiagnosticReferral(String serialNumber, DateTime date, string notes, DiagnosticType diagnosticType) :
            base(serialNumber, date, notes)
        {
            DiagnosticType = diagnosticType;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is DiagnosticReferral other))
            {
                return false;
            }

            return base.Equals(other) && DiagnosticType.Equals(other.DiagnosticType);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString() + "\ndiagnostic type: " + DiagnosticType;
        }
    }
}