using System;

namespace Models
{
    public class Response
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = "Failed";
        public bool throwExcpetion { get; set; } = true;

        public Response() { }
    }
}
