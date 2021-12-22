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

    public class BuildingController : ControllerBase
    {
        private readonly BuildingService buildingService;
        public BuildingController(BuildingService buildingService)
        {
            this.buildingService = buildingService;
        }

        [HttpGet]
        public List<Building> GetAllBuildings()
        {
            return buildingService.GetAllBuildings();
        }

        [HttpPost]
        [Route("buildings")]
        public Building CreateBuildings(Building building)
        {
            return buildingService.CreateBuildings(building);
        }

        [HttpPost]
        [Route("allBuildings")]
        public void CreateAllBuildings(List<Building> buildings)
        {
            buildingService.CreateAllBuildings(buildings);
        }

    }
}
