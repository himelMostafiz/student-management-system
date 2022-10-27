using DLL.ModelInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.Models
{
    public class StudentImage : ITrackable, ISoftDelete
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string ImageUrl { get; set; }
        public string CreatedBy { get ; set ; }
        public DateTimeOffset CreatedAt { get ; set ; }
        public string UpdatedBy { get ; set ; }
        public DateTimeOffset UpdatedAt { get ; set ; }
    }
}
