using HospitalClassLib.Schedule.Service;
using HospitalClassLib.SharedModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    public class ManagerController : ControllerBase
    {

        private readonly ManagerService managerService;

        public ManagerController(ManagerService managerService)
        {
            this.managerService = managerService;
        }

        [HttpGet("login")]
        [Authorize]
        public IActionResult SellersEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok(currentUser);
        }

        private LoggedUser GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new LoggedUser
                {
                    Username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                };
            }
            return null;
        }

        [HttpGet("getByUsername/{id?}")]
        public IActionResult GetByUsername(string id)
        {
            return Ok(managerService.GetByUsername(id));
        }

    }
}
