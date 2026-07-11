Use db_user
CREATE TABLE IpCount(
    -- id khoa chinh, tu tang
    id INT NOT NULL IDENTITY(1,1),
    ip NVARCHAR(50) NOT NULL,
    [count] INT NOT NULL DEFAULT(0)
)

ALTER TABLE IpCount ADD CONSTRAINT PK_IpCount PRIMARY KEY (id);
ALTER TABLE IpCount ADD CONSTRAINT UQ_IpCount_ip UNIQUE (ip);

-- them truong dateRequest, type datetime, allow null, khong can default value
ALTER TABLE IpCount ADD dateRequest DATETIME NULL;