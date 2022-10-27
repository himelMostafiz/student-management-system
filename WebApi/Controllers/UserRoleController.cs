using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [HttpPost("createRole")]
        public async Task<IActionResult> CreateRole()
        {
            await _userRoleService.AddNewRoleAsync();
            return Ok("programming is fun ...");
        }

        [HttpPost("CreateUserRole")]
        public async Task<IActionResult> CreateUserRole()
        {
            await _userRoleService.AddNewUserAsync();
            return Ok("Programming is fun..  - by Ashis sir.");
        }
    }
}
