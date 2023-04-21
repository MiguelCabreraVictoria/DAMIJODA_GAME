/**
    @author: DamijodaStudios
    @version: 1.0.0
    @description: password encryption to database
    @copyright: DamijodaStudios
    
 */

import bycrypt from 'bcryptjs';


const helpers = {}

helpers.encryptPassword = async (password) =>{
    const salt = await bycrypt.genSalt(10); // se genera un patron, repitiendo 10 veces el algoritmo;
    const hash = await bycrypt.hash(password, salt); // metodo para cifrar contraseña;
    return hash;
};

helpers.matchPassword = async (password,savedPassword) =>{ //se compara con lo que de el usuario y la contraseña encriptada;
    try {
        return await bycrypt.compare(password,savedPassword);
    } catch (error) {
        console.log(error);
    }
}

export{helpers};