//modules
import express from 'express';
import morgan from 'morgan';
const app = express();

import authRoutes from './routes/authentication.routes.js'

//settings
import {PORT} from './config.js'
//middlewares
app.use(morgan('dev'));
app.use(express.json());
app.use(express.urlencoded({extended:false}));


//routes
app.use(authRoutes);
//public

//Starting server
app.listen(PORT,()=>{
    console.log(`The port ${PORT} is listening`);
})