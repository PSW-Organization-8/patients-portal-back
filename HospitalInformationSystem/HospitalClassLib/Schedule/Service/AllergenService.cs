using HospitalClassLib.Schedule.Repository.AllergenRepository;
using HospitalClassLib.SharedModel;
using System.Collections.Generic;

namespace HospitalClassLib.Schedule.Service
{
    public class AllergenService
    {
        public AllergenService() { }

        private readonly IAllergenRepository allergenRepository;

        public AllergenService(IAllergenRepository allergenRepository)
        {
            this.allergenRepository = allergenRepository;
        }

        public Allergen Get(int id)
        {
            return allergenRepository.Get(id);
        }

        public List<Allergen> GetAll()
        {
            return allergenRepository.GetAll();
        }
        public List<Allergen> GetSelectedAllergens(ICollection<Allergen> allergens)
        {
            return allergenRepository.GetSelectedAllergens(allergens);
        }
    }
}