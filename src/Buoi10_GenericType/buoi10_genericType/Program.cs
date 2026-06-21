class Program
{
    public static void Main(string[] args)
    {
        // var box1 = new BlindBox<string>(); // khoi tao đối tượng box1 với kiểu dữ liệu string
        // box1.Ten = "Gấu bông";
        // box1.HienThi();

        // var box2 = new BlindBox<int>(); // khoi tao đối tượng box2 với kiểu dữ liệu int
        // box2.Ten = 123;
        // box2.HienThi();
        
        // viet ra bo crud dung chung generic type BlindBox<T>
        var crud = new CRUD<string>(); // khoi tao đối tượng crud với kiểu dữ liệu string
        crud.Create("item 1");
        crud.Create("item 2");
        crud.HienThi();


        /*Activitor: khoi tao khong dung new 
        vd: hinh vuong
        var hv1 = new HinhVuong();
        var hv2 = Activator.CreateInstance<HinhVuong>(); // khoi tao doi tuong hv2 bang activator
        var hv3 = Activator.CreateInstance(typeof(HinhVuong)) as HinhVuong; // khoi tao doi tuong hv3 bang activator va ep kieu ve hinh vuong
        

        */



    }
}


