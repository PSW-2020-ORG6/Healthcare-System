using System;
using System.Collections.Generic;
using System.Text;
using HealthClinicBackend.Backend.Events.Dto;

namespace HealthClinicBackend.Backend.Events.Service
{
    interface ILogEventService<in T> where T : EventParams
    {
        public void LogEvent(T eventParams);
    }
}