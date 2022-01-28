using HospitalClassLib.Schedule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Schedule.Repository.FeedbackRepository
{
    public interface IFeedbackRepository
    {
        List<Feedback> GetAll();
        List<Feedback> GetApproved();
        Feedback Get(int id);
        Feedback Update(Feedback feedback);
        Feedback Create(Feedback feedback);
        bool ExistsById(int id);
        bool Delete(int id);
    }
}
