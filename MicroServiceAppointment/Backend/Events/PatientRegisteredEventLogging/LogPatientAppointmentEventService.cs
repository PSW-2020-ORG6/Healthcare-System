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
            List<PatientAppointmentEventDto> allEvents = GetAll();
            List<int> date = new List<int>();
            List<int> sprecialization = new List<int>();
            List<int> doctor = new List<int>();
            int stepTwoToOneTotal = 0;
            int stepThreeToTwo = 0;
            int stepFourToThree = 0;

            foreach (PatientAppointmentEventDto patientAppointmentEvent in allEvents)
            {
                date.Add(patientAppointmentEvent.TransitionsFromTwoToOneStep);
                sprecialization.Add(patientAppointmentEvent.TransitionsFromThreeToTwoStep);
                doctor.Add(patientAppointmentEvent.TransitionsFromFourToThreeStep);
            }
            foreach (int i in date)
                stepTwoToOneTotal += i;
            foreach (int i in sprecialization)
                stepThreeToTwo += i;
            foreach (int i in doctor)
                stepFourToThree += i;

            int totalReturns = stepTwoToOneTotal + stepThreeToTwo + stepFourToThree;
            double staticticsStepTwoToOne = (stepTwoToOneTotal * 100) / totalReturns;
            double staticticsStepThreeToTwo = (stepThreeToTwo * 100) / totalReturns;
            double staticticsStepFourToThree = (stepFourToThree * 100) / totalReturns;
            List<double> resultListStatistics = new List<double>();
            resultListStatistics.Add(staticticsStepTwoToOne);
            resultListStatistics.Add(staticticsStepThreeToTwo);
            resultListStatistics.Add(staticticsStepFourToThree);
            return resultListStatistics;
        }

        public List<double> GetStatisticsResultPerDate()//procenat koliko se puta vracao na datum,jednom, dvaput i vise puta
        {
            List<PatientAppointmentEventDto> allEvents = GetAll();
            List<int> date = new List<int>();
            List<int> Once = new List<int>();
            List<int> Twice = new List<int>();
            List<int> MultipleTimes = new List<int>();
      
            foreach (PatientAppointmentEventDto patientAppointmentEvent in allEvents)
            {
                date.Add(patientAppointmentEvent.TransitionsFromTwoToOneStep);
            }
            foreach(int i in date)
            {
                if (i == 1)
                    Once.Add(i);
                if (i == 2)
                    Twice.Add(i);
                else if(i!=1 && i!=2)
                    MultipleTimes.Add(i);
            }
            double staticticsOnceResult = (Once.Count * 100) / date.Count;
            double staticticsTwiceResult = (Twice.Count * 100) / date.Count;
            double staticticsMultipleTimesResult = (MultipleTimes.Count * 100) / date.Count;
            List<double> resultListStatistics = new List<double>();
            resultListStatistics.Add(staticticsOnceResult);
            resultListStatistics.Add(staticticsTwiceResult);
            resultListStatistics.Add(staticticsMultipleTimesResult);
            return resultListStatistics;
        }
        public List<double> GetStatisticsResultPerSpecialization()//procenat koliko se puta vracao na specijalizaciju,jednom, dvaput i vise puta
        {
            List<PatientAppointmentEventDto> allEvents = GetAll();
            List<int> specialization = new List<int>();
            List<int> Once = new List<int>();
            List<int> Twice = new List<int>();
            List<int> MultipleTimes = new List<int>();
          

            foreach (PatientAppointmentEventDto patientAppointmentEvent in allEvents)
            {
                specialization.Add(patientAppointmentEvent.TransitionsFromThreeToTwoStep);
            }
            foreach (int i in specialization)
            {
                if (i == 1)
                    Once.Add(i);
                if (i == 2)
                    Twice.Add(i);
                else if (i != 1 && i != 2)
                    MultipleTimes.Add(i);
            }
            
            double staticticsOnceResult = (Once.Count * 100) / specialization.Count;
            double staticticsTwiceResult = (Twice.Count * 100) / specialization.Count;
            double staticticsMultipleTimesResult = (MultipleTimes.Count * 100) / specialization.Count;
            List<double> resultListStatistics = new List<double>();
            resultListStatistics.Add(staticticsOnceResult);
            resultListStatistics.Add(staticticsTwiceResult);
            resultListStatistics.Add(staticticsMultipleTimesResult);
            return resultListStatistics;
        }
        public List<double> GetStatisticsResultPerDoctor()//procenat koliko se puta vracao na doktora,jednom, dvaput i vise puta
        {
            List<PatientAppointmentEventDto> allEvents = GetAll();
            List<int> doctor = new List<int>();
            List<int> Once = new List<int>();
            List<int> Twice = new List<int>();
            List<int> MultipleTimes = new List<int>();

            foreach (PatientAppointmentEventDto patientAppointmentEvent in allEvents)
            {
                doctor.Add(patientAppointmentEvent.TransitionsFromFourToThreeStep);
            }
            foreach (int i in doctor)
            {
                if (i == 1)
                    Once.Add(i);
                if (i == 2)
                    Twice.Add(i);
                else if (i != 1 && i != 2)
                    MultipleTimes.Add(i);
            }
            double staticticsOnceResult = (Once.Count * 100) / doctor.Count;
            double staticticsTwiceResult = (Twice.Count * 100) / doctor.Count;
            double staticticsMultipleTimesResult = (MultipleTimes.Count * 100) / doctor.Count;
            List<double> resultListStatistics = new List<double>();
            resultListStatistics.Add(staticticsOnceResult);
            resultListStatistics.Add(staticticsTwiceResult);
            resultListStatistics.Add(staticticsMultipleTimesResult);
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
            double minutes = (time / number) / 60;
            var middleTime = minutes.ToString().Split(".");
            return middleTime[0] + ":" + middleTime[1];
        }
    }
}
