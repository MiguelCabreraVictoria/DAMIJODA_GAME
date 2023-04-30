/**
    @author: DamijodaStudios
    @version: 1.0.0
    @description: main file of the routes controllers
    @copyright: DamijodaStudios
    
 */



    import { pool } from '../configs/database_connection.js';

    import passport from 'passport';
    
    
    
    //para entrar
    export const GetIndex = (req,res)=>{
        res.redirect('/profile');
    }
    
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
    
    export const GetProfile = async (req,res)=>{
        const [user] = req.user;
         //match 
         const [rows] = await pool.query('SELECT * FROM damijoda.matches WHERE user_id = ?',[user.id]);
         const info = rows[0];
    
    
        res.render('index',{user:user,info:info}); //enviar el usuario a la vista y pagina
        console.log(info);
        console.log(user);
    
    
    
    
    }
    
    export const GetLogout = (req,res)=>{
        req.logout((err)=>{
            if(err) return next(err);
            res.redirect('/login');
        })
        
    }
    