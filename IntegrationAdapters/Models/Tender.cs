using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IntegrationAdapters.Models.DTO;

namespace IntegrationAdapters.Models
{
    public class Tender
    {
        [Key]
        public string TenderName { get; set; }
        public DateTime FinishDate { get; set; }

        public Tender()
        {
        }
        public Tender(string tenderName,  DateTime finishDate)
        {
            TenderName = tenderName;
            FinishDate = finishDate;
        }
    }
}
