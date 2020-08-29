CREATE DATABASE db_operation;

USE db_operation;

CREATE TABLE Operations(
    idoperation INT AUTO_INCREMENT PRIMARY KEY,
    idinvoice INT,
    amount DECIMAL(16, 4),
    date datetime
);