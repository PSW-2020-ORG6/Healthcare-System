using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Models
{
    public class MedicineReport
    {
        public string Id { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual List<MedicineDosage> Dosage { get; set; }  

        public MedicineReport() {
            Dosage = new List<MedicineDosage>();
        }

    }
}
