// File:    Comment.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Comment

using System;
using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Util;

namespace HealthClinicBackend.Backend.Model.Blog
{
    public class Feedback : Entity
    {
        public string PatientId { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public Boolean Approved { get; set; }

        public Feedback() : base()
        {
        }

        public Feedback(String text, String patientId, DateTime date, Boolean app) : base()
        {
            PatientId = patientId;
            Text = text;
            Date = date;
            Approved = app;
        }

        public Feedback(String serialNumber, String text, String patientId, DateTime date, Boolean app) : base(
            serialNumber)
        {
            PatientId = patientId;
            Text = text;
            Date = date;
            Approved = app;
        }

        public Feedback(FeedbackDto feedbackDto) : base()
        {
            Text = feedbackDto.Text;
            PatientId = feedbackDto.PatientId;
            Date = feedbackDto.Date;
            Approved = feedbackDto.Approved;
        }
    }
}