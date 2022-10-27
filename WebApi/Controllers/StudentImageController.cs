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
    public class StudentImageController : ControllerBase
    {
        private readonly IStudentImageService _studentImageService;

        public StudentImageController(IStudentImageService studentImageService)
        {
            _studentImageService = studentImageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudentImages()
        {
            return Ok(await _studentImageService.GetAllStudentImagesAsync());
        }

        [HttpGet(template: "{studentName}")]
        public async Task<IActionResult> GetAStudentImage(string studentName)
        {
            return Ok(await _studentImageService.GetAStudentImageAsync(studentName));
        }

        [HttpPost]
        public async Task<IActionResult> Insert(StudentImageInserRequestValidationModel studentImageInserRequestValidationModel)
        {
            return Ok(await _studentImageService.InsertStudentImageAsync(studentImageInserRequestValidationModel));
        }
    }
}
