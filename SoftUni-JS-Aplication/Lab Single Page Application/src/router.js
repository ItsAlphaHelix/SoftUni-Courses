import { renderHome } from "./home.js";
import { renderLogin } from "./login.js";
import { registerRender } from "./register.js";
import { createRender } from "./create.js";
import { renderLogout } from "./logout.js";
import { notFoundRender } from "./404.js";

const routes = {

    '/': renderHome,
    '/login': renderLogin,
    '/register': registerRender,
    '/create': createRender,
    '/logout': renderLogout
}

export function router(path) {

    hideContent();

    const renderer = routes[path] || notFoundRender;
    renderer();
}
function hideContent() {

    const mainContent = document.querySelector('.main-content');
    Array.from(mainContent.children).map(section => section.style.display = 'none');

}