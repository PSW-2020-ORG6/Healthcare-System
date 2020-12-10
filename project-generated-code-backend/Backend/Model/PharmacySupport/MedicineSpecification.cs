using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HealthClinicBackend.Backend.Model.Util;

namespace HealthClinicBackend.Backend.Model.PharmacySupport
{
    public class MedicineSpecification: Entity
    {
        public string ID { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
        public string Shape { get; set; }
        public string Notes { get; set; }
        public string Regime { get; set; }
        public string Producer { get; set; }
        private List<string> ReplacementMedicineID { get; set; }

        public MedicineSpecification()
        {
            ReplacementMedicineID = new List<string>();
        }

        public MedicineSpecification(string id, string content, string type, string shape, string notes, string regime,
            string producer, List<string> replacementMedicineID)
        {
            ID = id;
            Content = content;
            Type = type ?? throw new ArgumentNullException(nameof(type));
            Shape = shape;
            ReplacementMedicineID = replacementMedicineID;
            Notes = notes;
            Regime = regime;
            Producer = producer;
        }
    }
}