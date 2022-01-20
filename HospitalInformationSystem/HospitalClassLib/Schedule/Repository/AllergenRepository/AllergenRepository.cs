using HospitalClassLib.Schedule.Model;
using HospitalClassLib.SharedModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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

        public List<Allergen> getPatientsAllergens(int id)
        {
            return dbContext.Patients.Where(p => p.Id == id).Include(x => x.Allergens).ToList()[0].Allergens.ToList();
        }
    }
}