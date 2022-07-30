namespace MyWebAPIs.AnyDataEndpoints.Model
{
    public class Request<T>
    {
        public T Header { get; set; }
        public T Payload { get; set; }
    }
}
