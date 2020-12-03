using System;
using Backend.Model.Util;

namespace health_clinic_class_diagram.Backend.Model.Survey
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