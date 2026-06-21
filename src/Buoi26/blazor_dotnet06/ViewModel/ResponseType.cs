// file nay de hung du lieu tu server ve

public class ResponseType<T>
{
   public int statusCode { get; set; }
   public string? message { get; set; }
   public DateTime dateTime { get; set; }
   public T content { get; set; }

   // void main ()
    // {
    //     var item = new ResponseType<ProductHeaderValue[]>();
    // }
}


