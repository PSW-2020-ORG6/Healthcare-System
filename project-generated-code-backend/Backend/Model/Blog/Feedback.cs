// File:    Comment.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Comment

using Backend.Model.Util;
using health_clinic_class_diagram.Backend.Dto;
using Model.Accounts;
using System;

namespace Model.Blog
{
    public class Feedback : Entity
    {
        private String text;
        private DateTime date;
        private String patientId;
        private Boolean approved;
        public string PatientId { get => patientId; set => patientId = value; }
        public string Text { get => text; set => text = value; }
        public DateTime Date { get => date; set => date = value; }
        public Boolean Approved { get => approved; set => approved = value; }
        public Feedback(String text, String patientId, DateTime date, Boolean app)
        {
            this.PatientId = patientId;
            this.Text = text;
            this.Date = date;
            this.Approved = app;
        }
        public Feedback() { }
        public Feedback(FeedbackDTO feedbackDTO)
        {
            this.text = feedbackDTO.Text;
            this.patientId = feedbackDTO.PatientId;
            this.date = feedbackDTO.Date;
            this.Approved = feedbackDTO.Approved;
        }
    }
}