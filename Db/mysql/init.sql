CREATE DATABASE db_operation;

USE db_operation;

CREATE TABLE Operations(
    id_operation INT AUTO_INCREMENT PRIMARY KEY,
    id_invoice INT,
    amount DECIMAL(16, 4),
    date datetime
);