using HospitalAPI.Dto;
using HospitalClassLib.RelocationEquipment;
using HospitalClassLib.RelocationEquipment.Service;
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

    public class MoveEquipmentController : ControllerBase
    {
        private readonly MoveEquipmentService moveEquipmentService;
        public MoveEquipmentController(MoveEquipmentService moveEquipmentService)
        {
            this.moveEquipmentService = moveEquipmentService;
        }

        [HttpGet]
        public List<MoveEquipment> GetAllEquipments()
        {
            return moveEquipmentService.GetAllEquipments();
        }

        [HttpPost]
        [Route("/api/moveEquipments")]
        public MoveEquipment CreateEquipments(MoveEquipment moveEquipment)
        {
            return moveEquipmentService.CreateEquipments(moveEquipment);
        }

        [HttpPost]
        [Route("/api/moveAllEquipments")]
        public void CreateAllEquipments(List<MoveEquipment> moveEquipments)
        {
            moveEquipmentService.CreateAllEquipments(moveEquipments);
        }

        [HttpGet]
        [Route("/api/moveEquipment/{id}")]
        public MoveEquipment Get(long id)
        {
            return moveEquipmentService.Get(id);
        }

        [HttpPost]
        [Route("/api/submitRelocation")]
        public bool SubmitRelocation(MoveEquipmentDTO meDTO)
        {
            return moveEquipmentService.SubmitRelocation(meDTO.IDeq ,meDTO.IDroom, meDTO.Amount, meDTO.DestinationRoom, meDTO.RelocationTime, meDTO.Duration);
        }

    }
}
