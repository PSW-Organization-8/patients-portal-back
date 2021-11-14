using HospitalClassLib.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Schedule.Repository.AllergenRepository
{
    public interface IAllergenRepository
    {
        List<Allergen> GetAll();
        Allergen Get(int id);
        Allergen Update(Allergen allergen);
        Allergen Create(Allergen allergen);
        bool ExistsById(int id);
        bool Delete(int id);
    }
}
