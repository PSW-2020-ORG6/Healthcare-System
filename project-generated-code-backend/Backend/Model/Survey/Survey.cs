using Backend.Model.Util;
using System;

namespace health_clinic_class_diagram.Backend.Model.Survey
{
    public class Survey : Entity
    {
        public string Id { get; set; }
        public string DoctorName { get; set; }
        public string Question1 { get; set; }
        public string Question2 { get; set; }
        public string Question3 { get; set; }
        public string Question4 { get; set; }
        public string Question5 { get; set; }
        public string Question6 { get; set; }
        public string Question7 { get; set; }
        public string Question8 { get; set; }
        public string Question9 { get; set; }
        public string Question10 { get; set; }
        public string Question11 { get; set; }
        public string Question12 { get; set; }
        public string Question13 { get; set; }
        public string Question14 { get; set; }
        public string Question15 { get; set; }
        public string Question16 { get; set; }
        public string Question17 { get; set; }
        public string Question18 { get; set; }
        public string Question19 { get; set; }
        public string Question20 { get; set; }
        public string Question22 { get; set; }
        public string Question21 { get; set; }
        public string Question23 { get; set; }


        public Survey() : base()
        {
        }

        public Survey(String id, String doctorName, String answerQuestion1, String answerQuestion2,
            String answerQuestion3, String answerQuestion4, String answerQuestion5, String answerQuestion6,
            String answerQuestion7, String answerQuestion8, String answerQuestion9, String answerQuestion10,
            String answerQuestion11, String answerQuestion12, String answerQuestion13, String answerQuestion14,
            String answerQuestion15, String answerQuestion16, String answerQuestion17, String answerQuestion18,
            String answerQuestion19, String answerQuestion20, String answerQuestion21, String answerQuestion22,
            String answerQuestion23)
        {
            Id = id;
            DoctorName = doctorName;
            Question1 = answerQuestion1;
            Question2 = answerQuestion2;
            Question3 = answerQuestion3;
            Question4 = answerQuestion4;
            Question5 = answerQuestion5;
            Question6 = answerQuestion6;
            Question7 = answerQuestion7;
            Question8 = answerQuestion8;
            Question9 = answerQuestion9;
            Question10 = answerQuestion10;
            Question11 = answerQuestion11;
            Question12 = answerQuestion12;
            Question13 = answerQuestion13;
            Question14 = answerQuestion14;
            Question15 = answerQuestion15;
            Question16 = answerQuestion16;
            Question17 = answerQuestion17;
            Question18 = answerQuestion18;
            Question19 = answerQuestion19;
            Question20 = answerQuestion20;
            Question21 = answerQuestion21;
            Question22 = answerQuestion22;
            Question23 = answerQuestion23;
        }
    }
}