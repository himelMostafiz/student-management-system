using BLL.Request_Validation;
using DLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IStudentImageService
    {
        Task<List<StudentImage>> GetAllStudentImagesAsync();
        Task<StudentImage> GetAStudentImageAsync(string studentName);
        Task<StudentImage> InsertStudentImageAsync(StudentImageInserRequestValidationModel studentImageRequestValidation);
    }
}
