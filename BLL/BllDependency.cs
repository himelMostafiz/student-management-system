using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BLL.Services;
using FluentValidation;
using BLL.Request_Validation;

namespace BLL
{
    public static class BllDependency
    {
        public static void AllDependencies(IServiceCollection services, IConfiguration Configuration)
        {

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost";
                options.InstanceName = "PractiseDb";
            });

            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<ICourseStudentService, CourseStudentService>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IStudentImageService, StudentImageService>();

            AllFluentValidationDependencies(services);
        }

        private static void AllFluentValidationDependencies(IServiceCollection services)
        {
            services.AddTransient<IValidator<DepartmentInserRequestValidationModel>, DepartmentValidator>();
            services.AddTransient<IValidator<StudentInserRequestValidationModel>, StudentValidator>();
            services.AddTransient<IValidator<CourseInserRequestValidationModel>, CourseValidator>();
            services.AddTransient<IValidator<CourseEnrollInserRequestValidationModel>, CourseEnrollValidator>();
        }
    }
}
