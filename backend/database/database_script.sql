--Create database
CREATE DATABASE IF NOT EXISTS basededatos;

USE basededatos;

--users table 

CREATE TABLE users (
    id INT NOT NULL AUTO_INCREMENT,
    username VARCHAR(50) NOT NULL,
    password VARCHAR(50) NOT NULL,
    login_time TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
    PRIMARY KEY(id)
);

DESCRIBE users;

--


