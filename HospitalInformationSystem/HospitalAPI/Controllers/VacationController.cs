using HospitalClassLib.SharedModel;
using HospitalClassLib.Vacation.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]

    public class VacationController : ControllerBase
    {
        private readonly VacationService vacationService;
        public VacationController(VacationService vacationService)
        {
            this.vacationService = vacationService;
        }

        [HttpGet]
        public List<VacationPeriod> GetAllVacations()
        {
            return vacationService.GetAllVacations();
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("/api/vacationById")]
        public VacationPeriod GetVacationByID(long ID)
        {
            return vacationService.GetVacationByID(ID);
        }

        [HttpPost]

        [Microsoft.AspNetCore.Mvc.Route("/api/vacations")]
        public VacationPeriod CreateVacations(VacationPeriod vacation)
        {
            return vacationService.CreateVacations(vacation);
        }

        [HttpPut]
        [Microsoft.AspNetCore.Mvc.Route("/api/vacations/edit")]
        public VacationPeriod EditVacations(VacationPeriod vacation)
        {
            return vacationService.EditVacations(vacation);
        }

        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("/api/allVacations")]
        public void CreateAllVacations(List<VacationPeriod> vacations)
        {
            vacationService.CreateAllVacations(vacations);
        }


    }
}
