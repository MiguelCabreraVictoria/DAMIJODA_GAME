/**
    @author: DamijodaStudios
    @version: 1.0.0
    @description: file of the routes
    @copyright: DamijodaStudios
    
 */

import express from 'express';
const router = express.Router();

import {auth} from '../lib/auth.js';

import {GetIndex,GetLogin,PostLogin,GetSingup,PostSignup,GetProfile,GetLogout} from '../controllers/authentication.controller.js';

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

export default router;