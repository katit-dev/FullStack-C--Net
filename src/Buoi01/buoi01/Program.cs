// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

Console.WriteLine("Hello, World!");

// Program.cs: mặc định là file khởi động của ứng dụng .Net, nó sẽ chạy mặc định hàm Main khi ứng dụng được khởi tạo
// .csproj: file cấu hình của dự án, thiết lập các thông tin như tên dự án, phiên bản, các thư viện tham chiếu, các thiết lập build,..
// bin: chứa output của dự án khi build
// obj: chứa các file tạm thời được tạo ra trong quá trình build dự án
// terminal dùng để chạy những lệnh bắt đầu bằng dotnet


// biến: là 1 vùng nhớ đặt tên, dùng để lưu trữ dữ liệu trong quá trình chương trình chạy
// cú pháp khai báo biến trong C#
var ten = "Nguyen";
Console.WriteLine("Hello " + ten);
// day la cach noi chuoi trong C# dung dou +

// KIEU DU LIEU
// chia pham vi dữ liệu mà 1 biến có thể chứa
// VD thực tế: ly để thịt sống và ly uống nước
// VD lập trình: biến chứa số tài sản (là những con số), biến tên người yêu cũ(là chuỗi)


// cú pháp
// <kiểu dữ liệu> <tên biến> = <giá trị khởi tạo>
// kiểu dữ liệu : xác định phạm v dữ liệu mà biến có thể lưu trữ
// dữ liệu số nguyên                        int
// dữ liệu số không nguyễn ==> số thực      double, float
// dữ liệu chuỗi, ký tự                     string
// dữ liệu đúng sai true/false              bool(boolean)
// dữ liệu ký tự đơn, 1 ký tự               chả ( 1 ký tự ví dụ 'a', 'b', '1', '@'....)
// dữ liệu tiền tệ                          decimal

// var là từ khóa khai báo biến đơn giản, tự động xác định kiểu dữ liệu dựa trên giá trị khởi tạo
// var number; //khai bao bien ma khong khoi tao gia tri ==> error 
var soTaisan = 10; // tự động hiểu là kiểu int
var diemTrungBinh = 8.5; // tự động hiểu là kiểu double
var ten2 = "Nguyen"; // tự động hiểu là kiểu string


// khai báo biến có kiểu dữ liệu rõ ràng
int soTaiSan1 = 10;
double diemTrungBinh1  = 8.5;
string tenNguoiYeuCu1 = "Phương Nga";
bool dangCoNguoiYeu1 = false;
Console.WriteLine("So tai san " + soTaisan);// cong chuoi

// Quy tắc đặt tên biến
/*
- tên biến không được trùng nhau
- không được bắt đầu bằng số
- viết liền không chứa khoảng cách
- không chứa ký tự đặc biệt trừ dấu gạch dước "_"
- khonng sử dụng từ khóa của ngôn ngữ, vd: int, vả, class, public, void, ...
*/

// Quy ước
/*
- camelCase: chữ cái đầu tiên của từ đầu viết thường, chữ cái đầu của các từ sau viết hoa, vd: soLuong
- PascalCase: chữ cái dầu tiền của tất cả các từ viết hoa, vd: SoLuong
- đặt tên biến có ý nghĩa, dễ hiểu
- Biến có thể thay đổi giá trị trong quá trình chương trình chạy bằng cách gán lại giá trị mới cho biến đó
VD: int soLuong = 10;
soLuong = 20; // gán giá trị mới cho biến soLuong
*/

//Output
// Console.Write(""); va Console.WriteLine("");
Console.Write("hello");
Console.Write("world");
Console.WriteLine();
Console.WriteLine("hello");
Console.WriteLine("world");


// input
//Console.ReadLine(); // lệnh chờ nhập dữ liệu từ bàn phím, kết thúc bằng phím Enter
// Cần có câu dẫn nhập dữ liệu từ bàn phím
Console.Write("Mời bạn nhập tên: ");
var tenNguoiDung = Console.ReadLine(); // dữ liệu nhập vào sữ được gán cho biến tenNguoiDung
Console.WriteLine("Xin chào " + tenNguoiDung);
// Console.ReadLine() luông trả về kiểu dữ liệu string dù nhập số hay ký tự
// nếu muốn chuyển đổi kiểu dữ liệu thì cần ép kiêu


//----------------------------------------------------------------------------------------------------------------
// BT nhỏ 
// nhập vào tên và tuổi từ bàn phím và in ra màn hình câu "chào" + ten_ban + ", " + tuoi_ban + " tuoi"
/*
B1: In câu mời nhập tên
B2: Khai báo biến ten_ban để lưu trữ tên nhập từ bàn phím 
B3: In câu mời nhập tuổi
B4: Khai báo biến tuoi_ban để lưu trữ tuổi nhập từ bàn phím
B5: In ra màn hình
*/

Console.Write("Mời bạn nhập tên: ");
var ten_ban = Console.ReadLine();
Console.Write("Mời bạn nhập tuổi: ");
var tuoi_ban = Console.ReadLine();
Console.WriteLine("Chao " + ten_ban + ", " + tuoi_ban + " tuoi");
Console.WriteLine($"Hello {ten_ban}, {tuoi_ban} tuoi"); // cach dung string interpolation

//----------------------------------------------------------------------------------------------------------------


Console.ForegroundColor = ConsoleColor.Yellow;// bắt đầu đổi màu chữ
Console.WriteLine("Text");
Console.ResetColor();// reset về màu mặc định

// --------------------------------------------------------------------------------------------------------
// Toán tử trong C#
// toán tử số học: +, -, *, /, %
Console.ForegroundColor = ConsoleColor.DarkRed;
int a = 10;
int b =3;
int tong = a + b;  // 10 + 3 = 13
int hieu = a - b;  // 10 - 3 = 7
int tich = a * b;  // 10 * 3 = 30
int thuong = a / b; // 10 / 3 phép chia lấy phần nguyên
int du = a % b;    // 10 % 3 phép chia lấy phần dư 1
Console.WriteLine("Tổng a và b là " + tong);
Console.WriteLine($"Hieu a va b la {hieu}");
Console.WriteLine($"Tich cua a va ba la {tich}");
Console.WriteLine($"Thuong cua a va b la {thuong}");
Console.WriteLine($"Du cua a va b la {du}");
Console.ResetColor();


// Toán tử gán 
// = : gán giá trị cho biến. VD:  a = 20
// += : tăng giá trị biến lên n giá trị. VD: a += n => a = a + n
a +=1 ; // a  = a + 1;
b += 99; // b = b + 99;

// -= : giảm giá trị biến đi n giá trị. VD: a -= n => a = a - n
a -= 2; // a = a - 2 
// *= : nhân giá trị biến với n giá trị. VD: a *= n => a = a * n
b *= 2; // b = b * 2
// /= : chia giá trị biến cho n giá trị. VD: a /= n => a = a / n
b /= 3; // b = b / 3
// %= : lấy phần dư giá trị biến chia cho n giá trị. VD: a %= n => a = a % n
a %= 3; // a = a % 3


int c =101; // khởi nghiệp với 101
c+=100; // c = 101 + 100  => 201 , gán cho c giá trị mới  => 201
Console.WriteLine($"Giá trị c sau khi +=100 là {c}"); // 201
c-=50; // c = 201 - 50 => 151 , gán cho c giá trị mới // 
Console.WriteLine($"Giá trị c sau khi -=50 là {c}"); // 151