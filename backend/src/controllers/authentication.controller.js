/**
    @author: DamijodaStudios
    @version: 1.0.0
    @description: main file of the routes controllers
    @copyright: DamijodaStudios
    
 */

    import { pool } from '../configs/database_connection.js';
    import passport from 'passport';
    
    //Default Rout
    export const GetIndex = (req,res)=>{
        res.redirect('/profile');
    }
    
    //Login
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
    
    //Signup
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
    
        res.render('index',{user:user}); //enviar el usuario a la vista y pagina
        console.log(user);
    }
    

    //JSON data

    export const GetMatches = async (req,res)=>{
        const [user] = req.user;
        const [matches] = await pool.query('SELECT * FROM matches WHERE user_id = ?',[user.id]);
        res.status(202).json(matches);
        console.log(matches)
    }

    //Logout
    export const GetLogout = (req,res)=>{
        req.logout((err)=>{
            if(err) return next(err);
            res.redirect('/login');
        })
        
    }


    export const GetError404 = (req,res)=>{
        res.status(404).render('page_404');
    }
    