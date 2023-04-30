/**
    @author: DamijodaStudios
    @version: 1.0.0
    @description: file of the routes
    @copyright: DamijodaStudios
    
 */

import express from 'express';
import jwt from 'jsonwebtoken';
const router = express.Router();

import {auth} from '../lib/auth.js';

import {GetIndex,GetLogin,PostLogin,GetSingup,PostSignup,GetProfile,GetMatches,GetLogout} from '../controllers/authentication.controller.js';

router.get('/',auth.isLoggedIn,GetIndex);

//Login routes

router.get('/login',GetLogin);
router.post('/login',PostLogin);



//Login routes
router.get('/signup', GetSingup);
router.post('/signup', PostSignup);


//profile
router.get('/profile',auth.isLoggedIn,GetProfile);

//Json endpoints

router.get('/profile/api/matches',ensureToken,GetMatches);





//logout 
router.get('/logout',GetLogout)

//404 page

// router.all('*',GetError404);


//Authorization: Bearer <token>
function ensureToken(req,res,next){
    const bearerHeader = req.headers["authorization"]; //get the auth header value
    console.log(bearerHeader);
    
    if(typeof bearerHeader !== 'undefined'){
        const bearer = bearerHeader.split(" ");
        const bearerToken = bearer[1];
        req.token = bearerToken;
        console.log(req.token);
        next();
    }else{
        res.sendStatus(403);
    }
}

export default router;
