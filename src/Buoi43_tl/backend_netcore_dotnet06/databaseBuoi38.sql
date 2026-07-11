USE QuanLyNhanVien;

SELECT *
FROM NhanVien
WHERE  year(NgaySinh) <= (select Min(year(NgaySinh)) from NhanVien)


-- cho biet moid du an co bao nhieu nhan vien
SELECT count(MaDuAn) as SoLuongNhanVien, MaDuAn
FROM NhanVien_DuAn
GROUP BY MaDuAn

SELECT count(MaDuAn) as SoLuongNhanVien, MaDuAn,
(select Id as 'Ma Nhan vien', TenNV, NgaySinh, SoDienThoai from NhanVien NV, NhanVien_DuAn NVD 
where NV.Id = NVD.MaNhanVien and NVD.MaDuAn = NhanVien_DuAn.MaDuAn for json path)
FROM NhanVien_DuAn
GROUP BY MaDuAn

-- procedure
create procedure sp_layDanhSachNhanVienTheoDuAn(
    @MaDuAn int
) as
begin
SELECT count(MaDuAn) as SoLuongNhanVien, MaDuAn, TenDuAn,
(select Id as 'Ma Nhan vien', TenNV, NgaySinh, SoDienThoai from NhanVien NV, NhanVien_DuAn NVD 
where NV.Id = NVD.MaNhanVien and NVD.MaDuAn = NhanVien_DuAn.MaDuAn for json path)
FROM NhanVien_DuAn
GROUP BY MaDuAn, TenDuAn
end;

--- delete procedure sp_layDanhSachNhanVienTheoDuAn
drop procedure sp_layDanhSachNhanVienTheoDuAn

-- goi procedure
exec sp_layDanhSachNhanVienTheoDuAn @MaDuAn = 1





-- bt: xay dung procedure lay tat ca du an theo moi nhan vien
-- CREATE PROCEDURE sp_layDanhSachDuAnTheoNhanVien(
--     @MaNhanVien int
-- ) AS
-- BEGIN


-- store procedure insert cho tat ca tabel
