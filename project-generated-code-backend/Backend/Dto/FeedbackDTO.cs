using HealthClinicBackend.Backend.Model.Blog;
using System;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Dto
{
    public class FeedbackDto
    {
        public string SerialNumber { get; set; }
        public string PatientId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public Boolean Approved { get; set; }

        public FeedbackDto()
        {
        }

        public FeedbackDto(Feedback feedback)
        {
            SerialNumber = feedback.SerialNumber;
            PatientId = feedback.PatientId;
            Text = feedback.Text;
            Date = feedback.Date;
            Approved = feedback.Approved;
        }

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

        public List<FeedbackDto> ConvertListToFeedbackDTO(List<Feedback> lists)
        {
            List<FeedbackDto> feedbacksDTO = new List<FeedbackDto>();
            foreach (Feedback feedback in lists)
                feedbacksDTO.Add(new FeedbackDto(feedback));
            return feedbacksDTO;

        }
    }
}