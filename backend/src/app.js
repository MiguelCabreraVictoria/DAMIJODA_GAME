//modules
const express = require('express');
const morgan = require('morgan')
const app = express();

//settings

//middlewares
app.use(morgan('dev'));
app.use(express.json());
app.use(express.urlencoded({extended:false}));


//routes
app.use(require('./routes/authentication.routes.js'));

//public

//Starting server
app.listen(5000,()=>{
    console.log("The port 5000 is listening")
})