using System;

namespace Models.DTO_s.CustomExceptions
{
    public class FailedToFindEntityException<T> : Exception
    {
        public FailedToFindEntityException()
        {
            new Exception("Failed");
        }
    }

    public class FailedToFindEmailException : Exception
    {
        public FailedToFindEmailException(string email)
        {
            throw new Exception(string.Format("Email {0} not found", email.ToString()));
        }
    }
}
