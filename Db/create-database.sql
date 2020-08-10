CREATE DATABASE db_security;
GO

USE db_security;

CREATE TABLE Access(
    id_user INT primary key,
    username varchar(100),
    password varchar(100)
);

INSERT INTO Access(id_user, username, password)
VALUES (0, 'test', 'Abc123');