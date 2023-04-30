/**
    @author: DamijodaStudios
    @version: 1.0.0
    @description: file to verify if the user is logged in
    @copyright: DamijodaStudios
    
 */


import jws from 'jsonwebtoken';
import {SESS_SECRET} from '../configs/config.js'
const auth = {};

auth.isLoggedIn = (req, res, next) =>{
    if(req.isAuthenticated()){
        return next();
    }
    return res.redirect('/login');
}


auth.isAuthenticated = (req, res, next) =>{
    const authHeader = req.headers['authorization'];
    const token = authHeader && authHeader.split(' ')[1];
    if(token == null) return res.sendStatus(401);

    jws.verify(token, SESS_SECRET, (err, user)=>{
        if(err) return res.sendStatus(403);
        req.user = user;
        next();
    });
}

export {auth}