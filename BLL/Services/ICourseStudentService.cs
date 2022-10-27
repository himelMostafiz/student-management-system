using BLL.Request_Validation;
using DLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface ICourseStudentService
    {
        Task<List<CourseStudent>> GetAllCourseStudentAsync();
        Task<CourseStudent> GetACourseStudentAsync(int Id);
        Task<CourseStudent> AddCourseStudentAsync(CourseEnrollInserRequestValidationModel courseStudentRequestValidation);
        Task<CourseStudent> UpdateCourseStudentAsync(int Id, CourseEnrollInserRequestValidationModel courseStudentRequestValidation);
        Task<CourseStudent> DeleteCourseStudentAsync(int Id);
    }
}
