CREATE DATABASE QuanLyNhanVien;
USE QuanLyNhanVien;

CREATE TABLE NhanVien (
    Id INT PRIMARY KEY IDENTITY(1,1),
    TenNV NVARCHAR(100) NOT NULL,
    NgaySinh DATE NOT NULL,
    DiaChi NVARCHAR(255) NOT NULL,
    SoDienThoai NVARCHAR(15) NOT NULL,
    MaPB INT NOT NULL

);


CREATE TABLE PhongBan (
    Id INT PRIMARY KEY IDENTITY(1,1),
    TenPB NVARCHAR(100) NOT NULL
);

/*Tạo khoá ngoại*/
ALTER TABLE NhanVien
ADD CONSTRAINT FK_NhanVien_PhongBan
FOREIGN KEY (MaPB) REFERENCES PhongBan(Id);

-- them 3 phong ban: Kế toán, Nhân sự, CNTT
INSERT INTO PhongBan (TenPB) VALUES ('Kế toán');
INSERT INTO PhongBan (TenPB) VALUES ('Nhân sự');
INSERT INTO PhongBan (TenPB) VALUES ('CNTT');

/*Thêm dữ liệu cho 10 nhân viên rãi đều 3 phòng ban*/
INSERT INTO NhanVien (TenNV, NgaySinh, DiaChi, SoDienThoai, MaPB) VALUES ('Nguyen Van A', '1990-01-01', '123 Đường ABC', '0123456789', 1);
INSERT INTO NhanVien (TenNV, NgaySinh, DiaChi, SoDienThoai, MaPB) VALUES ('Tran Thi B', '1992-02-02', '456 Đường DEF', '0987654321', 2);
INSERT INTO NhanVien (TenNV, NgaySinh, DiaChi, SoDienThoai, MaPB) VALUES ('Le Van C', '1988-03-03', '789 Đường GHI', '0112233445', 3);
INSERT INTO NhanVien (TenNV, NgaySinh, DiaChi, SoDienThoai, MaPB) VALUES ('Pham Thi D', '1991-04-04', '321 Đường JKL', '0223344556', 1);
INSERT INTO NhanVien (TenNV, NgaySinh, DiaChi, SoDienThoai, MaPB) VALUES ('Hoang Van E', '1989-05-05', '654 Đường MNO', '0334455667', 2);
INSERT INTO NhanVien (TenNV, NgaySinh, DiaChi, SoDienThoai, MaPB) VALUES ('Vu Thi F', '1993-06-06', '987 Đường PQR', '0445566778', 3);
INSERT INTO NhanVien (TenNV, NgaySinh, DiaChi, SoDienThoai, MaPB) VALUES ('Do Van G', '1990-07-07', '123 Đường STU', '0556677889', 1);
INSERT INTO NhanVien (TenNV, NgaySinh, DiaChi, SoDienThoai, MaPB) VALUES ('Nguyen Thi H', '1992-08-08', '456 Đường VWX', '0667788990', 2);
INSERT INTO NhanVien (TenNV, NgaySinh, DiaChi, SoDienThoai, MaPB) VALUES ('Le Van I', '1988-09-09', '789 Đường YZ', '0778899001', 3);
INSERT INTO NhanVien (TenNV, NgaySinh, DiaChi, SoDienThoai, MaPB) VALUES ('Pham Thi J', '1991-10-10', '321 Đường ABC', '0889900112', 1); 

-- tao them table Nhậm Chức cho nhân viên quan hệ 1-1
CREATE TABLE NhamChuc (
    Id INT PRIMARY KEY IDENTITY(1,1),
    TenChucVu NVARCHAR(100) NOT NULL,
    IdNhanVien INT NOT NULL,
    FOREIGN KEY (IdNhanVien) REFERENCES NhanVien(Id)
);


