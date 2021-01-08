using HealthClinicBackend.Backend.Events.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinicBackend.Backend.Events.Repository
{
    interface IEventRepository
    {
        void LogEvent(Event @event);
    }
}
