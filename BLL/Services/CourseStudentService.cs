using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility.Exceptions;
using BLL.Request_Validation;
using DLL.Models;
using DLL.Repositories;

namespace BLL.Services
{
    public class CourseStudentService : ICourseStudentService
    {
        public readonly IUnitOfWorkRepository _unitOfWorkRepository;

        public CourseStudentService(IUnitOfWorkRepository unitOfWorkRepository)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
        }

        public async Task<List<CourseStudent>> GetAllCourseStudentAsync()
        {
            var coursesAssignStudentList = await _unitOfWorkRepository.CourseStudentRepository.GetAllAsync();
            
            if (coursesAssignStudentList.Count == 0)
                throw new ApplicationValidationException("No courses assign to any students.");
            
            return coursesAssignStudentList;
        }

        public async Task<CourseStudent> GetACourseStudentAsync(int id)
        {
            var coursesAssignStudent = await _unitOfWorkRepository.CourseStudentRepository.FindSingleEntityAsync(cs=>cs.CourseId == id || cs.StudentId == id);
            
            if (coursesAssignStudent == null)
                throw new ApplicationValidationException("Current courses does not assign to the current student.");
            
            return coursesAssignStudent;
        }

        public async Task<CourseStudent> AddCourseStudentAsync(CourseEnrollInserRequestValidationModel courseStudentRequestValidation)
        {
            var courseEnrollObj = new CourseStudent()
            {
                CourseId = courseStudentRequestValidation.CoursetId,
                StudentId = courseStudentRequestValidation.StudentId
            };

            await _unitOfWorkRepository.CourseStudentRepository.CreateAsync(courseEnrollObj);

            if(! await _unitOfWorkRepository.SaveChangesAsync())
                throw new ApplicationValidationException("Some error occurs to assigning the course to a student.");

            return courseEnrollObj;
        }

        public async Task<CourseStudent> UpdateCourseStudentAsync(int id, CourseEnrollInserRequestValidationModel courseStudentRequestValidation)
        {
            var courseEnrollObj = await _unitOfWorkRepository.CourseStudentRepository
                .FindSingleEntityAsync(cs=> cs.CourseId==id || cs.StudentId == id);

            if (courseEnrollObj == null)
                throw new ApplicationException("No student found who contains such course!!!");

            courseEnrollObj.CourseId = courseStudentRequestValidation.CoursetId;
            courseEnrollObj.StudentId = courseStudentRequestValidation.StudentId;

             _unitOfWorkRepository.CourseStudentRepository.Update(courseEnrollObj);

            if(!await _unitOfWorkRepository.SaveChangesAsync())
                throw new ApplicationValidationException("Some error occurs when updating the information regarding assign to a student.");

            return courseEnrollObj;
        }

        public async Task<CourseStudent> DeleteCourseStudentAsync(int id)
        {
            var courseEnrollObj = await _unitOfWorkRepository.CourseStudentRepository
                .FindSingleEntityAsync(cs => cs.CourseId == id || cs.StudentId == id);

            if (courseEnrollObj == null)
                throw new ApplicationException("No student found who contains such course!!!");

            _unitOfWorkRepository.CourseStudentRepository.Delete(courseEnrollObj);

            if (!await _unitOfWorkRepository.SaveChangesAsync())
                throw new ApplicationValidationException("Some error occurs when deleting the information regarding assign to a student.");

            return courseEnrollObj;
        }

        
    }
}
