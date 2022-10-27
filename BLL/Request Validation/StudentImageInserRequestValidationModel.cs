using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Request_Validation
{
    public class StudentImageInserRequestValidationModel
    {
        public string StudentName { get; set; }
        public IFormFile  StudentImage { get; set; }
    }
}
