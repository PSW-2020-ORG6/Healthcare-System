using System;
using System.ComponentModel.DataAnnotations;
using HealthClinicBackend.Backend.Model.Util;

namespace HealthClinicBackend.Backend.Model.PharmacySupport
{
    public class ActionAndBenefitMessage : Entity
    {
        public Guid ActionID { get; set; }
        public string PharmacyName { get; set; }
        public string Text { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public ActionAndBenefitMessage()
        {
        }

        public ActionAndBenefitMessage(Guid id, string pharmacyName, string text, DateTime dateFrom, DateTime dateTo)
        {
            ActionID = id;
            PharmacyName = pharmacyName;
            Text = text;
            DateFrom = dateFrom;
            DateTo = dateTo;
        }
    }
}