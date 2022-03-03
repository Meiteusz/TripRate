using System;

namespace Models.DTO_s.CustomExceptions
{
    public class FailedToFindEntity<T> : Exception
    {
        public FailedToFindEntity()
        {
            new Exception("Failed");
        }
    }
}
