//modules
import express from 'express';
import morgan from 'morgan';
import path from 'path';
import { fileURLToPath } from 'url';
const app = express();

import authRoutes from './routes/authentication.routes.js'

//settings
import {PORT} from './config.js'
//__dirname setings
const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

app.set('views', path.join(__dirname, 'views'));

app.set('view engine', 'ejs');

//middlewares
app.use(morgan('dev'));
app.use(express.json());
app.use(express.urlencoded({extended:false}));


//routes
app.use(authRoutes);

//public
app.use(express.static(__dirname + '/public'));

//Starting server
app.listen(PORT,()=>{
    console.log(`The port ${PORT} is listening`);
})