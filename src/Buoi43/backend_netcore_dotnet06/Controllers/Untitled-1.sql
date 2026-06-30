
create database db_user
GO
use db_user
GO

-- =============================================
-- Script: Tạo các bảng users, Roles, UserRole
-- Database: SQL Server
-- =============================================

-- =============================================
-- 1. Tạo các bảng (không kèm constraint)
-- =============================================

-- Bảng Roles
CREATE TABLE Roles
(
    id          INT                 NOT NULL    IDENTITY(1,1),
    rolename    NVARCHAR(100)        NOT NULL,
    deleted     BIT                 NOT NULL    DEFAULT(0)
);
GO

-- Bảng users
CREATE TABLE users
(
    id              UNIQUEIDENTIFIER    NOT NULL    DEFAULT(NEWID()),
    username        NVARCHAR(100)       NOT NULL,
    email           NVARCHAR(255)       NOT NULL,
    hashPassword    NVARCHAR(255)       NOT NULL,
    phone           NVARCHAR(20)        NULL,
    fullname        NVARCHAR(150)       NULL,
    deleted         BIT                 NOT NULL    DEFAULT(0)
);
GO

-- Bảng UserRole (bảng trung gian users - Roles)
CREATE TABLE UserRole
(
    idUser      UNIQUEIDENTIFIER    NOT NULL,
    idRole      INT                 NOT NULL,
    [desc]      NVARCHAR(255)       NULL
);
GO

-- =============================================
-- 2. Tạo các constraint
-- =============================================

-- Constraint cho bảng Roles
ALTER TABLE Roles
    ADD CONSTRAINT PK_Roles PRIMARY KEY (id);
GO
ALTER TABLE Roles
    ADD CONSTRAINT UQ_Roles_rolename UNIQUE (rolename);
GO

-- Constraint cho bảng users
ALTER TABLE users
    ADD CONSTRAINT PK_users PRIMARY KEY (id);
GO
ALTER TABLE users
    ADD CONSTRAINT UQ_users_username UNIQUE (username);
GO
ALTER TABLE users
    ADD CONSTRAINT UQ_users_email UNIQUE (email);
GO

-- Constraint cho bảng UserRole
ALTER TABLE UserRole
    ADD CONSTRAINT PK_UserRole PRIMARY KEY (idUser, idRole);
GO
ALTER TABLE UserRole
    ADD CONSTRAINT FK_UserRole_users FOREIGN KEY (idUser) REFERENCES users(id);
GO
ALTER TABLE UserRole
    ADD CONSTRAINT FK_UserRole_Roles FOREIGN KEY (idRole) REFERENCES Roles(id);
GO

-- =============================================
-- 3. Sinh dữ liệu cho bảng Roles: User, Admin
-- =============================================
INSERT INTO Roles (rolename, deleted)
VALUES
    (N'User',  0),
    (N'Admin', 0);
GO
