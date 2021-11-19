using HospitalClassLib.Schedule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Schedule.Repository.QuestionRepository
{
    public interface IQuestionRepository
    {
        List<Question> GetAll();
        Question Get(int id);
        Question Update(Question question);
        Question Create(Question question);
        Question CreateQuestion(Question question);
        bool ExistsById(int id);
        bool Delete(int id);
        List<double> GetAvgQuestionValues();
    }
}

