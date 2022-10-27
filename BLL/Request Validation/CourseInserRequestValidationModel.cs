using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Request_Validation
{
    public class CourseInserRequestValidationModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Credit { get; set; }
    }
}
