import MySQLStore from 'express-mysql-session';
import  session from 'express-session';
import mysql from 'mysql2/promise';

import {DB_HOST,DB_PORT,DB_USER,DB_DATABASE,DB_PASSWORD} from './config.js';

//DATABASE CONNECTION 

export const pool = mysql.createPool({
    host:DB_HOST,
    port:DB_PORT,
    user:DB_USER,
    database:DB_DATABASE,
    password:DB_PASSWORD
});

export const sessionStore = new MySQLStore({    host:DB_HOST,
    port:DB_PORT,
    user:DB_USER,
    database:DB_DATABASE,
    password:DB_PASSWORD},pool)


