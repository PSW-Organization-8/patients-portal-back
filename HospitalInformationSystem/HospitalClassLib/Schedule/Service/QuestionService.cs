using HospitalClassLib.Schedule.Model;
using HospitalClassLib.Schedule.Repository.QuestionRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Schedule.Service
{
    public class QuestionService
    {
        public QuestionService() { }

        private readonly IQuestionRepository questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            this.questionRepository = questionRepository;
        }

        public Question Get(int id)
        {
            return questionRepository.Get(id);
        }

        public List<Question> GetAll()
        {
            return questionRepository.GetAll();
        }
        public Question Create(Question survey)
        {
            return questionRepository.Create(survey);
        }

        public bool Delete(int id)
        {
            return questionRepository.Delete(id);
        }
    }
}
