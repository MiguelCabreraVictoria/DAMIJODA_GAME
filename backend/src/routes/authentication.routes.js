/**
    @author: DamijodaStudios
    @version: 1.0.0
    @description: file of the routes
    @copyright: DamijodaStudios
    
 */

import express from 'express';
const router = express.Router();

import {auth} from '../lib/auth.js';

import {GetIndex,GetLogin,PostLogin,GetSingup,PostSignup,GetProfile,GetMatches,GetLogout,GetError404} from '../controllers/authentication.controller.js';

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

router.get('/profile/api/matches',auth.isLoggedIn,GetMatches);



//logout 
router.get('/logout',GetLogout)

//404 page

router.all('*',GetError404);

export default router;