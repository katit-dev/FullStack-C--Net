-- liet ke all nhan vien thuoc phong ban cntt
-- bao gom: id nhan vie, ten nv, ngay sinh, dia chia, ma pb, ten pb

USE QuanLyNhanVien;

SELECT nv.Id, nv.TenNV, nv.NgaySinh, nv.DiaChi, pb.Id, pb.TenPB
FROM NhanVien nv, PhongBan pb
WHERE nv.MaPB = pb.Id AND pb.TenPB LIKE '%CNTT'

SELECT nv.Id, nv.TenNV, nv.NgaySinh, nv.DiaChi, pb.Id, pb.TenPB
FROM NhanVien nv
INNER JOIN PhongBan pb 
ON nv.MaPB = pb.Id
WHERE pb.TenPB LIKE '%CNTT'


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
VALUES (N'Dự Án AI', N'Dự án phát triển ứng dụng AI', '2026-06-02', '2026-12-02', 1);

INSERT INTO DiaDiem (TenDiaDiem, DiaChi)
VALUES (N'Training AI', N'112 cao thắng, lầu 5 quận 3');



INSERT INTO NhanVien_Duan (MaNhanVien, MaDuAn)
VALUES (1, 1), (2, 1), (3, 1);

/*
Dự án bắt đầu ngày 2-6-2026 và kết thúc ngày 2-12-2026
địa điểm trainning ứng dụng ai: 112 Cao Thắng, lầu 5 quận 3
có 3 nhân viên tham gia Id: 1, 2, 3

 Yêu Cầu:
        Cho biết tên của những nhân viên (Id,TenNV,SoDienThoai,Email,TenPB,TenDiaDiem tham gia dự án) tham gia dự án "Dự Án AI" và địa điểm training của dự án đó ở đâu

        Viết câu lệnh SQL để truy vấn thông tin trên
*/

SELECT nv.Id, nv.TenNV, nv.SoDienThoai, pb.TenPB, dd.TenDiaDiem
FROM NhanVien nv, PhongBan pb, DuAn da, NhanVien_Duan nvda, DiaDiem dd 
WHERE nv.MaPB = pb.Id
AND nv.Id = nvda.MaNhanVien
AND nvda.MaDuAn = da.Id
AND da.MaDiaDiem = dd.Id
AND da.TenDuAn LIKE N'%Dự Án AI'

