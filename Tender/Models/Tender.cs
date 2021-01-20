using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TenderProcurement.Models.DTO;

namespace TenderProcurement.Models
{
    public class Tender
    {
        [Key]
        public string TenderName { get; set; }
        public DateTime FinishDate { get; set; }
        public bool IsActive { get; set; }

        public Tender()
        {
        }
        public Tender(string tenderName,  DateTime finishDate, bool isActive)
        {
            TenderName = tenderName;
            FinishDate = finishDate;
            IsActive = isActive;
        }
    }
}
