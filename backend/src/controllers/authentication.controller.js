import { pool } from '../configs/database_connection.js';

import passport from 'passport';



//para entrar
export const GetLogin = (req,res)=>{
    res.render('Login')
}

export const  PostLogin = (req,res,next)=>{
    passport.authenticate('local.login',{
        successRedirect: '/profile',
        failureRedirect: '/login',
        failureFlash: true
    })(req,res,next);
}

//crear nueva cuenta
export const GetSingup = (req,res)=>{
    res.render('Signup')
}

export const PostSignup = passport.authenticate('local.singup',{
    successRedirect: '/profile',
    failureRedirect: '/login',
    failureFlash: true
});

//Profile

export const GetProfile = (req,res)=>{
    res.render('index');

}

export const GetLogout = (req,res)=>{
    req.logout((err)=>{
        if(err) return next(err);
        res.redirect('/login');
    })
    
}




