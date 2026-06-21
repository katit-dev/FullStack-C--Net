-- create database QuanLySinhVien
CREATE DATABASE QuanLySinhVien;

-- use database QuanLySinhVien
USE QuanLySinhVien;

-- drop table SinhVien if exists
DROP TABLE IF EXISTS SINHVIEN;

-- xoa table SinhVien  va tao lai table SINHVIEN id tu tang, hoten dia chi la nvarchar
CREATE TABLE SINHVIEN (
    MaSV INT PRIMARY KEY IDENTITY(1,1),
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE NOT NULL,
    GioiTinh BIT NOT NULL,
    DiaChi NVARCHAR(255) NOT NULL,
    DaXoa BIT DEFAULT 0
);

-- insert data into SinhVien table
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Nguyễn Văn A', '2000-01-01', 1, N'Hà Nội', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Nguyễn Văn B', '2000-02-01', 1, N'Hà Nội', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Nguyễn Văn C', '2000-03-01', 1, N'Hà Nội', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Nguyễn Văn D', '2000-04-01', 1, N'Hồ Chí Minh', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Nguyễn Văn E', '2000-05-01', 1, N'Đà Nẵng', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Trần Thị A', '2001-01-10', 0, N'Cần Thơ', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Trần Thị B', '2001-02-10', 0, N'Hải Phòng', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Lê Văn A', '1999-03-15', 1, N'Huế', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Lê Văn B', '1999-04-15', 1, N'Nha Trang', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Phạm Thị A', '2002-05-20', 0, N'Vũng Tàu', 0);

INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Phạm Thị B', '2002-06-20', 0, N'Bình Dương', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Hoàng Văn A', '2001-07-11', 1, N'Đồng Nai', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Hoàng Văn B', '2001-08-11', 1, N'Long An', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Đỗ Thị A', '2000-09-09', 0, N'Tây Ninh', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Đỗ Thị B', '2000-10-09', 0, N'Nam Định', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Bùi Văn A', '1998-11-30', 1, N'Thanh Hóa', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Bùi Văn B', '1998-12-30', 1, N'Nghệ An', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Võ Thị A', '2003-01-25', 0, N'Quảng Nam', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Võ Thị B', '2003-02-25', 0, N'Quảng Ngãi', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Dương Văn A', '2002-03-03', 1, N'Bến Tre', 0);

INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Dương Văn B', '2002-04-03', 1, N'Trà Vinh', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Ngô Thị A', '2001-05-05', 0, N'Sóc Trăng', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Ngô Thị B', '2001-06-05', 0, N'An Giang', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Đặng Văn A', '2000-07-07', 1, N'Kiên Giang', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Đặng Văn B', '2000-08-07', 1, N'Cà Mau', 0);

-- Tiếp tục tương tự đến đủ 100 sinh viên

INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Sinh Viên 26', '2001-01-01', 1, N'Hà Nội', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Sinh Viên 27', '2001-02-01', 0, N'Hồ Chí Minh', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Sinh Viên 28', '2001-03-01', 1, N'Đà Nẵng', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Sinh Viên 29', '2001-04-01', 0, N'Hải Phòng', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Sinh Viên 30', '2001-05-01', 1, N'Cần Thơ', 0);

INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Sinh Viên 31', '2001-06-01', 0, N'Hà Nội', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Sinh Viên 32', '2001-07-01', 1, N'Hồ Chí Minh', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Sinh Viên 33', '2001-08-01', 0, N'Đà Nẵng', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Sinh Viên 34', '2001-09-01', 1, N'Hải Phòng', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Sinh Viên 35', '2001-10-01', 0, N'Cần Thơ', 0);

INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Sinh Viên 36', '2001-11-01', 1, N'Hà Nội', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Sinh Viên 37', '2001-12-01', 0, N'Hồ Chí Minh', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Sinh Viên 38', '2002-01-01', 1, N'Đà Nẵng', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Sinh Viên 39', '2002-02-01', 0, N'Hải Phòng', 0);
INSERT INTO SINHVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, DaXoa) VALUES (N'Sinh Viên 40', '2002-03-01', 1, N'Cần Thơ', 0);




