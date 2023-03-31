import express from 'express';
const router = express.Router();



import {GetLogin,GetSingup} from '../controllers/authentication.controller.js'

//Login routes
router.get('/login',GetLogin)

//Login routes
router.get('/signup', GetSingup)

export default router;