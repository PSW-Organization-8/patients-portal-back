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
        public EventRepository(MyDbContext dbContext) : base(dbContext)
        {

        }

        protected override long GetId(Event entity)
        {
            return entity.Id;
        }
    }
}
