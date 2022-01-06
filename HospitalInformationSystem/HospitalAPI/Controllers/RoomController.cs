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

    public class RoomController : ControllerBase
    {

        private readonly RoomService roomService;
        public RoomController(RoomService roomService)
        {
            this.roomService = roomService;
        }

        [HttpGet]
        public List<Room> GetAllRooms()
        {
            return roomService.GetAllRooms();
        }

        [HttpPost]
        [Route("/api/rooms")]
        public Room CreateRooms(Room room)
        {
            return roomService.CreateRooms(room);
        }

        [HttpPost]
        [Route("/api/allRooms")]
        public void CreateAllRooms(List<Room> rooms)
        {
            roomService.CreateAllRooms(rooms);
        }
    }
}
