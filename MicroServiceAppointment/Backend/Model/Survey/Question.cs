﻿using MicroServiceAccount.Backend.Model.Util;

namespace MicroServiceAppointment.Backend.Model.Survey
{
    public class Question: Entity
    {
        public string QuestionText { get; set; }
        public int Id { get; set; }

        public Question(): base()
        {
        }

        public Question(int id, string questionText): base()
        {
            Id = Id;
            QuestionText = QuestionText;
        }
    }
}