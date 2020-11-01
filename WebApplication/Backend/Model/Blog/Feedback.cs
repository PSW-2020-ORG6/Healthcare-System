// File:    Comment.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Comment

using Model.Accounts;
using System;

namespace Model.Blog
{
    public class Feedback
    {
        private String text;
        private DateTime date;
        private Account account;
        private Boolean approved;

        public Account Account
        {
            get
            {
                return account;
            }
            set
            {
                this.account = value;
            }
        }

        public string Text { get => text; set => text = value; }
        public DateTime Date { get => date; set => date = value; }
        public Boolean Approved { get => approved; set => approved = value; }

    }
}