using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace health_clinic_class_diagram.Backend.Model.Survey
{
    public class Answer
    {
        public int answerRate;

        public int AnswerRate { get => answerRate; set => answerRate = value; }
        public Answer() { }
        public Answer(int AnswerRate)
        {
            this.answerRate = AnswerRate;
        }
    }

  

}
