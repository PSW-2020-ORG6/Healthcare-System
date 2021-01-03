using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Schedule;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Util
{
    public class Constants
    {
        public static readonly Specialization GeneralPractice = new Specialization { Name = "General practitioner" };

        public static readonly ProcedureType GeneralPracticeExam = new ProcedureType
        { Specialization = GeneralPractice, Name = "General practice exam", EstimatedTimeInMinutes = 30 };

        public static readonly List<string> FloorNames = new List<string>()
        { "Ground floor",
          "First floor",
          "Second floor",
          "Third floor",
          "Fourth floor",
          "Fifth floor",
          "Sixth floor"
        };
    }
}