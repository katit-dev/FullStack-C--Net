-- them 1 column vao bang NhanVien ten cot la MaTruongPhong
ALTER TABLE NhanVien
ADD MaTruongPhong INT;

-- cai dat rang buoc khoa ngoai cho cot MaTruongPhong
ALTER TABLE NhanVien
ADD CONSTRAINT FK_MaTruongPhong
FOREIGN KEY (MaTruongPhong) REFERENCES NhanVien(Id);

-- insert phong ban Kế Toán, Nhân sự, CNTT vào bảng PhongBan
INSERT INTO PhongBan
    (TenPB)
VALUES
    ('Kế Toán'),
    ('Nhân sự'),
    ('CNTT');

-- insert nhân viên vào bảng NhanVien, DE MA TRUONG PHONG LA NULL
INSERT INTO NhanVien
    (TenNV, NgaySinh, DiaChi, SoDienThoai, MaPB, MaTruongPhong)
VALUES
    ('Nguyen Van A', '1990-01-01', '123 Nguyen Trai', '0123456789', 1, NULL),
    ('Le Thi B', '1992-02-02', '456 Le Loi', '0987654321', 2, NULL),
    ('Tran Van C', '1988-03-03', '789 Tran Hung Dao', '0112233445', 3, NULL),
    ('Pham Thi D', '1995-04-04', '321 Nguyen Hue', '0223344556', 1, NULL),
    ('Hoang Van E', '1991-05-05', '654 Le Duan', '0334455667', 2, NULL),
    ('Vu Thi F', '1989-06-06', '987 Tran Phu', '0445566778', 3, NULL),
    ('Do Van G', '1993-07-07', '159 Nguyen Van Cu', '0556677889', 1, NULL),
    ('Nguyen Thi H', '1994-08-08', '753 Le Lai', '0667788990', 2, NULL),
    ('Le Van I', '1987-09-09', '852 Tran Quang Khai', '0778899001', 3, NULL);


SELECT TOP (1000) [Id]
      ,[TenNV]
      ,[NgaySinh]
      ,[DiaChi]
      ,[SoDienThoai]
      ,[MaPB]
      ,[MaTruongPhong]
  FROM [QuanLyNhanVien].[dbo].[NhanVien]

  SELECT TOP (1000) [Id]
      ,[TenPB]
  FROM [QuanLyNhanVien].[dbo].[PhongBan]

-- INNER JOIN
Use QuanLyNhanVien;

SELECT nv.Id, nv.TenNV, pb.TenPB
FROM NhanVien nv INNER JOIN PhongBan pb
ON nv.MaPB = pb.Id

-- cach viet khac cua INNER JOIN
SELECT NV.Id, NV.TenNV, PB.TenPB
FROM NhanVien NV, PhongBan PB
WHERE NV.MaPB = PB.Id

---
BEGIN TRANSACTION
    -- them du lieu vao bang nhan vien
    INSERT INTO NhanVien
        (TenNV, NgaySinh, DiaChi, SoDienThoai, MaPB, MaTruongPhong)
    VALUES
        ('Nguyen Van J', '1990-10-10', '123 Nguyen Trai', '0123456789', 1, NULL); 
    
    SELECT *
    FROM NhanVien, PhongBan
    WHERE NhanVien.MaPB = PhongBan.Id
    
COMMIT