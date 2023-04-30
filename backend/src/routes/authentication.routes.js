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

import {GetIndex,
        GetLogin,
        PostLogin,
        GetSingup,
        PostSignup,
        GetProfile,
        GetMatches,
        GetLevels,
        GetBosses,
        GetEnemies,
        GetCharacters,
        GetGems,
        GetArmors,
        GetWeapons,
        GetLogout} from '../controllers/authentication.controller.js';

router.get('/',auth.isLoggedIn,GetIndex);

//Login routes

router.get('/login',GetLogin);
router.post('/login',PostLogin);

//Login routes
router.get('/signup', GetSingup);
router.post('/signup', PostSignup);

//profile
router.get('/profile',auth.isLoggedIn,GetProfile);

//logout 
router.get('/logout',GetLogout)

//Json get endpoints

router.get('/profile/api/matches',auth.isLoggedIn,GetMatches);
router.get('/profile/api/levels', auth.isLoggedIn,GetLevels);
router.get('/profile/api/bosses', auth.isLoggedIn,GetBosses);
router.get('/profile/api/enemies', auth.isLoggedIn,GetEnemies);
router.get('/profile/api/characters', auth.isLoggedIn,GetCharacters);
router.get('/profile/api/gems', auth.isLoggedIn,GetGems);
router.get('/profile/api/armors', auth.isLoggedIn,GetArmors);
router.get('/profile/api/weapons', auth.isLoggedIn,GetWeapons);



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
