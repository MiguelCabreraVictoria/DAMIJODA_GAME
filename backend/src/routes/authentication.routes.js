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
        GetPage,
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
        PostMatches,
        GetLogout} from '../controllers/authentication.controller.js';

router.get('/',GetIndex);
router.get('/DAMIJODASTUDIOS',GetPage);

//Login routes
router.get('/login',GetLogin);
router.post('/login',PostLogin);

//SignUp routes
router.get('/signup', GetSingup);
router.post('/signup', PostSignup);

//profile
router.get('/profile',auth.isLoggedIn,GetProfile);

//logout 
router.get('/logout',GetLogout)


//Json get endpoints

//------------------GET DATA------------------//

router.get('/profile/api/matches',auth.isLoggedIn,GetMatches);
router.get('/profile/api/levels', auth.isLoggedIn,GetLevels);
router.get('/profile/api/bosses', auth.isLoggedIn,GetBosses);
router.get('/profile/api/enemies', auth.isLoggedIn,GetEnemies);
router.get('/profile/api/characters', auth.isLoggedIn,GetCharacters);
router.get('/profile/api/gems', auth.isLoggedIn,GetGems);
router.get('/profile/api/armors', auth.isLoggedIn,GetArmors);
router.get('/profile/api/weapons', auth.isLoggedIn,GetWeapons);

//---------------POST DATA-----------------//

router.post('/profile/api/matches',auth.isLoggedIn,PostMatches);

//---------------PUT DATA-----------------//


//404 page

// router.all('*',GetError404);




export default router;
