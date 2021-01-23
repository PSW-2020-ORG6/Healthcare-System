using MicroServiceAppointment.Backend.Events.PatientRegisteredEventLogging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace WebApplicationTests
{
    public class EventStatisticsTests
    {
        List<PatientAppointmentEvent> events = new List<PatientAppointmentEvent>();

        public EventStatisticsTests()
        {
            events.Add(new PatientAppointmentEvent
            {
                IsAppointmentScheduled = true,
                SchedulingDuration = "120",
                TransitionsFromFourToThreeStep = 2,
                TransitionsFromThreeToTwoStep = 2,
                TransitionsFromTwoToOneStep = 2
            });
            events.Add(new PatientAppointmentEvent
            {
                IsAppointmentScheduled = true,
                SchedulingDuration = "60",
                TransitionsFromFourToThreeStep = 0,
                TransitionsFromThreeToTwoStep = 0,
                TransitionsFromTwoToOneStep = 0,
            });
        }

        [Fact]
        public void Statistic_percent_appointment_isScheduled()
        {
            var stubPatientEventRepository = new Mock<IPatientAppointmentEventRepository>();
            stubPatientEventRepository.Setup(m => m.GetAll()).Returns(events);
            LogPatientAppointmentEventService patientEventService = new LogPatientAppointmentEventService(stubPatientEventRepository.Object);

            var statistics = patientEventService.GetStatisticResults();

            Assert.True(statistics.PercentIsAppointmentScheduled == 100);
        }

        [Fact]
        public void Statistic_percent_first_step()
        {
            var stubPatientEventRepository = new Mock<IPatientAppointmentEventRepository>();
            stubPatientEventRepository.Setup(m => m.GetAll()).Returns(events);
            LogPatientAppointmentEventService patientEventService = new LogPatientAppointmentEventService(stubPatientEventRepository.Object);

            var statistics = patientEventService.GetStatisticResults();

            Assert.True(statistics.PercentTransitionsToFirstStepOnce == (double)100 / 3);
        }

        [Fact]
        public void Statistic_percent_second_step()
        {
            var stubPatientEventRepository = new Mock<IPatientAppointmentEventRepository>();
            stubPatientEventRepository.Setup(m => m.GetAll()).Returns(events);
            LogPatientAppointmentEventService patientEventService = new LogPatientAppointmentEventService(stubPatientEventRepository.Object);

            var statistics = patientEventService.GetStatisticResults();

            Assert.True(statistics.PercentTransitionsToSecondStepOnce == (double)100/3);
        }

        [Fact]
        public void Statistic_percent_third_step()
        {
            var stubPatientEventRepository = new Mock<IPatientAppointmentEventRepository>();
            stubPatientEventRepository.Setup(m => m.GetAll()).Returns(events);
            LogPatientAppointmentEventService patientEventService = new LogPatientAppointmentEventService(stubPatientEventRepository.Object);

            var statistics = patientEventService.GetStatisticResults();

            Assert.True(statistics.PercentTransitionsToThirdStepOnce == (double)100 / 3);
        }

        [Fact]
        public void Statistic_percent_time()
        {
            var stubPatientEventRepository = new Mock<IPatientAppointmentEventRepository>();
            stubPatientEventRepository.Setup(m => m.GetAll()).Returns(events);
            LogPatientAppointmentEventService patientEventService = new LogPatientAppointmentEventService(stubPatientEventRepository.Object);

            var statistics = patientEventService.GetStatisticResults();

            Assert.True(statistics.SchedulingDuration == "1:30");
        }

        [Fact]
        public void Statistic_percent_steps()
        {
            var stubPatientEventRepository = new Mock<IPatientAppointmentEventRepository>();
            stubPatientEventRepository.Setup(m => m.GetAll()).Returns(events);
            LogPatientAppointmentEventService patientEventService = new LogPatientAppointmentEventService(stubPatientEventRepository.Object);

            var statistics = patientEventService.GetStatisticResults();

            Assert.True(statistics.PercenttTransitionsToSecondStep ==(double) 100/3);
        }
    }
}
