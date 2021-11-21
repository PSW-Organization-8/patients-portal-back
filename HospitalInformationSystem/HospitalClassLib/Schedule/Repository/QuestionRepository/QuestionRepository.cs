using HospitalClassLib.Schedule.Model;
using Microsoft.EntityFrameworkCore;
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

        private DbSet<Question> dbSet;

        public QuestionRepository(MyDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = context.Set<Question>();
        }

        protected override int GetId(Question entity)
        {
            return entity.Id;
        }

        public Question CreateQuestion(Question entity)
        {
            if (!ExistsByIds(entity.Id, entity.SurveyId))
            {
                dbSet.Add(entity);
                context.SaveChanges();
                return entity;
            }
            return null;
        }

        public bool ExistsByIds(int idq, int ids)
        {
            bool exists = true;
            if (dbSet.Find(idq, ids) == null)
            {
                exists = false;
            }
            return exists;
        }

        public List<double> GetAvgQuestionValues()
        {
            return dbContext.Questions.GroupBy(x => x.Id, v => v.Value).OrderBy(x => x.Key).Select(x => x.Average()).ToList(); 
        }

        public List<double> GetAvgCategoryValues()
        {
            return dbContext.Questions.GroupBy(x => x.Category, v => v.Value).OrderBy(x => x.Key).Select(x => x.Average()).ToList();
        }
    }
}
