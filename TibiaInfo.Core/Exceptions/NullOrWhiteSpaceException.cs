using System;

namespace TibiaInfo.Core.Exceptions
{
    public class NullOrWhiteSpaceException : Exception
    {
        public NullOrWhiteSpaceException(string message, Exception ex) 
            : base(message,ex)
        {

        }
    }
}