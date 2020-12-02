using Backend.Model.Util;
using System;

namespace health_clinic_class_diagram.Backend.Model.Survey
{
    public class Survey : Entity
    {
        public string id;
        public string doctorName;
        public string question1;
        public string question2;
        public string question3;
        public string question4;
        public string question5;
        public string question6;
        public string question7;
        public string question8;
        public string question9;
        public string question10;
        public string question11;
        public string question12;
        public string question13;
        public string question14;
        public string question15;
        public string question16;
        public string question17;
        public string question18;
        public string question19;
        public string question20;
        public string question21;
        public string question22;
        public string question23;

        public string ID { get => id; set => id = value; }
        public string DoctorName { get => doctorName; set => doctorName = value; }
        public string Question1 { get => question1; set => question1 = value; }
        public string Question2 { get => question2; set => question2 = value; }
        public string Question3 { get => question3; set => question3 = value; }
        public string Question4 { get => question4; set => question4 = value; }
        public string Question5 { get => question5; set => question5 = value; }
        public string Question6 { get => question6; set => question6 = value; }
        public string Question7 { get => question7; set => question7 = value; }
        public string Question8 { get => question8; set => question8 = value; }
        public string Question9 { get => question9; set => question9 = value; }
        public string Question10 { get => question10; set => question10 = value; }
        public string Question11 { get => question11; set => question11 = value; }
        public string Question12 { get => question12; set => question12 = value; }
        public string Question13 { get => question13; set => question13 = value; }
        public string Question14 { get => question14; set => question14 = value; }
        public string Question15 { get => question15; set => question15 = value; }
        public string Question16 { get => question16; set => question16 = value; }
        public string Question17 { get => question17; set => question17 = value; }
        public string Question18 { get => question18; set => question18 = value; }
        public string Question19 { get => question19; set => question19 = value; }
        public string Question20 { get => question20; set => question20 = value; }
        public string Question22 { get => question22; set => question22 = value; }
        public string Question21 { get => question21; set => question21 = value; }
        public string Question23 { get => question23; set => question23 = value; }


        public Survey() { }
        public Survey(String Id, String DovtorName, String AnswerQuestion1, String AnswerQuestion2, String AnswerQuestion3, String AnswerQuestion4,
            String AnswerQuestion5, String AnswerQuestion6, String AnswerQuestion7, String AnswerQuestion8,
            String AnswerQuestion9, String AnswerQuestion10, String AnswerQuestion11, String AnswerQuestion12,
            String AnswerQuestion13, String AnswerQuestion14, String AnswerQuestion15, String AnswerQuestion16,
            String AnswerQuestion17, String AnswerQuestion18, String AnswerQuestion19, String AnswerQuestion20,
            String AnswerQuestion21, String AnswerQuestion22, String AnswerQuestion23)
        {
            this.id = Id;
            this.doctorName = DoctorName;
            this.question1 = AnswerQuestion1;
            this.question2 = AnswerQuestion2;
            this.question3 = AnswerQuestion3;
            this.question4 = AnswerQuestion4;
            this.question5 = AnswerQuestion5;
            this.question6 = AnswerQuestion6;
            this.question7 = AnswerQuestion7;
            this.question8 = AnswerQuestion8;
            this.question9 = AnswerQuestion9;
            this.question10 = AnswerQuestion10;
            this.question11 = AnswerQuestion11;
            this.question12 = AnswerQuestion12;
            this.question13 = AnswerQuestion13;
            this.question14 = AnswerQuestion14;
            this.question15 = AnswerQuestion15;
            this.question16 = AnswerQuestion16;
            this.question17 = AnswerQuestion17;
            this.question18 = AnswerQuestion18;
            this.question19 = AnswerQuestion19;
            this.question20 = AnswerQuestion20;
            this.question21 = AnswerQuestion21;
            this.question22 = AnswerQuestion22;
            this.question23 = AnswerQuestion23;

        }

    }
}
