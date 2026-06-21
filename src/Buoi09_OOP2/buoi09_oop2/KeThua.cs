/*
 Ke thua trong OOP
 - class con kế thừa thuộc tính và phương thức từ class cha
 - vd: 
 class KhungLong()
 {

 }

 class ConGa : KhungLong
 {

 }

 - con gà là class con kế thừa từ class cha khủng long
 - con gà là class dẫn xuất: derived class
    - khủng long là class cơ sở: base class


*/
// class HocVien
// {
//     public string HoTen;
//     public int Tuoi;

//     public void DiHoc()
//     {
//         System.Console.WriteLine(HoTen + " di hoc");
//     }
// }

// class Mentor
// {
//     public string HoTen;
//     public int Tuoi;

//     public void DiLam()
//     {
//         System.Console.WriteLine(HoTen + " di lam");
//     }
// }

// class GiangVien
// {
//     public string HoTen;
//     public int Tuoi;

//     public void DiDay()
//     {
//         System.Console.WriteLine(HoTen + " di day");
//     }
// }

class NguoiDung
{
    public string Name;
    public int Age;
    public string Role;
    private string Password; // chi class NguoiDung moi truy cap duoc
    protected string chiaKhoa; // class con co the truy cap duoc

    // constructor mac dinh
    // public NguoiDung()
    // {
    //     Console.WriteLine("constructor nguoi dund");
    // }
    // class con se mac dinh goi den constructor khong tham so nay

    public NguoiDung(string name, int age, string role)
    {
        Name = name;
        Age = age;
        Role = role;
    }

    // method
    public virtual void ShowInfo()
    {
        System.Console.WriteLine("Name: " + Name);
        System.Console.WriteLine("Age: " + Age);
        System.Console.WriteLine("Role: " + Role);
    }

}


class Mentor : NguoiDung
{
   // metor ke thua tu NguoiDung, nhung chi nhung cai public va protected
   // protected: chi class con moi truy cap duoc, program ben ngoai khong truy cap duoc
   // metor co Name, Age, Role va ShowInfo() cua class NguoiDung

    // them thuoc tinh rieng
    public int HeSoLuong;

    // khi tao doi tuong Mentor
    // se goi den constructor cua class cha NguoiDung truoc
    // sau do moi den constructor cua Mentor
    // public Mentor()
    // {
    //     Console.WriteLine("constructor mentor");
    // }

    public Mentor(string name, int age, string role, int heSoLuong)
        : base(name, age, role) // goi den constructor cua class cha
    {
        HeSoLuong = heSoLuong;
    }

   // Mentor co the co them thuoc tinh va phuong thuc rieng
   public void ChamBaiTap()
   {
    System.Console.WriteLine(Name + " cham bai tap");
   }

   public void DiemDanh()
   {
    System.Console.WriteLine(Name + " diem danh");
   }

   // class NguoiDung co ham ShowInfo(): chi co Name, Age, Role
    // neu muon hien thi them HeSoLuong can override ham ShowInfo()
    // override: ghi de 
    // cho phep con dinh nghia lai phuong thuc cua cha
    // la phuong tien tao ra tinh da hinh (Polymorphism)
    public override void ShowInfo()
    {
        Console.WriteLine($"{Name} - {Age} tuoi - Vai tro: {Role} - He so luong: {HeSoLuong}");
    }


}