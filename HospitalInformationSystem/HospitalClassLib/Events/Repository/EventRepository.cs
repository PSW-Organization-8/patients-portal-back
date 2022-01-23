using HospitalClassLib.Events.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Events.Repository
{
    public class EventRepository : AbstractSqlRepository<Event, long>, IEventRepository
    {
        private MyDbContext dbContext;

        public EventRepository(MyDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext; 
        }

        public List<Tuple<int, int, int>> ButtonClicksByAge()
        {
            dbContext.Events.Join(dbContext.Patients,
                                            x => x.UserId,
                                            y => y.Username,
                                            (x, y) => x.EventClass).Distinct();
            return null;
        }

        public List<int> MostWantedSpecialization()
        {
            return dbContext.Events.GroupBy(x => x.DoctorSpecialization).OrderBy(x => x.Key).Select(x => x.Count()).ToList();
        }

        public List<int> SuccessfulByTime()
        {
            List<int> list = new List<int>();
            int byYear = dbContext.Events.Where(x => x.TimeStamp >= DateTime.Now.AddYears(-1) && x.TimeStamp <= DateTime.Now).Count();
            int byMonth = dbContext.Events.Where(x => x.TimeStamp >= DateTime.Now.AddMonths(-1) && x.TimeStamp <= DateTime.Now).Count();
            int byWeek = dbContext.Events.Where(x => x.TimeStamp >= DateTime.Now.AddDays(-7) && x.TimeStamp <= DateTime.Now).Count();
            list.Add(byYear);
            list.Add(byMonth);
            list.Add(byWeek);
            return list; 
        }

        protected override long GetId(Event entity)
        {
            return entity.Id;
        }
    }
}
