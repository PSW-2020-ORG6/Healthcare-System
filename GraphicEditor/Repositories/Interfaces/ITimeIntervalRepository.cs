using Model.Util;
using System.Collections.Generic;

namespace GraphicEditor.Repositories.Interfaces
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
