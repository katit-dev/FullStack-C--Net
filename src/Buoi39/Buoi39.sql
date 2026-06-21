--SQl server - system functions
select Id, UPPER(TenNV), FORMAT(NgaySinh, 'dd/MM/yyyy')
from NhanVien
where YEAR(NgaySinh) = 1990

Use QuanLyNhanVien

CREATE FUNCTION CalculateTax(@Price decimal(18, 2))
RETURNS decimal(18, 2)
AS
BEGIN
    DECLARE @Tax decimal(18, 2)
    SET @Tax = @Price * 0.1
    -- Assuming a tax rate of 10%
    RETURN @Tax
END

SELECT *, 1000 AS "LUONG", dbo.CalculateTax(1000) AS "THUE"
FROM NhanVien

-- VIET HAM TINH TONG 2 SO A VA B
CREATE FUNCTION CalculateSum(@A int, @B int)
RETURNS int
AS
BEGIN
    DECLARE @Sum int
    SET @Sum = @A + @B
    RETURN @Sum
END

SELECT dbo.CalculateSum(5, 10) AS "Tong"

------------------------------------------------------

CREATE FUNCTION LayThongTinNhanVien(@namSinh int)
RETURNS @TBLDanhSachNhanVien TABLE
(
    MaNhanVien int,
    HoTen nvarchar(50),
    NgaySinh int,
    MaPhongBan int,
    TenPhongBan nvarchar(50)
)
AS
BEGIN
    INSERT INTO @TBLDanhSachNhanVien
    SELECT NV.Id, NV.TenNV, YEAR(NV.NgaySinh), PB.Id, PB.TenPB
    FROM NhanVien NV
    JOIN PhongBan PB ON NV.MaPB = PB.Id
    WHERE YEAR(NV.NgaySinh) = @namSinh

    RETURN;
END


SELECT *FROM dbo.LayThongTinNhanVien(1990)

-- VIET function lay ra thong tin du an cua cac phong ban
















