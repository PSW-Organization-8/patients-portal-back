using HospitalClassLib.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Schedule.Repository.AllergenRepository
{
    public class AllergenRepository : AbstractSqlRepository<Allergen, int>, IAllergenRepository
    {
        private MyDbContext dbContext;

        public AllergenRepository(MyDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override int GetId(Allergen entity)
        {
            return entity.Id;
        }
    }
}
