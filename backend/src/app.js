/**
    @author: DamijodaStudios
    @version: 1.0.0
    @description: main file of the project
    @copyright: DamijodaStudios
    
 */


//modules
import express from 'express';
import morgan from 'morgan';
import flash from 'connect-flash';
import session from 'express-session';
import passport from 'passport';


import path from 'path';
import { fileURLToPath } from 'url';


//Init
const app = express();


//imports
import {sessionStore} from './configs/database_connection.js';
import passportauth from './services/authService.js'



//settings
import {PORT,SESS_NAME,SESS_SECRET,NODE_ENV} from './configs/config.js' //Port
const __filename = fileURLToPath(import.meta.url); //__filename config
const __dirname = path.dirname(__filename); //__dirname config



//view engine
app.set('views', path.join(__dirname, 'views')); //se establece la direccion carpeta views
app.set('view engine', 'ejs'); // se configura el motor de vistas

const oneDay = 1000 * 60 * 60 * 24;

//middlewares
app.use(session({
    name: SESS_NAME,
    secret: SESS_SECRET,
    resave: false,
    saveUninitialized: false,
    store: sessionStore,
    cookie: {
        maxAge: oneDay,
        sameSite: true,
        secure: NODE_ENV === 'production', 
    }
}))

app.use(flash());

app.use(morgan('dev'));
app.use(express.json()); //post data formato json
app.use(express.urlencoded({extended:false})); //post data desde un form

app.use(passport.initialize()); //inicio de passport;
app.use(passport.session()); // manejo de los datos con passport 

//Global Variables

app.use((req,res,next)=>{
    
    res.locals.success_msg = req.flash('success_msg');
    res.locals.message = req.flash('message');
    app.locals.user = req.user;
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