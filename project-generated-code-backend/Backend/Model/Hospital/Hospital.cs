// File:    Hospital.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Hospital

using Model.Accounts;
using System;
using System.Collections.Generic;
using Model.Util;

namespace Model.Hospital
{
    public class Hospital
    {
        private String Name { get; set; }
        private Address Address { get; set; }
        private List<Medicine> Medicine { get; set; }
        public List<Physitian> Physitians { get; set; }
        public List<Patient> Patients { get; set; }
        public List<Room> Rooms { get; set; }
    }
}