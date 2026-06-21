// blind box: xé túi mù
//
// class là genertic type: kiểu tổng quát
// TenClass<T>: T là kiểu dữ liệu mà mình muốn sử dụng khi tạo đối tượng

class BlindBox<T>
{
   public T Ten { get; set;}

   public void HienThi()
   {
       Console.WriteLine($"Tên: {Ten}");
   }
}