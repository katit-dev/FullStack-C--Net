-- select lay 1 phan tu cua table voi dieu kien phan tran
-- PageIndex: la trang hien tai(3)
-- PageSize: so luong ban ghi tren 1 trang(10)

--DECLARE @PageIndex INT;
--DECLARE @PageSize INT;

-- SET @PageIndex = 4; -- Trang hiện tại
-- SET @PageSize = 10; -- Số lượng bản ghi trên mỗi trang

SELECT *
FROM SINHVIEN
ORDER BY MaSV
OFFSET (@PageIndex - 1) * @PageSize ROWS
FETCH NEXT @PageSize ROWS ONLY;


-- Update: cap nhat du lieu trong table
UPDATE SINHVIEN SET  HoTen = N'Nguyễn Văn Z' WHERE MaSV = 1;

SELECT * FROM SINHVIEN

-- Delete: xoa du lieu trong table
-- la lenh rat han che
DELETE FROM SINHVIEN WHERE MaSV = 1;

-- thay vi xoa du lieu, ta co the cap nhat cot DaXoa thanh 1 de danh dau la da xoa
UPDATE SINHVIEN SET DaXoa = 1 WHERE MaSV = 1;

-- bt1: lay ra 10 sinh vien bat dau bang chu "Nguyễn", sap xep theo ngay sinh tu cu den moi
select TOP 10* from SINHVIEN
where HoTen LIKE N'Nguyễn%'
ORDER BY NgaySinh ASC;

-- bt2: cap nhat dia chi cua sinh vien co ma sv = 5 thanh "Hà Nội"
Update SINHVIEN
SET DiaChi = N'Hà Nội'
Where MaSV = 5;

-- bt3: lay tu trang 2 cua danh sach sinh vien, moi trang co 10 sinh vien, sap xep theo ten tu a den z
DECLARE @PageIndex INT = 2;
DECLARE @PageSize INT = 10;

SELECT *
FROM SINHVIEN
WHERE DaXoa = 0
ORDER BY HoTen ASC
OFFSET (@PageIndex - 1) * @PageSize ROWS
FETCH NEXT @PageSize ROWS ONLY;

-- bt4: xoa sinh vien co ma sv = 10
UPDATE SINHVIEN
SET DaXoa = 1
WHERE MaSV = 10;

-- bt5: lay ra so luong sinh vien nam va nu trong bang
-- having la tren dieu kien sau khi da group by

-- nhom nao tren 20 thi moi hien thi
SELECT GioiTinh, COUNT(*) AS SoLuong
From SINHVIEN
GROUP BY GioiTinh
HAVING COUNT(*) > 20;

