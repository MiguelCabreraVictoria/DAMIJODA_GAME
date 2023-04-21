/**
    @author: DamijodaStudios
    @version: 1.0.0
    @description: file to verify if the user is logged in
    @copyright: DamijodaStudios
    
 */

const auth = {};

auth.isLoggedIn = (req, res, next) =>{
    if(req.isAuthenticated()){
        return next();
    }
    return res.redirect('/login');
}

export {auth}