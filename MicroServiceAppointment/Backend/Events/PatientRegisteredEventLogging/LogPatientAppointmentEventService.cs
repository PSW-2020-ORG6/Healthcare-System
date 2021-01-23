using MicroServiceAppointment.Backend.Dto;
using MicroServiceAppointment.Backend.Events.EventLogging;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServiceAppointment.Backend.Events.PatientRegisteredEventLogging
{
    public class LogPatientAppointmentEventService : ILogEventService<PatientAppointmentEventParams>
    {
        private readonly IPatientAppointmentEventRepository _patientAppointmentEventRepository;
        public StatisticsResulDto resultStatistics=new StatisticsResulDto();

        public LogPatientAppointmentEventService(IPatientAppointmentEventRepository patientAppointmentEventRepository)
        {
            _patientAppointmentEventRepository = patientAppointmentEventRepository;
        }
        private List<PatientAppointmentEventDto> GetPatientAppointmentEventDto(List<PatientAppointmentEvent> appointments)
        {
            List<PatientAppointmentEventDto> appointmentsDto = new List<PatientAppointmentEventDto>();
            foreach (PatientAppointmentEvent a in appointments)
            {
                PatientAppointmentEventDto appointmentDTO = new PatientAppointmentEventDto(a);
                appointmentsDto.Add(appointmentDTO);
            }
            return appointmentsDto;
        }
       
        public void LogEvent(PatientAppointmentEventParams eventParams)
        {
            var patientAppointmentEvent = new PatientAppointmentEvent
            { TimeStamp = DateTime.Now, TransitionsFromTwoToOneStep = eventParams.TransitionsFromTwoToOneStep, 
                TransitionsFromThreeToTwoStep = eventParams.TransitionsFromThreeToTwoStep, TransitionsFromFourToThreeStep = eventParams.TransitionsFromFourToThreeStep,
                IsAppointmentScheduled = eventParams.IsAppointmentScheduled, SchedulingDuration = eventParams.SchedulingDuration};

            _patientAppointmentEventRepository.LogEvent(patientAppointmentEvent);
        }
        public List<PatientAppointmentEventDto> GetAll()
        {
            return GetPatientAppointmentEventDto(_patientAppointmentEventRepository.GetAll());
        }

        public List<double> GetStatisticsResultPerSteps()//procenat koliko se puta vracao na datum,specijalizaciju i doktora
        {
            var first = 0;
            var second = 0;
            var third = 0;
            foreach (PatientAppointmentEventDto patientAppointmentEvent in GetAll())
            {
                first += patientAppointmentEvent.TransitionsFromTwoToOneStep;
                second += patientAppointmentEvent.TransitionsFromThreeToTwoStep;
                third += patientAppointmentEvent.TransitionsFromFourToThreeStep;
            }
            List<double> resultListStatistics = new List<double>();
            double count = first + second + third;
            resultListStatistics.Add((first * 100) / count);
            resultListStatistics.Add((second * 100) / count);
            resultListStatistics.Add((third * 100) / count);
            return resultListStatistics;
        }

        public EventStatisticDTO GetStatisticResults()
        {
            EventStatisticDTO statisticResults = new EventStatisticDTO(GetStatisticsMiddleTime());
            var isSheduled = GetStatisticsResultPerIsScheduled();
            statisticResults.PercentIsAppointmentScheduled = isSheduled[0];
            statisticResults.PercentIsNotAppointmentScheduled = isSheduled[1];

            var stepOne = GetStatisticsResultPerDate();
            statisticResults.PercentTransitionsToFirstStepOnce = stepOne[0];
            statisticResults.PercentTransitionsToFirstStepTwice = stepOne[1];
            statisticResults.PercentTransitionsToFirstStepMore = stepOne[2];

            var stepTwo = GetStatisticsResultPerSpecialization();
            statisticResults.PercentTransitionsToSecondStepOnce = stepTwo[0];
            statisticResults.PercentTransitionsToSecondStepTwice = stepTwo[1];
            statisticResults.PercentTransitionsToSecondStepMore = stepTwo[2];

            var stepThree = GetStatisticsResultPerDoctor();
            statisticResults.PercentTransitionsToThirdStepOnce = stepThree[0];
            statisticResults.PercentTransitionsToThirdStepTwice = stepThree[1];
            statisticResults.PercentTransitionsToThirdStepMore = stepThree[2];

            var percentSteps = GetStatisticsResultPerSteps();
            statisticResults.PercenttTransitionsToFirstStep = percentSteps[0];
            statisticResults.PercenttTransitionsToSecondStep = percentSteps[1];
            statisticResults.PercenttTransitionsToThirdStep = percentSteps[2];

            return statisticResults;
        }

        public List<double> GetStatisticsResultPerDate()//procenat koliko se puta vracao na datum,jednom, dvaput i vise puta
        {
            var once = 0;
            var twice = 0;
            var more = 0;
            foreach (PatientAppointmentEventDto patientAppointmentEvent in GetAll())
            {
                if (patientAppointmentEvent.TransitionsFromTwoToOneStep == 0) once += 1;
                if (patientAppointmentEvent.TransitionsFromTwoToOneStep == 1) twice += 1;
                else more += 1;
            }
            List<double> resultListStatistics = new List<double>();
            double count = once + twice + more;
            resultListStatistics.Add((once * 100) / count);
            resultListStatistics.Add((twice * 100) / count);
            resultListStatistics.Add((more * 100) / count);
            return resultListStatistics;
        }
        public List<double> GetStatisticsResultPerSpecialization()//procenat koliko se puta vracao na specijalizaciju,jednom, dvaput i vise puta
        {
            var once = 0;
            var twice = 0;
            var more = 0;
            foreach (PatientAppointmentEventDto patientAppointmentEvent in GetAll())
            {
                if (patientAppointmentEvent.TransitionsFromThreeToTwoStep == 0) once += 1;
                if (patientAppointmentEvent.TransitionsFromThreeToTwoStep == 1) twice += 1;
                else more += 1;
            }
            List<double> resultListStatistics = new List<double>();
            double count = once + twice + more;
            resultListStatistics.Add((once * 100) / count);
            resultListStatistics.Add((twice * 100) / count);
            resultListStatistics.Add((more * 100) / count);
            return resultListStatistics;
        }
        public List<double> GetStatisticsResultPerDoctor()//procenat koliko se puta vracao na doktora,jednom, dvaput i vise puta
        {
            var once = 0;
            var twice = 0;
            var more = 0;
            foreach (PatientAppointmentEventDto patientAppointmentEvent in GetAll())
            {
                if (patientAppointmentEvent.TransitionsFromFourToThreeStep == 0) once += 1;
                if (patientAppointmentEvent.TransitionsFromFourToThreeStep == 1) twice += 1;
                else more += 1;
            }
            List<double> resultListStatistics = new List<double>();
            double count = once + twice + more;
            resultListStatistics.Add((once * 100) / count);
            resultListStatistics.Add((twice * 100) / count);
            resultListStatistics.Add((more * 100) / count);
            return resultListStatistics;
        }

        public string GetStatisticsMiddleTime()//prosecno vreme
        {
            var time = 0;
            var number = 0;
            foreach (PatientAppointmentEventDto patientAppointmentEvent in GetAll())
            {
                if (patientAppointmentEvent.IsAppointmentScheduled)
                {
                    time += Int32.Parse(patientAppointmentEvent.SchedulingDuration);
                    number += 1;
                }
            }
            var seconds =(int) time / number;
            var minutes = (int)(seconds / 60);
            return minutes.ToString() + ":" + (seconds-minutes*60).ToString();
        }

        public List<double> GetStatisticsResultPerIsScheduled()//procenat zakazanih i nezakazanih
        {
            var isScheduled = 0;
            var allEvents = GetAll();
            List<double> result = new List<double>();
            foreach (PatientAppointmentEventDto patientAppointmentEvent in allEvents)
                if (patientAppointmentEvent.IsAppointmentScheduled) isScheduled += 1;
            double isScheduledPer = isScheduled * 100 / allEvents.Count;
            result.Add(isScheduledPer);
            result.Add(100- isScheduledPer);
            return result;
        }
    }
}
