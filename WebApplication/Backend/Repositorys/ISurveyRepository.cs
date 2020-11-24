using health_clinic_class_diagram.Backend.Model.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Backend.Repositorys
{
    public interface ISurveyRepository
    {
        public bool AddNewSurvey(Survey surveyText);

        public List<double> calculateStatistics(List<Survey> reports);

        public List<double> getStatistics(string doctorId);
    }
}
