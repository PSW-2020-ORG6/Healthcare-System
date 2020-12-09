using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Models
{
    public class MedicineSpecification
    {
        [Key]
        public String ID { get; set; }
        public String Content { get; set; }
        public String Type { get; set; }
        public String Shape { get; set; }
        public String Notes { get; set; }
        public String Regime { get; set; }
        public String Producer { get; set; }
        private List<String> ReplacementMedicineID { get; set; }
        public MedicineSpecification()
        {
            ReplacementMedicineID = new List<string>();
        }
        public MedicineSpecification(String id, String content, String type, String shape, String notes, String regime, String producer, List<string> replacementMedicineID)
        {
            ID = id;
            Content = content;
            Type = type;
            Shape = shape;
            ReplacementMedicineID = replacementMedicineID;
            Notes = notes;
            Regime = regime;
            Producer = producer;
        }
    }
}
