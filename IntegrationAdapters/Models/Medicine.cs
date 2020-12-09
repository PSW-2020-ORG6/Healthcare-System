using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Models
{
    public class Medicine
    {
        public String MedicineID { get; set; }
        public String Name { get; set; }
        public String MedicineSpecificationID { get; set; }

        public Medicine()
        {
        }
        public Medicine(string medicineID, string name, String medicineSpecification)
        {
            MedicineID = medicineID;
            Name = name;
            MedicineSpecificationID = medicineSpecification;
        }
    }
}
