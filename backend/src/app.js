//modules
import express from 'express';
import morgan from 'morgan';
import flash from 'connect-flash';
import session from 'express-session';
import passport from 'passport';
import MySQLStore from 'express-mysql-session';



import path from 'path';
import { fileURLToPath } from 'url';


//Init
const app = express();

//imports
import {sessionStore} from './configs/database_connection.js'


//settings
import {PORT} from './configs/config.js' //Port
const __filename = fileURLToPath(import.meta.url); //__filename config
const __dirname = path.dirname(__filename); //__dirname config



//view engine
app.set('views', path.join(__dirname, 'views')); //se establece la direccion carpeta views
app.set('view engine', 'ejs'); // se configura el motor de vistas

//middlewares
app.use(session({
    secret: 'damijoda',
    resave: false,
    saveUninitialized: false,
    store: sessionStore
}))

app.use(flash());

app.use(morgan('dev'));
app.use(express.json()); //post data formato json
app.use(express.urlencoded({extended:false})); //post data desde un form


//Global Variables

app.use((req,res,next)=>{
    res.locals.success_msg = req.flash('success_msg')
    next();
})

//routes
import authRoutes from './routes/authentication.routes.js'
app.use(authRoutes);



//public
app.use(express.static(__dirname + '/public'));

//Starting server
app.listen(PORT,()=>{
    console.log(`The port ${PORT} is listening`);
})