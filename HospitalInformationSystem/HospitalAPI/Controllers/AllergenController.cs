using HospitalClassLib.Schedule.Repository.AllergenRepository;
using HospitalClassLib.Schedule.Service;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AllergenController
    {
        private readonly AllergenService allergenService;
        private readonly AllergenRepository allergenRepository;
        public AllergenController(AllergenService allergenService, AllergenRepository allergenRepository)
        {
            this.allergenService = allergenService;
            this.allergenRepository = allergenRepository;
        }
    }
}
