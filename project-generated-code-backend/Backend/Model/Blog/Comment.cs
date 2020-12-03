// File:    Comment.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Comment

using Model.Accounts;
using System;

namespace Model.Blog
{
    public class Comment
    {
        public Account Account { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }
    }
}