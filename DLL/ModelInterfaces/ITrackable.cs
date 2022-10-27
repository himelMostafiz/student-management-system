using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.ModelInterfaces
{
    public interface ITrackable
    {
        string CreatedBy { get; set; }
        DateTimeOffset CreatedAt { set; get; }
        string UpdatedBy { get; set; }
        DateTimeOffset UpdatedAt { set; get; }
    }
}
