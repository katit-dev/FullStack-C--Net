SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- procedure
ALTER procedure [dbo].[sp_layDanhSachNhanVienTheoDuAn](
    @MaDuAn int
) as
begin
SELECT count(MaDuAn) as SoLuongNhanVien, MaDuAn,
(select Id as 'Ma Nhan vien', TenNV, NgaySinh, SoDienThoai from NhanVien NV, NhanVien_DuAn NVD 
where NV.Id = NVD.MaNhanVien and NVD.MaDuAn = NhanVien_DuAn.MaDuAn for json path)
FROM NhanVien_DuAn
GROUP BY MaDuAn,
end;
GO
