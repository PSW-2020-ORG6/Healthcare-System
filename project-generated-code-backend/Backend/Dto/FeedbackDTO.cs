using Backend.Model.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace health_clinic_class_diagram.Backend.Dto
{
    public class FeedbackDTO
    {
        private String text;
        private DateTime date;
        private String patientId;
        private Boolean approved;
        private String serialNumber;
        public string SerialNumber { get => serialNumber; set => serialNumber=value; }
        public string PatientId { get => patientId; set => patientId = value; }
        public string Text { get => text; set => text = value; }
        public DateTime Date { get => date; set => date = value; }
        public Boolean Approved { get => approved; set => approved = value; }
        public bool IsCorrectText()
        {
            if (Text == null)
                return false;
            String[] words = Text.Split('\n');
            return words != null && Text != null && Text.Length > 2;
        }
        public bool IsApprovalValid()
        {
            return Approved != null;
        }
    }
}
