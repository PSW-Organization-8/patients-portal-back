using HospitalClassLib.Equipment.Repository.IRepository;
using HospitalClassLib.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Equipment.Repository
{
   public  class BuildingRepository : AbstractSqlRepository<Building, long>, IBuildingRepository
    {
        public BuildingRepository(MyDbContext dbContext) : base(dbContext)
        {

        }
        protected override long GetId(Building entity)
        {
            return entity.ID;
        }
    }
}
