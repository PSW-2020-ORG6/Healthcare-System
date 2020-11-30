﻿using health_clinic_class_diagram.Backend.Model.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Backend.Util;

namespace WebApplication.Backend.Repositorys
{
    public interface ISurveyRepository
    {
        public bool AddNewSurvey(Survey surveyText);
        public List<StatisticAuxilaryClass> getStatisticsEachQuestion();
    }
}