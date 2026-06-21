/*
B1: tao databaseva table
*/

CREATE DATABASE QuanLyBanHang;
USE QuanLyBanHang;

CREATE TABLE KhachHang (
    Id INT PRIMARY KEY IDENTITY(1,1),
    TenKH NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255),
    SoDienThoai NVARCHAR(15),
    DiaChi NVARCHAR(255)
);

CREATE TABLE DonHang (
    Id INT PRIMARY KEY IDENTITY(1,1),
    NgayDat DATETIME,
    TongTien DECIMAL(18, 2),
    MaKhachHang INT
);

CREATE TABLE SanPham (
    Id INT PRIMARY KEY IDENTITY(1,1),
    TenSP NVARCHAR(255) NOT NULL,
    Gia DECIMAL(18, 2),
    SoLuong INT,
    HinhAnh NVARCHAR(255)
);

-- gap quan he nhieu nhieu ==> sinh ra table thu 3 luu khoa chinh tu 2 table lien quan
CREATE TABLE ChiTietDonHang (
    IdDonHang INT,
    IdSanPham INT,
    SoLuong INT,
    Gia DECIMAL(18, 2)
);

-- drop table chi tiet don hang
DROP TABLE ChiTietDonHang;

-- B2: Tao rang buoc toan ven giua cac table(quanhe/thuc the)
ALTER TABLE DonHang
ADD CONSTRAINT FK_DonHang_KhachHang 
FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(Id);

ALTER TABLE ChiTietDonHang
ADD CONSTRAINT FK_ChiTietDonHang_DonHang
FOREIGN KEY (IdDonHang) REFERENCES DonHang(Id);

ALTER TABLE ChiTietDonHang
ADD CONSTRAINT FK_ChiTietDonHang_SanPham
FOREIGN KEY (IdSanPham) REFERENCES SanPham(Id);

-- rang buoc cap khoa chinh cho chi tiet don hang
ALTER TABLE ChiTietDonHang
ADD CONSTRAINT PK_ChiTietDonHang
PRIMARY KEY (IdDonHang, IdSanPham);



-- tao 10 khac hang
INSERT INTO KhachHang (TenKH, Email, SoDienThoai, DiaChi)
VALUES
(N'Nguyễn Văn A', 'nguyenvana@email.com', '0123456789', '123 Đường ABC, Quận XYZ'),
(N'Lê Thị B', 'lethib@email.com', '0987654321', '456 Đường DEF, Quận GHI'),
(N'Trần Văn C', 'tranvanc@email.com', '0123456788', '789 Đường JKL, Quận MNO'),
(N'Phạm Thị D', 'phamthid@email.com', '0987654320', '012 Đường PQR, Quận STU'),
(N'Hoàng Văn E', 'hoangvana@email.com', '0123456787', '345 Đường VWX, Quận YZ'),
(N'Nguyễn Thị F', 'nguyenthib@email.com', '0987654319', '678 Đường ABC, Quận XYZ'),
(N'Lý Văn G', 'lyvang@email.com', '0123456786', '901 Đường DEF, Quận GHI'),
(N'Vũ Thị H', 'vuthih@email.com', '0987654318', '234 Đường JKL, Quận MNO'),
(N'Đỗ Văn I', 'dovana@email.com', '0123456785', '567 Đường PQR, Quận STU'),
(N'Bùi Thị J', 'buithij@email.com', '0987654317', '890 Đường VWX, Quận YZ');

-- tao 10 don hang voi 10 khach hang tuong ung
INSERT INTO DonHang (NgayDat, TongTien, MaKhachHang)
VALUES
('2024-01-01', 1000000, 1),
('2024-01-02', 1500000, 2),
('2024-01-03', 2000000, 3),
('2024-01-04', 2500000, 4),
('2024-01-05', 3000000, 5),
('2024-01-06', 3500000, 6),
('2024-01-07', 4000000, 7),
('2024-01-08', 4500000, 8),
('2024-01-09', 5000000, 9),
('2024-01-10', 5500000, 10);

-- tao 10 san pham
INSERT INTO SanPham (TenSP, Gia, SoLuong, HinhAnh)
VALUES
(N'Laptop Dell XPS 13', 15000000, 10, 'dell_xps_13.jpg'),
(N'Điện thoại Samsung Galaxy S21', 20000000, 20, 'samsung_galaxy_s21.jpg'),
(N'Ti vi LG OLED55', 30000000, 5, 'lg_oled55.jpg'),
(N'Máy tính bảng Apple iPad Pro', 25000000, 15, 'ipad_pro.jpg'),
(N'Loa Bluetooth JBL Flip 5', 2000000, 30, 'jbl_flip_5.jpg'),
(N'Camera hành trình GoPro Hero 9', 5000000, 8, 'gopro_hero_9.jpg'),
(N'Bàn phím cơ Logitech G Pro', 3000000, 12, 'logitech_g_pro.jpg'),
(N'Monitor ASUS ROG Swift PG27UQ', 35000000, 4, 'asus_rog_swift_pg27uq.jpg'),
(N'Ổ cứng SSD Samsung 970 EVO Plus', 4000000, 25, 'samsung_970_evo_plus.jpg'),
(N'Chuột gaming Razer DeathAdder V2', 1500000, 18, 'razer_deathadder_v2.jpg');

-- tao chi tiet don hang cho 10 don hang tuong ung voi 10 san pham
INSERT INTO ChiTietDonHang (IdDonHang, IdSanPham, SoLuong, Gia)
VALUES
(1, 1, 1, 15000000),
(2, 2, 1, 20000000),
(3, 3, 1, 30000000),
(4, 4, 1, 25000000),
(5, 5, 2, 4000000),
(6, 6, 1, 5000000),
(7, 7, 1, 3000000),
(8, 8, 1, 35000000),
(9, 9, 2, 8000000),
(10, 10, 1, 1500000);



--------------- bai tap 
-- Create tables without foreign key constraints
CREATE TABLE  QuocGia (
    MaQuocGia INT IDENTITY(1,1) PRIMARY KEY,
    TenQuocGia nVARCHAR(200) NOT NULL
) 

CREATE TABLE  TheLoai (
    MaTheLoai INT IDENTITY(1,1) PRIMARY KEY,
    TenTheLoai nVARCHAR(150) NOT NULL
) 

CREATE TABLE Phim (
    MaPhim INT IDENTITY(1,1) PRIMARY KEY,
    TenPhim nVARCHAR(255) NOT NULL,
    HinhAnh nVARCHAR(500),
    MoTa TEXT,
    NgayChieu DATE,
    DanhGia DECIMAL(3,1),
    MaQuocGia INT NOT NULL
) 

CREATE TABLE  Phim_TheLoai (
    MaPhim INT NOT NULL,
    MaTheLoai INT NOT NULL,
    PRIMARY KEY (MaPhim, MaTheLoai)
) 

-- Add foreign key constraints
ALTER TABLE Phim
ADD CONSTRAINT FK_Phim_QuocGia 
FOREIGN KEY (MaQuocGia) REFERENCES QuocGia(MaQuocGia)
ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE Phim_TheLoai
ADD CONSTRAINT FK_PhimTheLoai_Phim 
FOREIGN KEY (MaPhim) REFERENCES Phim(MaPhim) 
ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE Phim_TheLoai
ADD CONSTRAINT FK_PhimTheLoai_TheLoai 
FOREIGN KEY (MaTheLoai) REFERENCES TheLoai(MaTheLoai) 
ON DELETE CASCADE ON UPDATE CASCADE;

-- drop cac table: Phim_TheLoai, Phim, TheLoai, QuocGia
DROP TABLE Phim_TheLoai;
DROP TABLE Phim;
DROP TABLE TheLoai;
DROP TABLE QuocGia;