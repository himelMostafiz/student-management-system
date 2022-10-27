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
    public class DepartmentInserRequestValidationModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class DepartmentValidator : AbstractValidator<DepartmentInserRequestValidationModel>
    {
        private readonly IServiceProvider _serviceProvider;
        public DepartmentValidator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            //RuleFor(x => x.Code).NotNull().NotEmpty().Length(2, 9).WithMessage("Department code should not null or empty.The code should range from 2 to 9 characters.").MustAsync(IsCodeAlreadyExist);
            //RuleFor(x => x.Name).NotNull().NotEmpty().Length(9, 50).WithMessage("Department name should not null or empty. Name must be 9 to 50 characters long.").MustAsync(IsNameAlreadyExist);

            RuleFor(x => x.Code).NotNull().NotEmpty().Length(2, 9)
                .MustAsync(IsCodeAlreadyExist).WithMessage("The department code already exist !!!");
            RuleFor(x => x.Name).NotNull().NotEmpty().Length(9, 50).MustAsync(IsNameAlreadyExist)
                .WithMessage("The department namee already exist !!!");

        }
        private async Task<bool> IsCodeAlreadyExist(string code, CancellationToken arg2)
        {
            if (!string.IsNullOrEmpty(code))
            {
                return true;
            }

            var requireService = _serviceProvider.GetRequiredService<IDepartmentService>();
            return await requireService.IsDepartmentCodeAlreadyExist(code);
        }
        private async Task<bool> IsNameAlreadyExist(string name, CancellationToken arg2)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return true;
            }

            var requireService = _serviceProvider.GetRequiredService<IDepartmentService>();
            return await requireService.IsDepartmentNameAlreadyExist(name);
        }

       
    }
}
