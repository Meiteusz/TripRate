using System.Collections.Generic;

namespace Models.DTO_s.Responses
{
    public class ResponseQuery<T> : Response
    {
        public IList<T> Query { get; set; } = new List<T>();
    }
}
