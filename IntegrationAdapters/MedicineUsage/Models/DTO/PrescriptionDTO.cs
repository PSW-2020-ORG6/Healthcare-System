using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Models.DTO
{
    public class PrescriptionDTO
    {
        public string PatientName { get; set; }
        public string PatientSurName { get; set; }
        public string Medicine { get; set; }
        public int Quantity { get; set; }
        public string PharmacyName { get; set; }
        public string Note { get; set; }

        public PrescriptionDTO() { }
    }
}
