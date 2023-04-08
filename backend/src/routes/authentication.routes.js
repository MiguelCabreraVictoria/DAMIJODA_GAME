import express from 'express';
const router = express.Router();

//import {pool} from '../database_connection.js'

import {GetLogin,PostLogin,GetSingup,PostSignup} from '../controllers/authentication.controller.js';

//Login routes
router.get('/login',GetLogin);
router.post('/login',PostLogin);



//Login routes
router.get('/signup', GetSingup);
router.post('/signup', PostSignup);

export default router;