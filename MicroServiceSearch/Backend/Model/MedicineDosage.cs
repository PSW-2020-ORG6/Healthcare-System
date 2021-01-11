// File:    MedicineDosage.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class MedicineDosage

using System;
using System.ComponentModel.DataAnnotations.Schema;
using MicroServiceAccount.Backend.Model.Util;
using Newtonsoft.Json;

namespace MicroServiceSearch.Backend.Model
{
    public class MedicineDosage : Entity
    {
        [ForeignKey("Medicine")] public string MedicineSerialNumber { get; set; }
        public virtual Medicine Medicine { get; set; }
        public double Amount { get; set; }
        public string Note { get; set; }

        public MedicineDosage() : base()
        {
        }

        public MedicineDosage(double ammount, string note, Medicine medicine) : base()
        {
            Amount = ammount;
            Note = note;
            Medicine = medicine;
        }

        [JsonConstructor]
        public MedicineDosage(String serialNumber, double ammount, string note, Medicine medicine) : base(serialNumber)
        {
            Amount = ammount;
            Note = note;
            Medicine = medicine;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedicineDosage other))
            {
                return false;
            }

            const double TOLERANCE = 0.00001;
            return Medicine.Equals(other.Medicine) && Math.Abs(Amount - other.Amount) < TOLERANCE &&
                   Medicine.Equals(other.Medicine);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "medicine: " + Medicine + "\namount: " + Amount + "\nnote: " + Note;
        }

        public bool MedicineNameContains(string value)
        {
            return Medicine.GenericName.ToUpper().Contains(value.ToUpper()) || Medicine.MedicineType.Type.ToUpper().Contains(value.ToUpper());
        }

        public bool MedicineTypeContains(string value)
        {
            return Medicine.MedicineType.Type.ToUpper().Contains(value.ToUpper());
        }

    }
}