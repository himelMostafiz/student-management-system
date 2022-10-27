using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BLL.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Request_Validation
{
    public class StudentValidator : AbstractValidator<StudentInserRequestValidationModel>
    {
        private readonly IServiceProvider _serviceProvider;

        public StudentValidator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            RuleFor(s => s.Email).NotNull().NotEmpty().Length(15, 45).MustAsync(IsEmailAlreadyExist)
                .WithMessage("Email already exist!!!");
            
            RuleFor(s => s.Email).NotNull().NotEmpty().Length(15, 45).WithMessage("Please provide the sudent name!!!");

        }

        private async Task<bool> IsEmailAlreadyExist(string email, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(email))
                return true;

            var requireService = _serviceProvider.GetRequiredService<IStudentService>();
            var isEmailExist = await requireService.IsStudentEmailAlreadyExist(email);

            return !isEmailExist;
        }

    }
}
