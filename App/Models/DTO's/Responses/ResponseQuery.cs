using System.Collections.Generic;

namespace Models.DTO_s.Responses
{
    public class ResponseQuery<T> : Response
    {
        public IEnumerable<T> Query { get; set; }
    }
}
