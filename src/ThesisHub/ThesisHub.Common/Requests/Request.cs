namespace ThesisHub.Common.Requests
{
    public class Request<T> where T : class
    {
        public T Data { get; set; }
    }
}
