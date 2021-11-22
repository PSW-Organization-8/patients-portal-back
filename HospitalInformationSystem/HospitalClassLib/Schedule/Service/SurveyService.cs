using HospitalClassLib.Schedule.Model;
using HospitalClassLib.Schedule.Repository.SurveyRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Schedule.Service
{
    public class SurveyService
    {
        public SurveyService() { }

        private readonly ISurveyRepository surveyRepository;

        public SurveyService(ISurveyRepository surveyRepository)
        {
            this.surveyRepository = surveyRepository;
        }

        public Survey Get(int id)
        {
            return surveyRepository.Get(id);
        }

        public List<Survey> GetAll()
        {
            return surveyRepository.GetAll();
        }
        public Survey Create(Survey survey)
        {
            return surveyRepository.Create(survey);
        }

        public bool Delete(int id)
        {
            return surveyRepository.Delete(id);
        }
    }
}
