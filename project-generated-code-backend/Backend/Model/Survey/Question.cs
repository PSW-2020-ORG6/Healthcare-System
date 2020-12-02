using System;

namespace health_clinic_class_diagram.Backend.Model.Survey
{
    public class Question
    {
        public string question;
        public int id;

        public String QuestionText { get => question; set => question = value; }
        public int Id { get => id; }

        public Question() { }
        public Question(int ID, String QuestionText)
        {
            id = ID;
            question = QuestionText;
        }
    }
}
