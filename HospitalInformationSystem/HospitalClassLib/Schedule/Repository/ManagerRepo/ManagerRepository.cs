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

        public LoggedUser GetLoggedUser(string username, string password)
        {
            LoggedUser user = (LoggedUser)dbContext.Managers.Where(p => p.Username == username && p.Password == password).FirstOrDefault();
            return user;
        }

        public Manager GetByUsername(string username)
        {
            return dbContext.Managers.SingleOrDefault(manager => manager.Username.Equals(username));
        }
    }
}
