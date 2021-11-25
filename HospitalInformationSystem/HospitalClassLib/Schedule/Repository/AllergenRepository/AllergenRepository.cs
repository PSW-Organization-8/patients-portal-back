using HospitalClassLib.SharedModel;
using System.Collections.Generic;
using System.Linq;

namespace HospitalClassLib.Schedule.Repository.AllergenRepository
{
    public class AllergenRepository : AbstractSqlRepository<Allergen, int>, IAllergenRepository
    {
        private MyDbContext dbContext;

        public AllergenRepository(MyDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Allergen> GetSelectedAllergens(ICollection<Allergen> allergens)
        {
            return dbContext.Allergens.Where(x => allergens.Contains(x)).ToList();
        }

        protected override int GetId(Allergen entity)
        {
            return entity.Id;
        }
    }
}