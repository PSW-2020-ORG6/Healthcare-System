// File:    Hospital.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Hospital

using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Util;

namespace HealthClinicBackend.Backend.Model.Hospital
{
    public class Hospital
    {
        private String Name { get; set; }
        private Address Address { get; set; }
        private List<Medicine> Medicine { get; set; }
        public List<Physician> Physitians { get; set; }
        public List<Patient> Patients { get; set; }
        public List<Room> Rooms { get; set; }
    }
}