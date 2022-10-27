using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace BLL.Helpers
{
    public interface IFileValidator
    {
        (bool valid, string errorMessage) validateFile(IFormFile fileToValidate);
    }
}
