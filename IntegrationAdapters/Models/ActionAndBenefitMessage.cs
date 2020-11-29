using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Models
{
    public class ActionAndBenefitMessage
    {
        public Guid ActionID { get; set; }
        public string PharmacyName { get; set; }
        public string Text { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public ActionAndBenefitMessage() { }
        public ActionAndBenefitMessage(string pharmacyName, string text, DateTime dateFrom, DateTime dateTo )
        {
            PharmacyName = pharmacyName;
            Text = text;
            DateFrom = dateFrom;
            DateTo = dateTo;
        }
        public ActionAndBenefitMessage(Guid id,string pharmacyName, string text, DateTime dateFrom, DateTime dateTo)
        {
            ActionID = id;
            PharmacyName = pharmacyName;
            Text = text;
            DateFrom = dateFrom;
            DateTo = dateTo;
        }
    }
}
