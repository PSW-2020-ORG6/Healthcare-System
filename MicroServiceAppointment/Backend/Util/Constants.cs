using MicroServiceAccount.Backend.Model;
using MicroServiceAppointment.Backend.Model;
using System.Collections.Generic;

namespace MicroServiceAppointment.Backend.Util
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