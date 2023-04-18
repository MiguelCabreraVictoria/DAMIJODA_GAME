document.getElementById('menu-btn').addEventListener('click', openCloseMenu);

let side_menu = document.getElementById('side-menu');
let menu_btn = document.getElementById('menu-btn');
let main = document.getElementById('main');
let content = document.getElementById('content');

function openCloseMenu() {
    main.classList.toggle('move-main');
    side_menu.classList.toggle('side-menu-move');
    content.classList.toggle('content-move');
    side_menu.classList.remove('side-menu-colapse');
    side_menu.classList.remove('side-menu-expand');
}

function expandMenu() {
  side_menu.classList.toggle('side-menu-expand');
  side_menu.classList.remove('side-menu-colapse');
}

function colapseMenu() {
    side_menu.classList.toggle('side-menu-colapse');
    side_menu.classList.remove('side-menu-expand');
}