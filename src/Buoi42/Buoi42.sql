use db_user

-- viet cau lenh tao bang IpCount
    -- id tu tang, khoa chinh
    -- ip Nvarchar(15)
    -- count Int not null default 0
    -- dateRequest datetime defaultvalue getdate()
CREATE TABLE IpCount (
    id INT IDENTITY(1,1) PRIMARY KEY,
    ip NVARCHAR(15),
    count INT NOT NULL DEFAULT 0,
    dateRequest DATETIME DEFAULT GETDATE()
);