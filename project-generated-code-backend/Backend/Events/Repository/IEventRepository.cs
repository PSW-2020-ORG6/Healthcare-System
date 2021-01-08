using HealthClinicBackend.Backend.Events.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinicBackend.Backend.Events.Repository
{
    public interface IEventRepository<in T> where T : Event
    {
        void LogEvent(T @event);
    }
}