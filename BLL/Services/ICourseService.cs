using BLL.Request_Validation;
using DLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface ICourseService
    {
        Task<List<Course>> GetAllCourseAsync();
        Task<Course> GetACourseAsync(string code);
        Task<Course> AddCourseAsync(CourseInserRequestValidationModel courseRequestValidation);
        Task<Course> UpdateCourseAsync(String code, CourseInserRequestValidationModel courseRequestValidation);
        Task<Course> DeleteCourseAsync(string code);
        Task<bool> GetCourseById(int courseId);
        Task<bool> IsCourseCodeAlreadyExist(string code);
        Task<bool> IsCourseNameAlreadyExist(string name);
    }
}
