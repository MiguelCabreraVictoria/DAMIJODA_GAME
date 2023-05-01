/**
    @author: DamijodaStudios
    @version: 1.0.0
    @description: main file of the routes controllers
    @copyright: DamijodaStudios
    
 */

    import { pool } from '../configs/database_connection.js';
    import passport from 'passport';
    
    //Endpoints

    //Default Route
    export const GetIndex = (req,res)=>{
        res.redirect('/profile');
    }
    
    //Login
    export const GetLogin = (req,res)=>{
        res.render('Login')
        console.log("-> estoy en el login  | posiblemente no se autentico el usuario");
    }


    
    export const PostLogin = (req, res, next) => {
        const {username, password} = req.body;
        passport.authenticate('local.login', (err, user, info) => {
            if (err) { return next(err); }
            if (!user) { return res.status(401).json({message: 'Authentication fallo'}); }
            req.login(user, (err) => {
                if (err) { return next(err); }
                return res.redirect('/profile');
            });
        })(req, res, next);
    
        console.log(`| --> EL usuario ${username} esta tratando de iniciar sesion`);
        console.log("| --> autenticando...");
        console.log("|---------------------------------------------------------|")
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
        console.log(`| --> El usuario ${user.username} ha sido autenticado exitosamente | `);
        console.log(`| --> Bienvenido a DAMIJODA STUDIOS ${user.username}               |`);
        console.log("|---------------------------------------------------------|")

    }
    
    //Logout
    export const GetLogout = (req,res)=>{
        req.logout((err)=>{
            if(err) return next(err);
            res.redirect('/login');
        })
        console.log("| --> El usuario ha cerrado sesion. Vuelve pronto!");
        console.log("|---------------------------------------------------------|")
    }


    //JSON data

    export const GetMatches = async (req,res)=>{
        const [user] = req.user;
        const [matches] = await pool.query('SELECT * FROM damijoda.matches WHERE user_id = ?',[user.id]);
        res.status(202).json(matches);
        console.log("-> endpoint de matches");
        console.log(matches);
    }

    export const GetLevels = async (req,res)=>{
        const [user] = req.user;
        const [matches] = await pool.query('SELECT * FROM damijoda.matches WHERE user_id = ?',[user.id]);
        const [levels] = await pool.query('SELECT * FROM damijoda.levels WHERE level_id = ?',[matches[0].level_id]);
        res.status(202).json(levels);
        console.log("-> endpoint de levels");
        console.log(levels);
        
    }

    export const GetBosses = async (req,res)=>{
        const [bosses] = await pool.query('SELECT * FROM damijoda.bosses');
        res.status(202).json(bosses);
        console.log("-> endpoint de bosses");
        console.log(bosses);
    }

    export const GetEnemies = async (req,res)=>{
        const [enemies] = await pool.query('SELECT * FROM damijoda.enemies');
        res.status(202).json(enemies);
        console.log("-> endpoint de enemies");
        console.log(enemies);
    }

    export const GetCharacters = async (req,res)=>{
        const [user] = req.user;
        const [matches] = await pool.query('SELECT * FROM damijoda.matches WHERE user_id = ?',[user.id]);
        const [characters] = await pool.query('SELECT * FROM damijoda.characters WHERE match_id = ?',[matches[0].match_id]);
        res.status(202).json(characters);
        console.log("-> endpoint de characters");
        console.log(characters[0]);
    }

    export const GetGems = async (req,res)=>{
        const [user] = req.user;
        const [matches] = await pool.query('SELECT * FROM damijoda.matches WHERE user_id = ?',[user.id]);
        const [characters] = await pool.query('SELECT * FROM damijoda.characters WHERE match_id = ?',[matches[0].match_id]);
        const [gems] = await pool.query('SELECT * FROM damijoda.gems WHERE character_id = ?',[characters[0].character_id]);
        res.status(202).json(gems); 
        console.log("-> endpoint de gems");
        console.log(gems);
    }


    export const GetArmors = async (req,res)=>{
        const [user] = req.user;
        const [matches] = await pool.query('SELECT * FROM damijoda.matches WHERE user_id = ?',[user.id]);
        const [characters] = await pool.query('SELECT * FROM damijoda.characters WHERE match_id = ?',[matches[0].match_id]);
        const [armors] = await pool.query('SELECT * FROM damijoda.armors WHERE character_id = ?',[characters[0].character_id]);
        res.status(202).json(armors); 
        console.log("-> endpoint de armors");
        console.log(armors);
    }

    export const GetWeapons = async (req,res)=>{
        const [user] = req.user;
        const [matches] = await pool.query('SELECT * FROM damijoda.matches WHERE user_id = ?',[user.id]);
        const [characters] = await pool.query('SELECT * FROM damijoda.characters WHERE match_id = ?',[matches[0].match_id]);
        const [weapons] = await pool.query('SELECT * FROM damijoda.weapons WHERE character_id = ?',[characters[0].character_id]);
        res.status(202).json(weapons);
        console.log("-> endpoint de weapons");
        console.log(weapons[0]);
    }



    //404 page
    export const GetError404 = (req,res)=>{
        res.status(404).render('page_404');
    }
    