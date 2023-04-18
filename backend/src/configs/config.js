import {config} from 'dotenv';
config();

export const PORT = process.env.PORT || 5000
export const DB_HOST = process.env.DB_HOST || "localhost";
export const DB_PORT = process.env.DB_PORT || 3306;
export const DB_USER = process.env.DB_USER ||"root"
export const DB_DATABASE = process.env.DB_DATABASE || "basededatos";
export const DB_PASSWORD = process.env.DB_PASSWORD || "@Jupiter6.";

export const SESS_NAME = process.env.SESS_NAME;
export const SESS_SECRET = process.env.SESS_SECRET;
export const NODE_ENV = process.env.NODE_ENV;

