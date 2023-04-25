/**
    @author: DamijodaStudios
    @version: 1.0.0
    @description: file that uses passport to authenticate the user
    @copyright: DamijodaStudios
    
 */

import passport, { Passport } from "passport";
import { Strategy as LocalStrategy } from "passport-local";


import {pool} from '../configs/database_connection.js'
import {helpers} from '../lib/helpers.js'

// login passport

passport.use('local.login', new LocalStrategy({
    usernameField:'username',
    passwordField:'password',
    passReqToCallback: true
}, async (req, username, password, done)=>{
    //console.log(req.body);

    const [rows] = await pool.query('SELECT * FROM users WHERE username = ?',[username]);
    //si encuentra un usuario
    if(rows.length > 0){
        const user = rows[0];
        //validar contraseña 
        const validPassword = await helpers.matchPassword(password, user.password); //devuelve un true o un false;
        
        if(validPassword){
             done(null, user, req.flash('success_msg',`Welcome ${user.username}`));
        }else{
            done(null, false, req.flash('error','Incorrect username or password')); //en caso de que algun dato esta incorrecto
        }
    } else{
        //si no encuentra un usuario
        return done(null, false, req.flash('message','The Username does not exits'));
    }
}))



// signup passport 

passport.use('local.singup', new LocalStrategy({
    usernameField:'username',
    passwordField:'password',
    passReqToCallback: true
}, async (req, username, password, done)=>{
    const newUser = {username,password}
    newUser.password = await helpers.encryptPassword(password)
    const [result] = await pool.query('Insert INTO users SET ?',[newUser])
    newUser.id = result.insertId;
    return done(null, newUser);
}));

passport.serializeUser((user,done)=>{
    done(null, user.id);
})

passport.deserializeUser( async (id,done)=>{
    const rows = await pool.query('SELECT * FROM users where id = ?', [id]);
    done(null, rows[0]);
})

export default passport;