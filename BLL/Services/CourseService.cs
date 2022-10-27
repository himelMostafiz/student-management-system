using BLL.Request_Validation;
using DLL.Models;
using DLL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility.Exceptions;

namespace BLL.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWorkRepository _unitOfWork;

        public CourseService(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Course>> GetAllCourseAsync()
        {
            var courseList = await _unitOfWork.CourseRepository.GetAllAsync();
            if (courseList.Count == 0)
                throw new ApplicationValidationException("No courses found.");

            return courseList;
        }
        public async Task<Course> GetACourseAsync(string code)
        {
            var aCourse = await _unitOfWork.CourseRepository.FindSingleEntityAsync(c=>c.Code == code);

            if (aCourse == null)
                throw new ApplicationValidationException("Course not found.");

            return aCourse;
        }
        public async Task<Course> AddCourseAsync(CourseInserRequestValidationModel courseRequestValidation)
        {
            //Course aCourse = new Course();
            // aCourse.Code = courseRequestValidation.Code;
            // aCourse.Name = courseRequestValidation.Name;
            // aCourse.Credit = courseRequestValidation.Credit;

            Course aCourse = new Course()
            {
                Code = courseRequestValidation.Code,
                Name = courseRequestValidation.Name,
                Credit = courseRequestValidation.Credit
            };

            await _unitOfWork.CourseRepository.CreateAsync(aCourse);

            if (!await _unitOfWork.SaveChangesAsync())
                throw new ApplicationValidationException("Some error occurs to inserting the course data.");

                return aCourse;

        }
        public async Task<Course> UpdateCourseAsync(string code, CourseInserRequestValidationModel courseRequestValidation)
        {
            var aCourse = await _unitOfWork.CourseRepository.FindSingleEntityAsync(c => c.Code == code);

            if (aCourse == null)
                throw new ApplicationValidationException("Course not found.");

            aCourse.Code = courseRequestValidation.Code;
            aCourse.Name = courseRequestValidation.Name;
            aCourse.Credit = courseRequestValidation.Credit;

            _unitOfWork.CourseRepository.Update(aCourse);

            if (!await _unitOfWork.SaveChangesAsync())
                throw new ApplicationValidationException("Some error occurs to updating the course data.");

            return aCourse;


        }
        public async Task<Course> DeleteCourseAsync(string code)
        {
            var aCourse = await _unitOfWork.CourseRepository.FindSingleEntityAsync(c=>c.Code == code);

            if(aCourse == null)
                throw new ApplicationValidationException("Course not found.");

            _unitOfWork.CourseRepository.Delete(aCourse);

            if (!await _unitOfWork.CourseRepository.SaveCompletedAsync())
                throw new ApplicationValidationException("Some error occurs to deleting the course data.");

            return aCourse;
        }

        public async Task<bool> IsCourseCodeAlreadyExist(string code)
        {
            var isCourseExist = false;
            var aCourse = await _unitOfWork.CourseRepository.FindSingleEntityAsync(c => c.Code == code);
            if (aCourse != null)
                isCourseExist = true;

                return isCourseExist;
        }

        public async Task<bool> IsCourseNameAlreadyExist(string name)
        {
            var isCourseExist = false;
            var aCourse = await _unitOfWork.CourseRepository.FindSingleEntityAsync(c => c.Name == name);
            if (aCourse != null)
            {
                var courselst = await _unitOfWork.CourseRepository.GetAllAsync(c => c.Name == name);
                if(courselst.Count > 1)
                  isCourseExist = true;
            }
                

            return isCourseExist;
        }

        public async Task<bool> GetCourseById(int courseId)
        {
            var isCourseExist = false;
            
            var aCourse = await _unitOfWork.CourseRepository.FindSingleEntityAsync(c => c.CourseId == courseId);

            if (aCourse != null)
              isCourseExist = true;

            return isCourseExist;
        }
    }
}
