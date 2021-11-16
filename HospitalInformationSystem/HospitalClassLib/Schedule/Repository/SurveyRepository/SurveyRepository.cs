using HospitalClassLib.Schedule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Schedule.Repository.SurveyRepository
{
    public class SurveyRepository : AbstractSqlRepository<Survey, int>, ISurveyRepository
    {
        private MyDbContext dbContext;

        public SurveyRepository(MyDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override int GetId(Survey entity)
        {
            return entity.Id;
        }
    }
}
