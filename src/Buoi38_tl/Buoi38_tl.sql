USE QuanLyNhanVien

SELECT * FROM NhanVien

-- lay ra nhan vien nho tuoi nhat
SELECT *
FROM NhanVien
WHERE YEAR(NgaySinh) = (select MIN(YEAR(NgaySinh)) FROM NhanVien)

-- cho biet moi du an co bao nhieu nhan vien
SELECT MaDuAn, COUNT(*) as SoLuongNhanVien
FROM NhanVien_Duan
GROUP BY MaDuAn

-- cho biet moi du an co bao nhieu nhan vien
-- va thong tin cua cac nhan vien do
SELECT MaDuAn, COUNT(*) as SoLuongNhanVien, 
(SELECT Id, TenNV, NgaySinh, SoDienThoai FROM NhanVien NV, NhanVien_Duan NVD
WHERE NV.Id = NVD.MaNhanVien AND NVD.MaDuAn = NhanVien_Duan.MaDuAn FOR JSON PATH)
FROM NhanVien_Duan
GROUP BY MaDuAn


-- viet stored procedure
ALTER PROCEDURE sp_layDanhSachNhanVienTheoDuAn(
    @MaDuAn INT
)
AS
BEGIN
    SELECT MaDuAn, TenDuAn, COUNT(*) as SoNhanVien, 
(SELECT Id as 'MaNhanVien', TenNV, NgaySinh, SoDienThoai FROM NhanVien NV, NhanVien_Duan NVD
WHERE NV.Id = NVD.MaNhanVien AND NVD.MaDuAn = NhanVien_Duan.MaDuAn FOR JSON PATH) AS DanhSachNhanVienJson
FROM NhanVien_Duan, DuAn
WHERE NhanVien_Duan.MaDuAn = DuAn.Id AND NhanVien_Duan.MaDuAn = @MaDuAn
GROUP BY MaDuAn, TenDuAn
END;

-- goi thu tuc
EXEC sp_layDanhSachNhanVienTheoDuAn @MaDuAn = 1


-- them 1 vai du lieu: them dia diem, them du an ten ro rang, them nhan vien cho cac du an
INSERT INTO DiaDiem (TenDiaDiem) VALUES ('Ha Noi'), ('Da Nang'), ('Ho Chi Minh')
INSERT INTO DuAn (TenDuAn, MaDiaDiem) VALUES ('Du An Benh Vien', 1), ('Du An Technology', 2), ('Du An CyberSoft', 3)


-- =========================
-- THEM DU LIEU BANG DiaDiem
-- =========================
INSERT INTO DiaDiem (TenDiaDiem, DiaChi)
VALUES 
(N'TP. Hồ Chí Minh', N'Quận 1, TP. Hồ Chí Minh'),
(N'Hà Nội', N'Cầu Giấy, Hà Nội'),
(N'Đà Nẵng', N'Hải Châu, Đà Nẵng'),
(N'Cần Thơ', N'Ninh Kiều, Cần Thơ'),
(N'Bình Dương', N'Thủ Dầu Một, Bình Dương');


-- ======================
-- THEM DU LIEU BANG DuAn
-- ======================
INSERT INTO DuAn (TenDuAn, MoTa, NgayBatDau, NgayKetThuc, MaDiaDiem)
VALUES
(N'Dự Án Web', N'Phát triển website quản lý nội bộ công ty', '2024-02-15', '2024-08-15', 2),
(N'Dự Án Mobile App', N'Xây dựng ứng dụng di động cho nhân viên', '2024-03-01', '2024-09-30', 3),
(N'Dự Án CRM', N'Phát triển hệ thống quản lý khách hàng', '2024-04-05', '2024-10-20', 4),
(N'Dự Án ERP', N'Xây dựng hệ thống quản lý tài nguyên doanh nghiệp', '2024-05-01', '2024-12-31', 5);


-- ==================================
-- THEM DU LIEU BANG NhanVien_Duan
-- ==================================
INSERT INTO NhanVien_Duan (MaNhanVien, MaDuAn, NgayThamGia)
VALUES

(1, 2, '2024-02-20'),
(4, 2, '2024-02-25'),
(5, 2, '2024-03-01'),

(2, 3, '2024-03-05'),
(3, 3, '2024-03-10'),
(6, 3, '2024-03-15'),

(1, 4, '2024-04-10'),
(5, 4, '2024-04-15'),
(6, 4, '2024-04-20'),

(3, 5, '2024-05-05'),
(4, 5, '2024-05-10'),
(6, 5, '2024-05-15');

-- viet stored procedure truyen vao ma nhan vien, tra ve thong tin cua nhan vien va tat ca du an ma nhan vien do tham gia

CREATE PROCEDURE sp_layDanhSachDuAnTheoNhanVien(
    @MaNhanVien INT
)
AS
BEGIN
    SELECT nv.Id as 'MaNhanVien',
            nv.TenNV,
            nv.NgaySinh,
            nv.SoDienThoai,
            COUNT(*) as SoDuAn,
            (
                SELECT da.Id as 'MaDuAn',
                 da.TenDuAn,da.MoTa,
                  da.NgayBatDau,
                   da.NgayKetThuc,
                    dd.TenDiaDiem,
                     dd.DiaChi
                FROM DuAn da
                INNER JOIN NhanVien_Duan nvd_detail
                ON da.Id = nvd_detail.MaDuAn
                INNER JOIN DiaDiem dd 
                ON da.MaDiaDiem = dd.Id
                WHERE nvd_detail.MaNhanVien = nv.Id
                For JSON PATH
            ) as DanhSachDuAnJson
    FROM NhanVien nv
    INNER JOIN NhanVien_Duan nvd
    ON nv.Id = nvd.MaNhanVien
    WHERE nv.Id = @MaNhanVien
    GROUP BY nv.Id, nv.TenNV, nv.NgaySinh, nv.SoDienThoai
END;

exec sp_layDanhSachDuAnTheoNhanVien @MaNhanVien = 1