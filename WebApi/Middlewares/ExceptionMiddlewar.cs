using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Utility.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Utility.Exceptions;
using Newtonsoft.Json;

namespace WebApi.Middlewares
{
    public class ExceptionMiddlewar
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        public ExceptionMiddlewar(RequestDelegate next, IWebHostEnvironment env) 
        {
            _next = next;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex,_env);
            }
            // Call the next delegate/middleware in the pipeline
          
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception, IWebHostEnvironment _env)
        {
            var code = HttpStatusCode.InternalServerError;
            var error = new ApiResponseError() { StatusCode =(int)code };

            if (_env.IsDevelopment())
            {
                error.Details = exception.StackTrace;
                error.ActualErrorMessage = exception.Message;
            }
            else {
                error.Details = exception.Message;
            }

            switch (exception)
            {
                case ApplicationValidationException e:
                    error.Message = e.Message;
                    error.StatusCode = (int) HttpStatusCode.UnprocessableEntity;
                    break;
                default:
                    error.Message = "Something is wrong in our system.";
                    error.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;

            }

            var result = JsonConvert.SerializeObject(error);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = error.StatusCode;

            await context.Response.WriteAsync(result); 

        }

    }
}
