// File:    Report.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Report

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Model.Util;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Model.MedicalExam
{
    public class Report : Entity
    {
        [NotMapped] public virtual List<AdditionalDocument> AdditionalDocument { get; set; }
        public DateTime Date { get; set; }
        public string Findings { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Physician Physician { get; set; }
        public string PatientConditions { get; set; }
        public virtual ProcedureType ProcedureType { get; set; }
        public String PatientName { get; set; }
        public String PhysitianName { get; set; }
        public string PatientId { get; set; }

        public Report() : base()
        {
        }

        public Report(String patient, String physitian, String patientId) : base()
        {
            PatientName = patient;
            PhysitianName = physitian;
            PatientId = patientId;
        }

        public Report(DateTime date, string findings, Patient patient, Physician physician, string patientConditions) :
            base()
        {
            Date = date;
            Findings = findings;
            Patient = patient;
            Physician = physician;
            PatientConditions = patientConditions;
        }

        [JsonConstructor]
        public Report(String serialNumber, DateTime date, string findings, Patient patient, Physician physician,
            string patientConditions) : base(serialNumber)
        {
            Date = date;
            Findings = findings;
            Patient = patient;
            Physician = physician;
            PatientConditions = patientConditions;
        }

        public void AddAdditionalDocument(AdditionalDocument newAdditionalDocument)
        {
            if (newAdditionalDocument == null)
                return;
            AdditionalDocument ??= new List<AdditionalDocument>();
            if (!AdditionalDocument.Contains(newAdditionalDocument))
                AdditionalDocument.Add(newAdditionalDocument);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Report other))
            {
                return false;
            }

            if (AdditionalDocument.Count != other.AdditionalDocument.Count)
            {
                return false;
            }

            if (AdditionalDocument.Any(doc => !other.AdditionalDocument.Contains(doc)))
            {
                return false;
            }

            return Date.Equals(other.Date) && Findings.Equals(other.Findings);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            var ret = "date: " + Date.ToString("dd.MM.yyyy.") + "\nfindings: " + Findings;
            return AdditionalDocument.Aggregate(ret, (current, doc) => current + ("\ndocument: " + doc));
        }

        public int CompareTo(Report other)
        {
            return Date.CompareTo(other.Date);
        }
    }
}