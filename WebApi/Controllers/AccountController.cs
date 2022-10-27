using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
using BLL.Request;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : OurApplicationController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginRequest request)
        {
            return Ok(await _accountService.LoginUser(request));
        }

        [HttpGet("test1")]
        public ActionResult Test1()
        {

            return Ok("enter test 1");
        }



        [HttpGet("test2")]
        [Authorize(Policy = "AtToken")]
        public ActionResult Test2()
        {

            return Ok("enter test 2");
        }

        [HttpGet("test3")]
        [Authorize(Roles = "customer,agent", Policy = "AtToken")]
        public ActionResult Test3()
        {
            var tt = User;

            _accountService.Test(tt);
            return Ok("enter test 3");
        }


        [HttpPost("logout")]
        [Authorize(Roles = "customer,agent", Policy = "AtToken")]
        public async Task<ActionResult> Logout()
        {
            var tt = User;

            return Ok(await _accountService.Logout(tt));
        }


        [HttpPost("refresh")]
        public async Task<ActionResult> RefreshToken(RefeshTokenRequest request)
        {
            return Ok(await _accountService.RefreshToken(request.Token));
        }


    }
}
