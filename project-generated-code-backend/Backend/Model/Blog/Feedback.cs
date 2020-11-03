// File:    Comment.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Comment

using Backend.Model.Util;
using Model.Accounts;
using System;

namespace Model.Blog
{
    public class Feedback : Entity
    {
        private String id;//treba nam zbog identifikacija feedbeck-a
        private String text;
     // private DateTime date;
        // private Account account;
        private String name;//samo pokazno jer nisam znala da preuzmem cijeli objekat u bazu
        private Boolean approved;

        //public Account Account
        //{
        //    get
        //    {
        //        return account;
        //    }
        //    set
        //    {
        //        this.account = value;
        //    }
        //}
        public string Name { get => name; set => name = value; }
        public string Id { get => id; set => id = value; }
        public string Text { get => text; set => text = value; }
       // public DateTime Date { get => date; set => date = value; }
        public Boolean Approved { get => approved; set => approved = value; }

    }
}