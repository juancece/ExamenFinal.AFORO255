CREATE DATABASE db_security;
GO

USE db_security;

CREATE TABLE Access(
    IdUser INT primary key,
    UserName varchar(100),
    Password varchar(100)
);

INSERT INTO Access(IdUser, UserName, Password)
VALUES (0, 'admin', 'Abc123');