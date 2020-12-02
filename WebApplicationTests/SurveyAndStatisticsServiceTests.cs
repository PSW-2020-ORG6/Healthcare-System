using Autofac.Extras.Moq;
using health_clinic_class_diagram.Backend.Model.Survey;
using Moq;
using System.Collections.Generic;
using WebApplication.Backend.Repositorys;
using WebApplication.Backend.Services;
using WebApplication.Backend.Util;
using Xunit;

namespace WebApplicationTests
{
    public class SurveyAndStatisticsServiceTests
    {
        Survey surveyTest = new Survey
               ("001", "Bozo Bozic", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3", "3");
       
        [Fact]
            public void Adds_new_survey()
            {
                var stubRepository = new Mock<ISurveyRepository>();
                var result = true;
               
                stubRepository.Setup(m => m.AddNewSurvey(surveyTest)).Returns(result);
                SurveyService service = new SurveyService(stubRepository.Object);
                bool result1 = service.AddNewSurvey(surveyTest);

                Assert.True(result1);
            }
       
            [Fact]
            public void get_Statistic_Each_Question_correct()
            {
                using (var mock = AutoMock.GetLoose()) {
                    mock.Mock<ISurveyRepository>()
                        .Setup(x => x.getStatisticsEachQuestion())
                        .Returns(getSampleStatisticsEachQuestion());

                var cls = mock.Create<SurveyService>();
                List<StatisticAuxilaryClass> expected = getSampleStatisticsEachQuestion();
                List<StatisticAuxilaryClass> actual = cls.getStatisticsEachQuestion();

                bool flag = true;
                for (int i = 0; i < actual.Count; i++) {
                    flag = compareStatisticAuxilaryClass(actual[i], expected[i]);
                    if (flag == false)
                        break;
                }

                Assert.True(flag);
                }
            }

        private bool compareStatisticAuxilaryClass(StatisticAuxilaryClass p1 , StatisticAuxilaryClass p2) {
            
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
