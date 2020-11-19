using Model.MedicalExam;

namespace HealthClinic.Message
{
    internal class SubmitReportMessage
    {
        public Report Report { get; internal set; }
    }
}