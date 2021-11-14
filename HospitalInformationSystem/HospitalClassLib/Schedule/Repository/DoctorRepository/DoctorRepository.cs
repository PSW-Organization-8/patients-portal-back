using HospitalClassLib.SharedModel;

namespace HospitalClassLib.Schedule.Repository.DoctorRepository
{
    public class DoctorRepository : AbstractSqlRepository<Doctor, int>, IDoctorRepository
    {
        private MyDbContext dbContext;

        public DoctorRepository(MyDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override int GetId(Doctor entity)
        {
            return entity.Id;
        }
    }
}
