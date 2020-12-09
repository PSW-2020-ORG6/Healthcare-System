using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Util;

namespace WebApplication.Backend.Repositorys.Interfaces
{
    public interface ITimeIntervalRepository
    {
        List<TimeInterval> GetAllTimeIntervals();
        TimeInterval GetTimeIntervalByStart(string start);
        TimeInterval GetTimeIntervalByEnd(string end);
        List<TimeInterval> GetTimeIntervalsById(string id);
        TimeInterval GetTimeIntervalById(string id);
    }
}
