import express from 'express';
const router = express.Router();

import {GetHola} from '../controllers/authentication.controller.js'

router.get('/',GetHola)


export default router;