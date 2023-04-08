//modules
import express from 'express';
import morgan from 'morgan';

import path from 'path';
import { fileURLToPath } from 'url';


//Init
const app = express();


//settings

import {PORT} from './config.js' //Port
const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

app.set('views', path.join(__dirname, 'views')); //se establece la direccion carpeta views
app.set('view engine', 'ejs'); // se configura el motor de vistas

//middlewares
app.use(morgan('dev'));
app.use(express.json());
app.use(express.urlencoded({extended:false}));




//routes
import authRoutes from './routes/authentication.routes.js'
app.use(authRoutes);



//public
app.use(express.static(__dirname + '/public'));

//Starting server
app.listen(PORT,()=>{
    console.log(`The port ${PORT} is listening`);
})