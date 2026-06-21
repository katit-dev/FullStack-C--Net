/* chan ke thua trong oop 2
- khi mot class khong muon class khac ke thua no, thi ta co the danh dau no la sealed
- mot class ke thua tu class sealed se bi loi

- khong cho phep class ke thua tu class sealed

*/
// public sealed class TaiSan
// {
//     public string TenTaiSan;
//     public double GiaTri;
//     public void HienThiThongTin()
//     {
//         System.Console.WriteLine("Ten tai san: " + TenTaiSan);
//         System.Console.WriteLine("Gia tri: " + GiaTri);
//     }
// }

// public class TaiSanKeThua : TaiSan
// {
//     // class nay se bi loi vi class TaiSan da bi danh dau la sealed
// }

// /* chan ghi de: sealed method

// */
// public class User
// {
//     public virtual void Work()
//     {
//         System.Console.WriteLine("User is working");
//     }
// }
//  public class SuperAdmin : User
// {
//     public sealed override void Work()
//     {
//         System.Console.WriteLine("Admin is working");
//     }
// }

// public class Admin : SuperAdmin
// {
//     // class nay se bi loi vi method Work() trong class SuperAdmin da bi danh dau la sealed
//     // public override void Work()
//     // {
//     //     System.Console.WriteLine("Admin is working");
//     // }
// }

/*
chan ke thua: sealed class
- nhung truong hop su dung sealed 
- class da hoan thien
- cong thuc tinh toan co dinh
- dam bao tinh toan ven va tranh thay doi ngoai y muon
*/