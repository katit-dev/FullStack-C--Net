-- =============================================
-- Script: Tạo bảng IpCount (đếm số lần truy cập theo IP)
-- Database: SQL Server
-- Cột: id (tự tăng), ip, count
-- =============================================

-- =============================================
-- 1. Tạo bảng
-- =============================================
CREATE TABLE IpCount
(
    id      INT             NOT NULL    IDENTITY(1,1),  -- khóa chính, tự tăng
    ip      NVARCHAR(45)    NOT NULL,                   -- 45 ký tự đủ chứa cả IPv6
    [count] INT             NOT NULL    DEFAULT(0)      -- [count] đặt trong ngoặc vì trùng tên hàm COUNT
);
GO

-- =============================================
-- 2. Tạo constraint
-- =============================================
ALTER TABLE IpCount
    ADD CONSTRAINT PK_IpCount PRIMARY KEY (id);
GO

-- Mỗi IP chỉ có 1 dòng (tránh ghi trùng)
ALTER TABLE IpCount
    ADD CONSTRAINT UQ_IpCount_ip UNIQUE (ip);
GO
