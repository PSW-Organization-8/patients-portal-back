using HospitalClassLib.SharedModel;
using System.Collections.Generic;

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
        List<Allergen> GetSelectedAllergens(ICollection<Allergen> allergens);
    }
}