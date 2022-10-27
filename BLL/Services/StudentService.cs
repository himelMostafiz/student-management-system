using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DLL.Models;
using DLL.Repositories;
using Utility.Exceptions;

namespace BLL.Services
{
    public class StudentService : IStudentService
    {
        //private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWorkRepository _unitOfWork;
        public StudentService(IUnitOfWorkRepository unitOfWork)
        {
            // _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            var studentList = await _unitOfWork.StudentRepository.GetAllAsync();
            if (studentList.Count == 0)
                throw new ApplicationValidationException("No students found.");

            return studentList;
        }

        public async Task<Student> GetAStudentAsync(string email)
        {
            var student =  await _unitOfWork.StudentRepository.FindSingleEntityAsync(s=>s.Email == email);
            if (student == null)
                throw new ApplicationValidationException("Student not found.");

            return student;
        }

        public async Task<Student> AddStudentAsync(Student astudent)
        {
           await _unitOfWork.StudentRepository.CreateAsync(astudent);

            if (await _unitOfWork.StudentRepository.SaveCompletedAsync())
            {
                return astudent;
            }

            throw new ApplicationException("Some error occurs to insert the department data.");
        }

        public async Task<Student> UpdateStudentAsync(string email, Student astudent)
        {
            var student = await _unitOfWork.StudentRepository.FindSingleEntityAsync(x => x.Email == email);

            if (student == null)
            {
                throw new ApplicationValidationException("Student not found.");
            }

            if (!string.IsNullOrWhiteSpace(astudent.Email))
            {
                var emailAlreadyExist = await _unitOfWork.StudentRepository.FindSingleEntityAsync(x => x.Email == student.Email);
                if (emailAlreadyExist != null)
                {
                    throw new ApplicationValidationException("Department code already exist.");
                }

                student.DepartmentId = astudent.DepartmentId;
                student.Email = astudent.Email;
                student.Name = astudent.Name;
            }

            _unitOfWork.StudentRepository.Update(student);

            if (await _unitOfWork.StudentRepository.SaveCompletedAsync())
            {
                return student;
            }

            throw new ApplicationValidationException("Some problem for updating data.");
        }
        public async Task<Student> DeleteStudentAsync(string email)
        {
            var aStudent = await _unitOfWork.StudentRepository.FindSingleEntityAsync(x => x.Email == email);

            if (aStudent == null)
            {
                throw new ApplicationValidationException("Student not found.");
            }

            _unitOfWork.StudentRepository.Delete(aStudent);

            if (await _unitOfWork.StudentRepository.SaveCompletedAsync())
            {
                return aStudent;
            }
            throw new ApplicationValidationException("Some problem for deleting data.");
        }

        public async Task<bool> GetStudentById(int studentId)
        {
            var isStudentExist = false;

            var aStudent = await _unitOfWork.StudentRepository.FindSingleEntityAsync(s => s.StudentId == studentId);

            if (aStudent != null)
                isStudentExist = true;

            return isStudentExist;
        }

        public async Task<bool> IsStudentEmailAlreadyExist(string email)
        {
            var isStudentExist = false;

            var aStudent = await _unitOfWork.StudentRepository.FindSingleEntityAsync(s => s.Email == email);

            if (aStudent != null)
                isStudentExist = true;

            return isStudentExist;
        }
    }
}
