import { pool } from '../configs/database_connection.js';


//para entrar
export const GetLogin = (req,res)=>{
    res.render('Login')
}

export const  PostLogin = (req,res)=>{
    const {username, password} = req.body;
    const info = {
        username: username,
        password: password
    };
    console.log(info);
    req.flash('success_msg', `Welcome back ${username}`)
    res.send('Hola');
}

//crear nueva cuenta
export const GetSingup = (req,res)=>{
    res.render('Signup')
}

export const PostSignup = (req,res)=>{
    const {username, password} = req.body;
    const info = {
        username: username,
        password: password
    };
    console.log(info);
    res.redirect('/login');
}


