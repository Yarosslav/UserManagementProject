-- Создание базы данных
CREATE DATABASE UserManagementDB;


USE UserManagementDB;


-- Создание таблицы Users
CREATE TABLE Users
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(200) NOT NULL,
    DRFO NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20) NOT NULL,
    DateCreated DATETIME NOT NULL DEFAULT GETDATE(),
    DateModified DATETIME NOT NULL DEFAULT GETDATE()
);
