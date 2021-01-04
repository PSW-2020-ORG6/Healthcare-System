// File:    Physitian.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Physitian

#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using HealthClinicBackend.Backend.Model.Util;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Model.Accounts
{
    public class Physician : Account
    {
        
        private Specialization specialization;

        public virtual TimeInterval WorkSchedule { get; set; }
        public virtual List<TimeInterval> VacationTime { get; set; }
        [NotMapped] public virtual List<Specialization> Specialization { get; set; }
        
        public String AllSpecializations
        {
            get { return Specialization.Aggregate("", (current, s) => current + (s + ", ")); }
        }
        
        public Physician() : base()
        {
        }

        public Physician(string name, string surname, string id)
            : base(name, surname, id)
        {
        }
        public Physician(string name, string surname)
            : base(name, surname)
        {
            Specialization = new List<Specialization>();
        }

        public Physician(string name, string surname, string id, DateTime dateOfBirth, string contact, string email,
            Address address, string password)
            : base(name, surname, id, dateOfBirth, contact, email, address, password)
        {
            Specialization = new List<Specialization>();
        }

        [JsonConstructor]
        public Physician(String serialNumber, string name, string surname, string id, DateTime dateOfBirth,
            string contact, string email, Address address, TimeInterval workSchedule, string password,
            List<Specialization> specialization = null)
            : base(serialNumber, name, surname, id, dateOfBirth, contact, email, address, password)
        {
            WorkSchedule = new TimeInterval();
            Specialization = specialization ?? new List<Specialization>();
        }

        public Physician(string name, string surname, Specialization specialization)
            :base(name,surname)
        {
            this.Specialization = new List<Specialization>();
            Specialization.Add(specialization);
        }

        public void AddSpecialization(Specialization newSpecialization)
        {
            if (newSpecialization == null)
                return;
            Specialization ??= new List<Specialization>();
            if (!Specialization.Contains(newSpecialization))
                Specialization.Add(newSpecialization);
        }

        public void RemoveSpecialization(Specialization oldSpecialization)
        {
            if (oldSpecialization == null)
                return;
            if (Specialization == null) return;
            if (Specialization.Contains(oldSpecialization))
                Specialization.Remove(oldSpecialization);
        }

        public void RemoveAllSpecialization()
        {
            Specialization?.Clear();
        }

        public void AddVacationTime(TimeInterval newTimeInterval)
        {
            if (newTimeInterval == null)
                return;
            VacationTime ??= new List<TimeInterval>();
            if (!VacationTime.Contains(newTimeInterval))
                VacationTime.Add(newTimeInterval);
        }

        public void RemoveVacationTime(TimeInterval oldTimeInterval)
        {
            if (oldTimeInterval == null)
                return;
            if (VacationTime == null) return;
            if (VacationTime.Contains(oldTimeInterval))
                VacationTime.Remove(oldTimeInterval);
        }

        public void RemoveAllVacationTime()
        {
            if (VacationTime != null)
                VacationTime.Clear();
        }

        public bool IsOnVacation(TimeInterval timeInterval)
        {
            return VacationTime.Any(vacation => vacation.IsOverLapping(timeInterval));
        }

        public bool IsTheirShift(TimeInterval timeInterval)
        {
            return WorkSchedule.IsTimeOfDayContained(timeInterval);
        }
    }
}