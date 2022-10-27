using BLL.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL.Request_Validation
{
    public class CourseEnrollValidator : AbstractValidator<CourseEnrollInserRequestValidationModel>
    {
        private readonly IServiceProvider _serviceProvider;
        public CourseEnrollValidator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            RuleFor(c => c.CoursetId).NotNull().NotEmpty().MustAsync(IsCourseExist)
                .WithMessage("The course does not exist!!!");
            RuleFor(c => c.StudentId).NotNull().NotEmpty().MustAsync(IsStudentExist)
                .WithMessage("The student does noy exist!!!");
        }

        private async Task<bool> IsCourseExist(int courseId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(courseId.ToString()))
                return true;

            var requireService = _serviceProvider.GetRequiredService<ICourseService>();
            var isCourseExist = await requireService.GetCourseById(courseId);

            return !isCourseExist;
        }


        private async Task<bool> IsStudentExist(int studentId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(studentId.ToString()))
                return true;

            var requireService = _serviceProvider.GetRequiredService<IStudentService>();
            var isCourseExist = await requireService.GetStudentById(studentId);

            return !isCourseExist;
        }

    }
}
