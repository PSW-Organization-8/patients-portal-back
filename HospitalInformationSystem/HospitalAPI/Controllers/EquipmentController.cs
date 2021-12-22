using HospitalClassLib.Equipment.Service;
using HospitalClassLib.SharedModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EquipmentController : ControllerBase
    {


        private readonly EquipmentService equipmentService;
        public EquipmentController(EquipmentService equipmentService)
        {
            this.equipmentService = equipmentService;
        }

        [HttpGet]
        public List<Equipment> GetAllEquipments()
        {
            return equipmentService.GetAllEquipments();
        }

       [HttpPost]
        [Route("equipmentsst")]
        public Equipment CreateEquipments(Equipment equipment)
        {
            return equipmentService.CreateEquipments(equipment);
        }

        [HttpPost]
        [Route("/api/allEquipments")]
        public void CreateAllEquipments(List<Equipment> equipments)
        {
           equipmentService.CreateAllEquipments(equipments);
        }

        [HttpGet]
        [Route("{id?}")]
        public Equipment Get(long id)
        {
            return equipmentService.Get(id);
        }

        [HttpGet]
        [Route("search")]
        public List<Equipment> Search(string str)
        {
            return equipmentService.Search(str);
        }



    }
}
