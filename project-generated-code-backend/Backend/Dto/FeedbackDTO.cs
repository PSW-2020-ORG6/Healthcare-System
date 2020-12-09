using System;

namespace HealthClinicBackend.Backend.Dto
{
    public class FeedbackDto
    {
        public string SerialNumber { get; set; }
        public string PatientId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public Boolean Approved { get; set; }

        public bool IsCorrectText()
        {
            if (Text == null)
                return false;
            String[] words = Text.Split('\n');
            return Text != null && Text.Length > 2;
        }

        public bool IsApprovalValid()
        {
            return Approved != null;
        }
    }
}