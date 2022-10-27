using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.Request_Validation;
using BLL.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourse()
        {
            return Ok( await _courseService.GetAllCourseAsync());
        }

        [HttpGet(template:"{code}")]
        public async Task<IActionResult> GetACourse(string code)
        {
            return Ok( await _courseService.GetACourseAsync(code));
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CourseInserRequestValidationModel courseInserRequestValidationModel)
        {
            return Ok(await _courseService.AddCourseAsync(courseInserRequestValidationModel));
        }

        [HttpPut(template: "{code}")]
        public async Task<IActionResult> UpdateCourse(string code, CourseInserRequestValidationModel courseInserRequestValidationModel)
        {
            return Ok( await _courseService.UpdateCourseAsync(code, courseInserRequestValidationModel));
        }

        [HttpDelete(template:"{code}")]
        public async Task<IActionResult> DeleteCourse(string code)
        {
            return Ok( await _courseService.DeleteCourseAsync(code));
        }

    }
}
