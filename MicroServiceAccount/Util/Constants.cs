using HealthClinicBackend.Backend.Model.Accounts;
using MicroServiceAccount.Backend.Model;
//using HealthClinicBackend.Backend.Model.Schedule;

namespace MicroServiceAccount.Backend.Util
{
    public class Constants
    {
        public static readonly Specialization GeneralPractice = new Specialization {Name = "General practitioner"};

        //public static readonly ProcedureType GeneralPracticeExam = new ProcedureType
        //    {Specialization = GeneralPractice, Name = "General practice exam", EstimatedTimeInMinutes = 30};
    }
}