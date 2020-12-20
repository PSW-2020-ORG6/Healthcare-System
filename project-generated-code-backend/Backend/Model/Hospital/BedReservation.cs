// File:    BedReservation.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class BedReservation

using System;
using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Util;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Model.Hospital
{
    public class BedReservation : Entity
    {
        public Bed Bed { get; set; }

        public Patient Patient { get; set; }

        public TimeInterval TimeInterval { get; set; }

        public BedReservation()
        {
        }

        public BedReservation(TimeInterval timeInterval, Patient patient, Bed bed) : base()
        {
            TimeInterval = timeInterval;
            Patient = patient;
            Bed = bed;
        }

        [JsonConstructor]
        public BedReservation(String serialNumber, TimeInterval timeInterval, Patient patient, Bed bed) : base(
            serialNumber)
        {
            TimeInterval = timeInterval;
            Patient = patient;
            Bed = bed;
        }

        public BedReservation(BedReservationDto bedReservationDto) : base()
        {
            TimeInterval = bedReservationDto.TimeInterval;
            Patient = bedReservationDto.Patient;
            Bed = bedReservationDto.Bed;
        }

        public override bool Equals(object obj)
        {
            BedReservation other = obj as BedReservation;

            if (other == null)
            {
                return false;
            }

            return this.Patient.Equals(other.Patient) && this.TimeInterval.Equals(other.TimeInterval)
                                                      && this.Bed.Equals(other.Bed);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "patient: " + Patient.Name + " " + Patient.Surname + "\nbed: " + Bed + "\ntime interval: " + TimeInterval;
        }
    }
}