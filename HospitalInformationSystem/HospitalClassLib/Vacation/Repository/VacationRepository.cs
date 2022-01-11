using HospitalClassLib.SharedModel;
using HospitalClassLib.Vacation.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Vacation.Repository
{
    public class VacationRepository : AbstractSqlRepository<VacationPeriod, long>, IVacationRepository
    {
        public VacationRepository(MyDbContext dbContext) : base(dbContext)
        {

        }
        protected override long GetId(VacationPeriod entity)
        {
            return entity.ID;
        }


        public new List<VacationPeriod> GetAll()
        {
            return context.Vacations.ToList();
        }



    }
}
