using System;

namespace Models.DTO_s.Responses
{
    public class ResponseException : Response
    {
        public Exception Exception { get; set; }
    }
}
