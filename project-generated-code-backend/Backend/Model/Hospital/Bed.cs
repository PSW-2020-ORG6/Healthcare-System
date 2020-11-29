// File:    Bed.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Bed

using Backend.Model.Util;
using Model.Accounts;
using Newtonsoft.Json;
using System;

namespace Model.Hospital
{
    public class Bed: Entity
    {
        private string floor;
        private string building;
        private int room;
        private int bedNumber;
        private string patient;

        public Bed(): base()
        {
        }

        public Bed(string floor, string building, int room, int bedNumber): base(Guid.NewGuid().ToString())
        {
            this.floor = floor;
            this.building = building;
            this.room = room;
            this.bedNumber = bedNumber;
            this.patient = null;
        }

        [JsonConstructor]
        public Bed(String serialNumber, string floor, string building, int room, int bedNumber, string patient) : base(serialNumber)
        {
            this.floor = floor;
            this.building = building;
            this.room = room;
            this.bedNumber = bedNumber;
            this.patient = patient;
        }

        public string Building { get => building; set { building = value; } }

        public string Floor { get => floor; set { floor = value; } }

        public int Room { get => room; set { room = value; } }

        public int BedNumber { get => bedNumber; set { bedNumber = value; } }
        public string Patient { get => patient; set { patient = value; } }

        public bool bedOccupied()
        {
            if(patient == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}