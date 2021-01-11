using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Models
{
    public class MedicineMessage
    {
        public String MedicineName { get; set; }
        public int Quantity { get; set; }
        public bool IsPharmacyApproved { get; set; }

        public MedicineMessage()
        {
        }

        public MedicineMessage(string medicineName, int quantity, bool isPharmacyApproved)
        {
            this.MedicineName = medicineName;
            this.Quantity = quantity;
            this.IsPharmacyApproved = isPharmacyApproved;
        }
    }
}
