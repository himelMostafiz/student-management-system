using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Request_Validation
{
    public class StudentInserRequestValidationModel
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
