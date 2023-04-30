/**
    @author: DamijodaStudios
    @version: 1.0.0
    @description: main file of the routes controllers
    @copyright: DamijodaStudios
    
 */

    import { pool } from '../configs/database_connection.js';
    import {SESS_SECRET} from '../configs/config.js'
    import passport from 'passport';
    import jwt from 'jsonwebtoken';
    
    //Default Rout
    export const GetIndex = (req,res)=>{
        res.redirect('/profile');
    }
    
    //Login
    export const GetLogin = (req,res)=>{
        res.render('Login')
        console.log("-> estoy en el login");
    }



    export const PostLogin = (req, res, next) => {
        passport.authenticate("local.login", (err, user, info) => {
          if (err) {
            return next(err);
          }
          if (!user) {
            return res.redirect("/login");
          }
          req.logIn(user, (err) => {
            if (err) {
              return next(err);
            }
            const token = jwt.sign({ user }, SESS_SECRET);
            res.json({ token });
            res.redirect("/profile");
          });
        })(req, res, next);
      };
    
    //Signup
    export const GetSingup = (req,res)=>{
        res.render('Signup');
        console.log("-> estoy en el signup");
    }
    
    export const PostSignup = passport.authenticate('local.singup',{
        successRedirect: '/login',
        failureRedirect: '/signup',
        failureFlash: true
    });
    
    //Profile
    export const GetProfile = async (req,res)=>{
        const [user] = req.user; 

        res.render('index',{user:user}); //enviar el usuario a la vista y pagina 
        console.log("-> estoy en el profile");
    }
    
    //JSON data

    export const GetMatches = async (req,res)=>{
        const [user] = req.user;
        const [matches] = await pool.query('SELECT * FROM matches WHERE user_id = ?',[user.id]);
        res.status(202).json(matches);
        console.log("-> endpoint de matches");

        jwt.verify(req.token, SESS_SECRET, (error, authData)=>
        {
            if(error){
                res.sendStatus(403);j
            }else{
                res.json({
                    message: 'Post created...',
                    authData: authData
                });
            }
        })
    }

    //Logout
    export const GetLogout = (req,res)=>{
        req.logout((err)=>{
            if(err) return next(err);
            res.redirect('/login');
        })

        console.log("-> Saliendo de mi cuenta");
    }


    export const GetError404 = (req,res)=>{
        res.status(404).render('page_404');
    }
    