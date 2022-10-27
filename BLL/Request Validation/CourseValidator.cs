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
    public class CourseValidator : AbstractValidator<CourseInserRequestValidationModel>
    {
        private readonly IServiceProvider _serviceProvider;
        public CourseValidator(IServiceProvider serviceProvider)
        {
           _serviceProvider = serviceProvider;

            RuleFor(c => c.Name).NotNull().NotEmpty().Length(1, 45).MustAsync(IsCourseNameAlreadyExist)
                .WithMessage("The course name already exist!!!");
            RuleFor(c => c.Code).NotNull().NotEmpty().Length(3, 9).MustAsync(IsCourseCodeAlreadyExist)
                .WithMessage("The course code already exist!!!");
        }

        private async Task<bool> IsCourseNameAlreadyExist(string courseName, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(courseName))
                return true;

            var requireService = _serviceProvider.GetRequiredService<ICourseService>();
            var isNameExist = await requireService.IsCourseNameAlreadyExist(courseName);

            return ! isNameExist;
        }

        private async Task<bool> IsCourseCodeAlreadyExist(string courseCode, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(courseCode))
                return true;

            var requireService = _serviceProvider.GetRequiredService<ICourseService>();
            var isCodeExist = await requireService.IsCourseCodeAlreadyExist(courseCode);

            return ! isCodeExist;
        }

    }
}
