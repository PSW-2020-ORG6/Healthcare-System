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

        public MedicineMessage(string MedicineName, int Quantity, bool IsPharmacyApproved)
        {
            this.MedicineName = MedicineName;
            this.Quantity = Quantity;
            this.IsPharmacyApproved = IsPharmacyApproved;
        }
    }
}
