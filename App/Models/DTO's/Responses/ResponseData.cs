namespace Models.DTO_s.Responses
{
    public class ResponseData<T> : Response
    {
        public T Data { get; set; }
    }
}
