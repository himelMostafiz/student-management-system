using DLL.ModelInterfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.Models
{
    public class AppUser : IdentityUser<int>, ITrackable, ISoftDelete
    {
        public string FullName { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public virtual ICollection<AppUserRole> AppUserRoles { get; set; }
        
    }
}
