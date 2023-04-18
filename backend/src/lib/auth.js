const auth = {};

auth.isLoggedIn = (req, res, next) =>{
    if(req.isAuthenticated()){
        return next();
    }
    return res.redirect('/login');
}

export {auth}