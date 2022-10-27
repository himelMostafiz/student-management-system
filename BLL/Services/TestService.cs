using Bogus;
using DLL.DBContext;
using DLL.Models;
using DLL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TestService : ITestService
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        private readonly ApplicationDbContext _dbContext ;

        public TestService(IUnitOfWorkRepository unitOfWork,ApplicationDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
        }

        public async Task InsertData()
        {
            var department = new Department()
            {
                Name = "science",
                Code = "science department"
            };


            var student = new Student()
            {
                Name = " abc",
                Email = "abc@gmail.com"
            };

            await _unitOfWork.DepartmentRepository.CreateAsync(department);
            
            await _unitOfWork.StudentRepository.CreateAsync(student);

            await _unitOfWork.SaveChangesAsync();

        }

        public async Task DummyData()
        {
            var demoStudent = new Faker<Student>()
                .RuleFor(s => s.Name, s => s.Name.FullName())
                .RuleFor(s => s.Email, (f, u) => f.Internet.Email(u.Name));

            var demoDepartment = new Faker<Department>()

            .RuleFor(d => d.Code, f => f.Name.LastName())

            .RuleFor(d => d.Name, f => f.Name.FullName())

            .RuleFor(u => u.Student, f => demoStudent.Generate(50).ToList());


            var departmentGenerateWithStudent = demoDepartment.Generate(100).ToList();

            await _dbContext.Departments.AddRangeAsync(departmentGenerateWithStudent);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DummyData1()
        {


            var dummyCourse = new Faker<Course>()
                .RuleFor(c => c.Name, c => c.Name.FullName())
                .RuleFor(c => c.Code, c => c.Name.FullName())
                .RuleFor(c => c.Credit, f => f.Random.Number(1, 10));

            var dummyCourseList = dummyCourse.Generate(50).ToList();
            await _dbContext.Courses.AddRangeAsync(dummyCourseList);
            await _dbContext.SaveChangesAsync();

            var studentIdList = await _dbContext.Students.Select(s => s.StudentId).ToListAsync();
            var courseIdList = await _dbContext.Courses.Select(c => c.CourseId).ToListAsync();

            int count = 0;

            foreach (var courseId in courseIdList)
            {
                var courseStudentList = new List<CourseStudent>();
                var studentIds = studentIdList.Skip(count).Take(5);

                foreach (var studentId in studentIds)
                {
                    courseStudentList.Add(
                        new CourseStudent()
                        {
                            CourseId = courseId,
                            StudentId = studentId

                        });
                }

                await _dbContext.CourseStudents.AddRangeAsync(courseStudentList);
                await _dbContext.SaveChangesAsync();
                count += 5;
            }
        }

        

    }
}
