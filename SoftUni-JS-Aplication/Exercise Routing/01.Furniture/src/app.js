import { catalogPage } from "./views/catalog.js";
import { createPage } from "./views/create.js";
import { detailsPage } from "./views/details.js";
import { editPage } from "./views/edit.js";
import { loginPage } from "./views/login.js";
import { registerPage } from "./views/register.js";
import { page, render } from "./lib.js";
import { logout } from "./api/users.js";
import { getUserData } from "./api/api.js";

const root = document.querySelector('div.container');
document.getElementById('logoutBtn').addEventListener('click', onLogout);

page(decorateContext);
page('/', catalogPage);
page('/details/:id', detailsPage);
page('/create', createPage);
page('/edit/:id', editPage);
page('/login', loginPage);
page('/register', registerPage);
page('/my-furniture', catalogPage);

updateUserNav();
page.start();

function decorateContext(ctx, next) {

    ctx.render = (content) => render(content, root);
    ctx.updateUserNav = updateUserNav;
    next();
}

function updateUserNav() {

    const user = getUserData();

    if(user) {

        document.getElementById('user').style.display = 'inline-block';
        document.getElementById('guest').style.display = 'none';

    } else {

        document.getElementById('user').style.display = 'none';
        document.getElementById('guest').style.display = 'inline-block';

    }
}

async function onLogout() {

    await logout();
    updateUserNav();
    page.redirect('/');
}

page('/');