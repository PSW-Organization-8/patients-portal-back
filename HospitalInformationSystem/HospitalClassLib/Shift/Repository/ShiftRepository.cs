using HospitalClassLib.Shift.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Shift.Repository
{
    public class ShiftRepository : AbstractSqlRepository<SharedModel.Shift, long>, IShiftRepository
    {
        public ShiftRepository(MyDbContext dbContext) : base(dbContext)
        {

        }
        protected override long GetId(SharedModel.Shift entity)
        {
            return entity.ID;
        }


        public List<SharedModel.Shift> GetAll()
        {
            return context.Shifts.ToList();
        }



    }
}
