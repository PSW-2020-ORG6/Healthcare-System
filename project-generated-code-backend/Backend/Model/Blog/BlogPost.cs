// File:    BlogPost.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class BlogPost

using Model.Accounts;
using System;
using System.Collections.Generic;

namespace Model.Blog
{
    public class BlogPost
    {
        private String name;

        private List<Feedback> feedbacks;

        public List<Feedback> Feedbacks
        {
            get
            {
                if (feedbacks == null)
                    feedbacks = new List<Feedback>();
                return feedbacks;
            }
            set
            {
                RemoveAllFeedbacks();
                if (value != null)
                {
                    foreach (Feedback oFeedback in value)
                        AddFeedback(oFeedback);
                }
            }
        }

        public void AddFeedback(Feedback newFeedback)
        {
            if (newFeedback == null)
                return;
            if (this.feedbacks == null)
                this.feedbacks = new System.Collections.Generic.List<Feedback>();
            if (!this.feedbacks.Contains(newFeedback))
                this.feedbacks.Add(newFeedback);
        }

        public void RemoveFeedback(Feedback oldFeedback)
        {
            if (oldFeedback == null)
                return;
            if (this.feedbacks != null)
                if (this.feedbacks.Contains(oldFeedback))
                    this.feedbacks.Remove(oldFeedback);
        }

        public void RemoveAllFeedbacks()
        {
            if (feedbacks != null)
                feedbacks.Clear();
        }

        private Model.Accounts.Physitian physitian;

        public Physitian Physitian
        {
            get
            {
                return physitian;
            }
            set
            {
                this.physitian = value;
            }
        }

    }
}