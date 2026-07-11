/* liet ke tat ca nhan vien thuoc phong ban cong nghe thong tin
 Bao gom: Id Nhan vie, ten nhan vie, ngay sinh, dia chi, so dien tohai, ma phong ban, ten phong ban
*/
USE QuanLyNhanVien

SELECT NV.Id, NV.TenNV, NV.NgaySinh, NV.DiaChi, NV.SoDienThoai, NV.MaPB, PB.TenPB
FROM NhanVien NV, PhongBan PB
WHERE NV.MaPB = PB.Id
AND PB.TenPB LIKE 'CNTT'

SELECT NV.Id, NV.TenNV, NV.NgaySinh, NV.DiaChi, NV.SoDienThoai, NV.MaPB, PB.TenPB
FROM NhanVien NV INNER JOIN PhongBan PB ON NV.MaPB = PB.Id
WHERE PB.TenPB LIKE 'CNTT'

/* 
  Them table Dự Án
  Id, TenDuAn, NgayBatDau, NgayKetThuc
*/

CREATE TABLE DuAn (
  Id INT PRIMARY KEY IDENTITY(1,1),
  TenDuAn NVARCHAR(255) NOT NULL,
  MoTa NVARCHAR(255),
  NgayBatDau DATE,
  NgayKetThuc DATE,
    MaDiaDiem INT
)

/* 
  Them table Địa điểm
  Id, TenDiaDiem, DiaChi
*/
CREATE TABLE DiaDiem (
  Id INT PRIMARY KEY IDENTITY(1,1),
  TenDiaDiem NVARCHAR(255) NOT NULL,
  DiaChi NVARCHAR(255)
)

/*Tạo ràng buộc khoá ngoại cho bảng DuAn -> DiaDiem*/
ALTER TABLE DuAn
ADD CONSTRAINT FK_DuAn_DiaDiem
FOREIGN KEY (MaDiaDiem) REFERENCES DiaDiem(Id);

/*Tạo table nhân viên dự án(N-N) 1 nhân viên tham gia được nhiều dự án, 1 dự án có nhiều nhân viên tham gia*/
CREATE TABLE NhanVien_Duan (
    MaNhanVien INT,
    MaDuAn INT,
    PRIMARY KEY (MaNhanVien, MaDuAn),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(Id),
    FOREIGN KEY (MaDuAn) REFERENCES DuAn(Id)
);



INSERT INTO DuAn (TenDuAn, MoTa, NgayBatDau, NgayKetThuc, MaDiaDiem)
VALUES (N'Dự Án AI', N'Dự án phát triển ứng dụng AI', '2026-06-02', '2026-12-02', 2);

INSERT INTO DiaDiem (TenDiaDiem, DiaChi)
VALUES (N'Training AI', N'112 cao thắng, lầu 5 quận 3');



INSERT INTO NhanVien_Duan (MaNhanVien, MaDuAn)
VALUES (1, 3), (2, 3), (3, 3);

/*
Dự án bắt đầu ngày 2-6-2026 và kết thúc ngày 2-12-2026
địa điểm trainning ứng dụng ai: 112 Cao Thắng, lầu 5 quận 3
có 3 nhân viên tham gia Id: 1, 2, 3

 Yêu Cầu:
        Cho biết tên của những nhân viên (Id,TenNV,SoDienThoai,Email,TenPB,TenDiaDiem tham gia dự án) tham gia dự án "Dự Án AI" và địa điểm training của dự án đó ở đâu

        Viết câu lệnh SQL để truy vấn thông tin trên
*/

SELECT 
    NV.Id,
    NV.TenNV,
    NV.SoDienThoai,
    PB.TenPB,
    DD.TenDiaDiem,
    DD.DiaChi
FROM NhanVien NV, PhongBan PB, NhanVien_DuAn NVDA, DuAn DA, DiaDiem DD
WHERE NV.MaPB = PB.Id
AND NV.Id = NVDA.MaNhanVien
AND NVDA.MaDuAn = DA.Id
AND DA.MaDiaDiem = DD.Id
AND DA.TenDuAn = N'Dự Án AI'

-- dotnet ef dbcontext scaffold Name=DBQuanLyNhanVienConnection Microsoft.EntityFrameworkCore.SqlServer -o Models/DBQuanLyNhanVien -c QuanLyNhanVienContext --force
