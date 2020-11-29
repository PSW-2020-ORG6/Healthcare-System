using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Models
{
    public class MedicineReport
    {
        public string Id { get; set; }
        public virtual DateTime date { get; set; }
        public virtual List<MedicineDosage> dosage { get; set; }  

        public MedicineReport() {
            dosage = new List<MedicineDosage>();
        }

    }
}
