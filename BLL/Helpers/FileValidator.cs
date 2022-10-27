using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Helpers
{
    public class FileValidator : IFileValidator
    {
        public (bool valid, string errorMessage) validateFile(IFormFile fileToValidate)
        {
            throw new NotImplementedException();
        }
    }
}
