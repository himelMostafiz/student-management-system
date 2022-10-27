using BLL.Request_Validation;
using DLL.Models;
using DLL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Exceptions;

namespace BLL.Services
{
    public class StudentImageService : IStudentImageService
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        private readonly IConfiguration _configuration;

        public StudentImageService(IUnitOfWorkRepository unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<List<StudentImage>> GetAllStudentImagesAsync()
        {
            var studentImageList = await _unitOfWork.StudentImageRepository.GetAllAsync();

            var allstudentImages = studentImageList.Select(
                c => {
                    
                    c.ImageUrl = _configuration.GetValue<string>(key: "MediaServer: ImageAccessUrl") + c.ImageUrl;
                    return c;

                }).ToList();

            if (studentImageList.Count == 0)
                throw new ApplicationValidationException("No student image found.");

           

            return studentImageList;
        }
        public async Task<StudentImage> GetAStudentImageAsync(string studentName)
        {
            var aStudentImage = await _unitOfWork.StudentImageRepository.FindSingleEntityAsync(s => s.StudentName == studentName);

            if (aStudentImage == null)
                throw new ApplicationValidationException("Student image is not found.");

            aStudentImage.ImageUrl =_configuration.GetValue<string>(key: "MediaServer: ImageAccessUrl") + aStudentImage.ImageUrl;

            return aStudentImage;
        }
        public async Task<StudentImage> InsertStudentImageAsync(StudentImageInserRequestValidationModel studentImageRequestValidation)
        {
            StudentImage aStudentImage = new StudentImage()
            {
                StudentName = studentImageRequestValidation.StudentName,
                ImageUrl = await  ForImageUpload(studentImageRequestValidation.StudentImage)
            };

            await _unitOfWork.StudentImageRepository.CreateAsync(aStudentImage);

            if (await _unitOfWork.SaveChangesAsync())
            {
                aStudentImage.ImageUrl = _configuration.GetValue<string>(key: "MediaServer: ImageAccessUrl") + aStudentImage.ImageUrl;
                return aStudentImage;
            }
                
           throw new ApplicationValidationException("Some error occurs to inserting the course data.");

            
        }

        private async Task<string> ForImageUpload(IFormFile file)
        {
            var extention = Path.GetExtension((file.FileName)) ?? ".png";

            var fileName = Guid.NewGuid().ToString() + extention;

            var imagePath = _configuration.GetValue<string>(key: "MediaServer: localImageStorage");

            var path = Path.Combine(Directory.GetCurrentDirectory(), imagePath, fileName).ToLower();
            
            await using var bits = new FileStream(path,FileMode.Create);

            await file.CopyToAsync(bits);

            bits.Close();

            return fileName;
        }

        
    }
}
