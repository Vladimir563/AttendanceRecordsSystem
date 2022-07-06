using System;


#pragma warning disable CS1591
namespace AttendanceRecordsSystem.WebApp.Authentication
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException()
        {
        }

        public InvalidCredentialsException(string message) : base(message)
        {
        }

        public InvalidCredentialsException(string message,
            Exception exception) : base(message, exception)
        {
        }
    }
}
