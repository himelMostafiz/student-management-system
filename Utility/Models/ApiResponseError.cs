using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Models
{
    public class ApiResponseError
    {
        public string Message { get; set; }
        public string ActualErrorMessage { get; set; }
        public string Details { get; set; }
        public bool IsSuccess { get; set; } = false;
        public int StatusCode { get; set; }
    }
}
