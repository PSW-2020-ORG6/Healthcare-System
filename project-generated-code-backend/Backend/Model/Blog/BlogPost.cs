// File:    BlogPost.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class BlogPost

using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;

namespace HealthClinicBackend.Backend.Model.Blog
{
    public class BlogPost
    {
        private String Name { get; set; }
        public Physician Physician { get; set; }
        public List<Feedback> Feedbacks { get; set; }

        public void AddFeedback(Feedback newFeedback)
        {
            if (newFeedback == null)
                return;
            Feedbacks ??= new List<Feedback>();
            if (!Feedbacks.Contains(newFeedback))
                Feedbacks.Add(newFeedback);
        }

        public void RemoveFeedback(Feedback oldFeedback)
        {
            if (oldFeedback == null)
                return;
            if (Feedbacks == null) return;
            if (Feedbacks.Contains(oldFeedback))
                Feedbacks.Remove(oldFeedback);
        }

        public void RemoveAllFeedbacks()
        {
            Feedbacks?.Clear();
        }
    }
}