using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Util;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinicBackend.Backend.Model.Hospital
{
    public class Bed : Equipment
    {
        [ForeignKey("Patient")] public string PatientSerialNumber { get; set; }
        public Patient Patient { get; set; }

        public Bed()
        {
        }

        public Bed(string name, string id) : base()
        {
            Name = name;
            Id = id;
        }

        [JsonConstructor]
        public Bed(String serialNumber, string name, string id) : base(serialNumber)
        {
            Name = name;
            Id = id;
        }

        public bool IsOccupied
        {
            get
            {
                if (PatientSerialNumber == null) return false;
                else return true;
            }
        }
    }
}