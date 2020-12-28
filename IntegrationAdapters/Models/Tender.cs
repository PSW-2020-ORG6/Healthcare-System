using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Models
{
    public class Tender
    {
        [Key]
        public string TenderName { get; set; }
        public string MedicineName { get; set; }
        public int Quantity { get; set; }
        public DateTime FinishDate { get; set; }
       // public virtual List<Offer> offers { get; set; }

        public Tender()
        {
            //offers = new List<Offer>();
        }
        public Tender(string tenderName, string medicineName, int quantity, DateTime finishDate)
        {
            TenderName = tenderName;
            MedicineName = medicineName;
            Quantity = quantity;
            FinishDate = finishDate;
           // offers = new List<Offer>();
        }
    }
}
