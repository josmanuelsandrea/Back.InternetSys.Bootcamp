namespace InternetSystem.Models
{
    public class GenericResponse<T>
    {
        public GenericResponse()
        {
            message = "Resource not found";
            statusCode = 404;
        }
        public int statusCode { get; set; }
        public T? data { get; set; }
        public string? message { get; set; }
    }
}