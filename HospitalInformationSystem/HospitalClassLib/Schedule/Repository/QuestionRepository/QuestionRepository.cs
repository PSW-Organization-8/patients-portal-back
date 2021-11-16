using HospitalClassLib.Schedule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Schedule.Repository.QuestionRepository
{
    public class QuestionRepository : AbstractSqlRepository<Question, int>, IQuestionRepository
    {
        private MyDbContext dbContext;

        public QuestionRepository(MyDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override int GetId(Question entity)
        {
            return entity.Id;
        }
    }
}
