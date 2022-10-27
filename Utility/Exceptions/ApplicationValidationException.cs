using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Exceptions
{
    public class ApplicationValidationException : Exception
    {
        public ApplicationValidationException(string message):base(message)
        {

        }
    }
}
