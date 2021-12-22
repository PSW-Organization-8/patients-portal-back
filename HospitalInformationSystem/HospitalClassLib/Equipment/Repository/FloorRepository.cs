using HospitalClassLib.Equipment.Repository.IRepository;
using HospitalClassLib.SharedModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Equipment.Repository
{
    public class FloorRepository : AbstractSqlRepository<Floor, long>, IFloorRepository
    {
        public FloorRepository(MyDbContext dbContext) : base(dbContext)
        {

        }
        protected override long GetId(Floor entity)
        {
            return entity.ID;
        }

        public  List<Floor> GetAll()
        {
            return context.Floors.Include(x => x.Building).ToList();
        }

    }


}
