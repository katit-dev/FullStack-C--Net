public class ResponseTypeDTO<T>
{
   // status code, message, data
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public T Content { get; set; }
    public DateTime Date { get; set; }

}
