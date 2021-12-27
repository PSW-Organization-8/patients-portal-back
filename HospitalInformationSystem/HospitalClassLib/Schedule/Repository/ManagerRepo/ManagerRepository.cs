using HospitalClassLib.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Schedule.Repository.ManagerRepo
{
    public class ManagerRepository : AbstractSqlRepository<Manager, int>, IManagerRepository
    {
        private MyDbContext dbContext;

        public ManagerRepository(MyDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        protected override int GetId(Manager entity)
        {
            return entity.Id;
        }

    }
}
