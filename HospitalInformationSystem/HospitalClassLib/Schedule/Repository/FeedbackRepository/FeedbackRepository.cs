using HospitalClassLib.Schedule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Schedule.Repository.FeedbackRepository
{
    public class FeedbackRepository : AbstractSqlRepository<Feedback, int>, IFeedbackRepository
    {
        private MyDbContext dbContext;

        public FeedbackRepository(MyDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Feedback> GetApproved()
        {
            return dbContext.Feedbacks.Where(x => x.FeedbackProperties.IsApproved && x.FeedbackProperties.IsPublishable).ToList();
        }

        protected override int GetId(Feedback entity)
        {
            return entity.Id;
        }
    }
}
