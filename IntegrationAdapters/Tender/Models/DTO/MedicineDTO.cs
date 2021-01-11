using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Models.DTO
{
    public class MedicineDTO
    {
        [Key]
        public string Id { get; set; }
        public string TenderName { get; set; }
        public string MedicineName { get; set; }
        public int Quantity { get; set; }
        public MedicineDTO() { }
        public MedicineDTO(string medicineName, int quantity, string tenderName)
        {
            this.MedicineName = medicineName;
            this.Quantity = quantity;
            this.TenderName = tenderName;
        }
    }
}
