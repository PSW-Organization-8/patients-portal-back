using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalClassLib.Feedbacks.Model;

namespace HospitalClassLib.Feedbacks.Service
{
    public class FeedbackService
    {
        ObservableCollection<Feedback> feedbacks = new ObservableCollection<Feedback>();

        private static FeedbackService instance = null;

        public static FeedbackService GetInstance()
        {
            if (instance == null)
            {
                instance = new FeedbackService();
            }
            return instance;
        }

        public Feedback Add(Feedback feedback)
        {
            feedback.Id = (feedbacks.Count + 1).ToString();
            feedbacks.Add(feedback);
            return feedback;
        }

        public ObservableCollection<Feedback> GetAll()
        {
            return feedbacks;
        }

        public void ApproveFeedback(string feedbackId)
        {
            foreach(Feedback feedback in this.feedbacks)
            {
                if (feedback.Id.Equals(feedbackId))
                    feedback.IsApproved = true;
            }
        }

        public ObservableCollection<Feedback> GetApprovedFeedbacks()
        {
            ObservableCollection<Feedback> approvedFeedbacks = new ObservableCollection<Feedback>();
            foreach (Feedback feedback in this.feedbacks)
            {
                if (feedback.IsApproved)
                    approvedFeedbacks.Add(feedback);
            }
            return approvedFeedbacks;
        }

    }
}
