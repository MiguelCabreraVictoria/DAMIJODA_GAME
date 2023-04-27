/**
    @author: DamijodaStudios
    @version: 1.0.0
    @description: main file of the project
    @copyright: DamijodaStudios
    
 */

document.getElementById('login-button').addEventListener('click', openMenuBox);

let h2 = document.getElementById('h2');
let form_box = document.getElementById('form-box');
let login_logo_button = document.getElementById('login-logo-button');
let function_move =  document.getElementById('functions');
let section = document.getElementById('section-background');

function openMenuBox() {
    h2.classList.toggle('h2-move');
    form_box.classList.toggle('form-box-move');
    section.classList.toggle('section-background-change');
}

let loginButton = document.getElementById('login-button');

loginButton.addEventListener('click', () => {
  document.body.classList.toggle('color-changed');
});
  
