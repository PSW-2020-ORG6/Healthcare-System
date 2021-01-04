using Autofac.Extras.Moq;
using Moq;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Survey;
using WebApplication.Backend.Services;
using WebApplication.Backend.Util;
using Xunit;
using System;
using HealthClinicBackend.Backend.Repository.Generic;

namespace WebApplicationTests
{
    public class SurveyAndStatisticsServiceTests
    {
        Survey surveyTest = new Survey
            ("001", "Bozo Bozic", new DateTime(2017, 05, 17));

        [Fact]
        public void Adds_new_survey()
        {
            var surveyRepository = new Mock<ISurveyRepository>();
            var appointmentRepository = new Mock<IAppointmentRepository>();
            var reportRepository = new Mock<IReportRepository>();

            SurveyService service = new SurveyService(surveyRepository.Object, appointmentRepository.Object,
                reportRepository.Object);

            bool result = service.AddNewSurvey(surveyTest);

            Assert.True(result);
            surveyRepository.Verify(m => m.Save(surveyTest), Times.Once);
        }

        private bool compareStatisticAuxilaryClass(StatisticAuxilaryClass p1, StatisticAuxilaryClass p2)
        {
            if (p1.AverageRating != p2.AverageRating)
                return false;
            else if (p1.Ones != p2.Ones)
                return false;
            else if (p1.Twos != p2.Twos)
                return false;
            else if (p1.Threes != p2.Threes)
                return false;
            else if (p1.Fours != p2.Fours)
                return false;
            else if (p1.Fives != p2.Fives)
                return false;

            return true;
        }

        private List<StatisticAuxilaryClass> getSampleStatisticsEachQuestion()
        {
            List<StatisticAuxilaryClass> output = new List<StatisticAuxilaryClass>
            {
                new StatisticAuxilaryClass
                {
                    AverageRating = 1,
                    Ones = 2,
                    Twos = 0,
                    Threes = 0,
                    Fours = 0,
                    Fives = 0,
                    OnesPercent = "100%",
                    TwosPercent = "0%",
                    ThreesPercent = "0%",
                    FoursPercent = "0%",
                    FivesPercent = "0"
                },
                new StatisticAuxilaryClass
                {
                    AverageRating = 1,
                    Ones = 2,
                    Twos = 0,
                    Threes = 0,
                    Fours = 0,
                    Fives = 0,
                    OnesPercent = "100%",
                    TwosPercent = "0%",
                    ThreesPercent = "0%",
                    FoursPercent = "0%",
                    FivesPercent = "0"
                },
                new StatisticAuxilaryClass
                {
                    AverageRating = 1,
                    Ones = 2,
                    Twos = 0,
                    Threes = 0,
                    Fours = 0,
                    Fives = 0,
                    OnesPercent = "100%",
                    TwosPercent = "0%",
                    ThreesPercent = "0%",
                    FoursPercent = "0%",
                    FivesPercent = "0"
                },
                new StatisticAuxilaryClass
                {
                    AverageRating = 1,
                    Ones = 2,
                    Twos = 0,
                    Threes = 0,
                    Fours = 0,
                    Fives = 0,
                    OnesPercent = "100%",
                    TwosPercent = "0%",
                    ThreesPercent = "0%",
                    FoursPercent = "0%",
                    FivesPercent = "0"
                },
                new StatisticAuxilaryClass
                {
                    AverageRating = 1,
                    Ones = 2,
                    Twos = 0,
                    Threes = 0,
                    Fours = 0,
                    Fives = 0,
                    OnesPercent = "100%",
                    TwosPercent = "0%",
                    ThreesPercent = "0%",
                    FoursPercent = "0%",
                    FivesPercent = "0"
                },
                new StatisticAuxilaryClass
                {
                    AverageRating = 1,
                    Ones = 2,
                    Twos = 0,
                    Threes = 0,
                    Fours = 0,
                    Fives = 0,
                    OnesPercent = "100%",
                    TwosPercent = "0%",
                    ThreesPercent = "0%",
                    FoursPercent = "0%",
                    FivesPercent = "0"
                },
                new StatisticAuxilaryClass
                {
                    AverageRating = 1,
                    Ones = 2,
                    Twos = 0,
                    Threes = 0,
                    Fours = 0,
                    Fives = 0,
                    OnesPercent = "100%",
                    TwosPercent = "0%",
                    ThreesPercent = "0%",
                    FoursPercent = "0%",
                    FivesPercent = "0"
                },
                new StatisticAuxilaryClass
                {
                    AverageRating = 1,
                    Ones = 2,
                    Twos = 0,
                    Threes = 0,
                    Fours = 0,
                    Fives = 0,
                    OnesPercent = "100%",
                    TwosPercent = "0%",
                    ThreesPercent = "0%",
                    FoursPercent = "0%",
                    FivesPercent = "0"
                },
                new StatisticAuxilaryClass
                {
                    AverageRating = 1,
                    Ones = 2,
                    Twos = 0,
                    Threes = 0,
                    Fours = 0,
                    Fives = 0,
                    OnesPercent = "100%",
                    TwosPercent = "0%",
                    ThreesPercent = "0%",
                    FoursPercent = "0%",
                    FivesPercent = "0"
                },
                new StatisticAuxilaryClass
                {
                    AverageRating = 1,
                    Ones = 2,
                    Twos = 0,
                    Threes = 0,
                    Fours = 0,
                    Fives = 0,
                    OnesPercent = "100%",
                    TwosPercent = "0%",
                    ThreesPercent = "0%",
                    FoursPercent = "0%",
                    FivesPercent = "0"
                },
                new StatisticAuxilaryClass
                {
                    AverageRating = 1,
                    Ones = 2,
                    Twos = 0,
                    Threes = 0,
                    Fours = 0,
                    Fives = 0,
                    OnesPercent = "100%",
                    TwosPercent = "0%",
                    ThreesPercent = "0%",
                    FoursPercent = "0%",
                    FivesPercent = "0"
                },
                new StatisticAuxilaryClass
                {
                    AverageRating = 1,
                    Ones = 2,
                    Twos = 0,
                    Threes = 0,
                    Fours = 0,
                    Fives = 0,
                    OnesPercent = "100%",
                    TwosPercent = "0%",
                    ThreesPercent = "0%",
                    FoursPercent = "0%",
                    FivesPercent = "0"
                },
                new StatisticAuxilaryClass
                {
                    AverageRating = 1,
                    Ones = 2,
                    Twos = 0,
                    Threes = 0,
                    Fours = 0,
                    Fives = 0,
                    OnesPercent = "100%",
                    TwosPercent = "0%",
                    ThreesPercent = "0%",
                    FoursPercent = "0%",
                    FivesPercent = "0"
                },
                new StatisticAuxilaryClass
                {
                    AverageRating = 1,
                    Ones = 2,
                    Twos = 0,
                    Threes = 0,
                    Fours = 0,
                    Fives = 0,
                    OnesPercent = "100%",
                    TwosPercent = "0%",
                    ThreesPercent = "0%",
                    FoursPercent = "0%",
                    FivesPercent = "0"
                },
                new StatisticAuxilaryClass
                {
                    AverageRating = 1,
                    Ones = 2,
                    Twos = 0,
                    Threes = 0,
                    Fours = 0,
                    Fives = 0,
                    OnesPercent = "100%",
                    TwosPercent = "0%",
                    ThreesPercent = "0%",
                    FoursPercent = "0%",
                    FivesPercent = "0"
                },
                new StatisticAuxilaryClass
                {
                    AverageRating = 1,
                    Ones = 2,
                    Twos = 0,
                    Threes = 0,
                    Fours = 0,
                    Fives = 0,
                    OnesPercent = "100%",
                    TwosPercent = "0%",
                    ThreesPercent = "0%",
                    FoursPercent = "0%",
                    FivesPercent = "0"
                },
                new StatisticAuxilaryClass
                {
                    AverageRating = 1,
                    Ones = 2,
                    Twos = 0,
                    Threes = 0,
                    Fours = 0,
                    Fives = 0,
                    OnesPercent = "100%",
                    TwosPercent = "0%",
                    ThreesPercent = "0%",
                    FoursPercent = "0%",
                    FivesPercent = "0"
                },
                new StatisticAuxilaryClass
                {
                    AverageRating = 1,
                    Ones = 2,
                    Twos = 0,
                    Threes = 0,
                    Fours = 0,
                    Fives = 0,
                    OnesPercent = "100%",
                    TwosPercent = "0%",
                    ThreesPercent = "0%",
                    FoursPercent = "0%",
                    FivesPercent = "0"
                },
                new StatisticAuxilaryClass
                {
                    AverageRating = 1,
                    Ones = 2,
                    Twos = 0,
                    Threes = 0,
                    Fours = 0,
                    Fives = 0,
                    OnesPercent = "100%",
                    TwosPercent = "0%",
                    ThreesPercent = "0%",
                    FoursPercent = "0%",
                    FivesPercent = "0"
                }
            };
            return output;
        }
    }
}