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
        passport.authenticate('local.login',{
            successRedirect: '/profile',
            failureRedirect: '/login',
            failureFlash: true
        })(req,res,next);
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
    
    //Logout
    export const GetLogout = (req,res)=>{
        req.logout((err)=>{
            if(err) return next(err);
            res.redirect('/login');
        })

        console.log("-> Saliendo de mi cuenta");
    }


    //JSON data

    export const GetMatches = async (req,res)=>{
        const [user] = req.user;
        const [matches] = await pool.query('SELECT * FROM damijoda.matches WHERE user_id = ?',[user.id]);
        res.status(202).json(matches);
        console.log("-> endpoint de matches");
    }

    export const GetLevels = async (req,res)=>{
        const [user] = req.user;
        const [matches] = await pool.query('SELECT * FROM damijoda.matches WHERE user_id = ?',[user.id]);
        const [levels] = await pool.query('SELECT * FROM damijoda.levels WHERE level_id = ?',[matches[0].level_id]);
        res.status(202).json(levels);
        console.log("-> endpoint de levels");
    }

    export const GetBosses = async (req,res)=>{
        const [bosses] = await pool.query('SELECT * FROM damijoda.bosses');
        res.status(202).json(bosses);
        console.log("-> endpoint de bosses");
    }

    export const GetEnemies = async (req,res)=>{
        const [enemies] = await pool.query('SELECT * FROM damijoda.enemies');
        res.status(202).json(enemies);
        console.log("-> endpoint de enemies");
    }

    export const GetCharacters = async (req,res)=>{
        const [user] = req.user;
        const [matches] = await pool.query('SELECT * FROM damijoda.matches WHERE user_id = ?',[user.id]);
        const [characters] = await pool.query('SELECT * FROM damijoda.characters WHERE match_id = ?',[matches[0].match_id]);
        res.status(202).json(characters);
        console.log("-> endpoint de characters");
    }

    export const GetGems = async (req,res)=>{
        const [user] = req.user;
        const [matches] = await pool.query('SELECT * FROM damijoda.matches WHERE user_id = ?',[user.id]);
        const [characters] = await pool.query('SELECT * FROM damijoda.characters WHERE match_id = ?',[matches[0].match_id]);
        const [gems] = await pool.query('SELECT * FROM damijoda.gems WHERE character_id = ?',[characters[0].character_id]);
        res.status(202).json(gems); 
        console.log("-> endpoint de gems");
    }


    export const GetArmors = async (req,res)=>{
        const [user] = req.user;
        const [matches] = await pool.query('SELECT * FROM damijoda.matches WHERE user_id = ?',[user.id]);
        const [characters] = await pool.query('SELECT * FROM damijoda.characters WHERE match_id = ?',[matches[0].match_id]);
        const [armors] = await pool.query('SELECT * FROM damijoda.armors WHERE character_id = ?',[characters[0].character_id]);
        res.status(202).json(armors); 
    }

    export const GetWeapons = async (req,res)=>{
        const [user] = req.user;
        const [matches] = await pool.query('SELECT * FROM damijoda.matches WHERE user_id = ?',[user.id]);
        const [characters] = await pool.query('SELECT * FROM damijoda.characters WHERE match_id = ?',[matches[0].match_id]);
        const [weapons] = await pool.query('SELECT * FROM damijoda.weapons WHERE character_id = ?',[characters[0].character_id]);
        res.status(202).json(weapons);
    }



    //404 page
    export const GetError404 = (req,res)=>{
        res.status(404).render('page_404');
    }