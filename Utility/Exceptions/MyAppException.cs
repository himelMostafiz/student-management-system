using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Exceptions
{
    public class MyAppException : Exception
    {
        public MyAppException(string message) : base(message)
        {

        }
    }
}
