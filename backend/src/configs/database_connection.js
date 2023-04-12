
import session from 'express-session';
import MySQLStore from 'express-mysql-session';
import mysql from 'mysql2/promise';

import {DB_HOST,DB_PORT,DB_USER,DB_DATABASE,DB_PASSWORD} from './config.js';

const MySQLStoreSession = MySQLStore(session);

//DATABASE CONNECTION 

const options = {
    host:DB_HOST,
    port:DB_PORT,
    user:DB_USER,
    database:DB_DATABASE,
    password:DB_PASSWORD
};

export const pool = mysql.createPool(options);

export const sessionStore = new MySQLStoreSession(options,pool);


