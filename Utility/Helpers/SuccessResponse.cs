using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Helpers
{
    public class SuccessResponse
    {
        public string Message { get; set; }
        public string DeveloperMessage { get; set; }
        public int StatusCode { get; set; }
    }
}
