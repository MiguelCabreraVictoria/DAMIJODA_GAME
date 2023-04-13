import express from 'express';
const router = express.Router();


import {GetLogin,PostLogin,GetSingup,PostSignup,GetProfile} from '../controllers/authentication.controller.js';

//Login routes
router.get('/login',GetLogin);
router.post('/login',PostLogin);



//Login routes
router.get('/signup', GetSingup);
router.post('/signup', PostSignup);


//profile
router.get('/profile',GetProfile);

export default router;