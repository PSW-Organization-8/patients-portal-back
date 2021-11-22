using HospitalClassLib.Schedule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Schedule.Repository.SurveyRepository
{
    public interface ISurveyRepository
    {
        List<Survey> GetAll();
        Survey Get(int id);
        Survey Update(Survey survey);
        Survey Create(Survey survey);
        bool ExistsById(int id);
        bool Delete(int id);
    }
}
