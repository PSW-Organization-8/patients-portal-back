using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalClassLib.Schedule.Model;
using HospitalClassLib.Schedule.Repository.FeedbackRepository;

namespace HospitalClassLib.Schedule.Service
{
    public class FeedbackService
    {
        public FeedbackService() { }

        private readonly IFeedbackRepository feedbackRepository;


        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            this.feedbackRepository = feedbackRepository;
        }

        public Feedback Add(Feedback feedback)
        {
            return feedbackRepository.Create(feedback);
        }

        public List<Feedback> GetAll()
        {
            return feedbackRepository.GetAll();
        }

        public Feedback Get(int id)
        {
            return feedbackRepository.Get(id);
        }

        public Feedback Create(Feedback feedback)
        {
            return feedbackRepository.Create(feedback);
        }

        public bool Delete(int id)
        {
            return feedbackRepository.Delete(id);
        }

        public void ApproveFeedback(int id)
        {
            Feedback feedbackForChange = feedbackRepository.Get(id);
            feedbackForChange.FeedbackProperties.IsApproved = true;
            feedbackRepository.Update(feedbackForChange);
        }

        public void RemoveFeedback(int id)
        {
            Feedback feedbackForChange = feedbackRepository.Get(id);
            feedbackForChange.FeedbackProperties.IsApproved = false;
            feedbackRepository.Update(feedbackForChange);
        }

    }
}
