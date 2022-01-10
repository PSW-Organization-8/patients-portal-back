using HospitalClassLib.SharedModel;
using HospitalClassLib.Shift.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]

    public class ShiftController : ControllerBase
    {
        private readonly ShiftService shiftService;
        public ShiftController(ShiftService shiftService)
        {
            this.shiftService = shiftService;
        }

        [HttpGet]
        public List<Shift> GetAllShifts()
        {
            return shiftService.GetAllShifts();
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("/api/shiftById")]
        public HospitalClassLib.SharedModel.Shift GetShiftByID(long ID)
        {
            return shiftService.GetShiftByID(ID);
        }

        [HttpPost]

        [Microsoft.AspNetCore.Mvc.Route("/api/shifts")]
        public Shift CreateShifts(Shift shift)
        {
            return shiftService.CreateShifts(shift);
        }

        [HttpPut]
        [Microsoft.AspNetCore.Mvc.Route("/api/shifts/edit")]
        public Shift EditShifts(Shift shift)
        {
            return shiftService.EditShifts(shift);
        }

        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("/api/allShifts")]
        public void CreateAllShifts(List<Shift> shifts)
        {
            shiftService.CreateAllShifts(shifts);
        }


    }
}
