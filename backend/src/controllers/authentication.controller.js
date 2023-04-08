import { pool } from '../database_connection.js';

export const GetLogin = (req,res)=>{
    res.render('Login')
}

export const  PostLogin = (req,res)=>{
    const {username, password} = req.body;
    console.log(username,password);
    res.send('Hola');
}


export const GetSingup = (req,res)=>{
    res.render('Signup')
}

export const PostSignup = (req,res)=>{
    const {username, password} = req.body;
    console.log(username,password);
    res.send('Hola');
}


