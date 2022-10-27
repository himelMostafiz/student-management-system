using BLL.Request_Validation;
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
    public class CourseEnrollController : ControllerBase
    {
        private readonly ICourseStudentService _courseEnrollService;

        public CourseEnrollController(ICourseStudentService courseEnrollService)
        {
            _courseEnrollService = courseEnrollService;
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CourseEnrollInserRequestValidationModel courseEnrollObj) 
        {
            return Ok(await _courseEnrollService.AddCourseStudentAsync(courseEnrollObj));
        }


    }
}
