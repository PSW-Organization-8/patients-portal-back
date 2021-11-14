using HospitalClassLib.Schedule.Repository.AllergenRepository;
using HospitalClassLib.SharedModel;

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
    }
}
