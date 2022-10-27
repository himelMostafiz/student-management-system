using BLL.Services;
using DLL.Models;
using DLL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Route("Controller")]
    public class StudentController : ControllerBase
    {
        //private readonly IStudentInterface _studentInterface;

        //public StudentController(IStudentInterface studentInterface)
        //{
        //    _studentInterface = studentInterface;
        //}
        
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
           // return Ok(await _studentInterface.GetAllAsync());
            return Ok(await _studentService.GetAllStudentsAsync());
        }

        [HttpGet(template: "{email}")]
        public async Task<IActionResult> GetAStudent(string email)
        {
            //return Ok(await _studentInterface.GetAStudentAsync(email));
            return Ok(await _studentService.GetAStudentAsync(email));
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Student aStudesnt )
        {
            //return Ok(await _studentInterface.InsertAsync(aStudesnt));
            return Ok(await _studentService.AddStudentAsync(aStudesnt));
        }

        [HttpPut(template: "{email}")]
        public async Task<IActionResult> Update(string email,Student aStudesnt)
        {
            //return Ok(await _studentInterface.UpdateAsync(email,aStudesnt));
            return Ok(await _studentService.UpdateStudentAsync(email,aStudesnt));
        }

        [HttpDelete(template: "{email}")]
        public async Task<IActionResult> Delete(string email)
        {
            //return Ok(await _studentInterface.DeleteAsync(email));
            return Ok(await _studentService.DeleteStudentAsync(email));
        }

    }
}
