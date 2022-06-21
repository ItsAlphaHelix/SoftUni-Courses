import { showView, updateRegisterNav } from "./util.js";
import { loginPage } from "./login.js";

const section = document.querySelector('#form-sign-up');
const form = section.querySelector('form');
form.addEventListener('submit', onSubmit);

export function registerPage() {

    showView(section);

}

async function onSubmit(event) {

    event.preventDefault();

    const formData = new FormData(form);
    const email = formData.get('email');
    const password = formData.get('password');
    const repeatPassword = formData.get('repeatPassword');
    
    await register(email, password, repeatPassword);
    form.reset();
    loginPage();
    updateRegisterNav();
}

async function register(email, password, repeatPassword) {

    try {

        const response = await fetch('http://localhost:3030/users/register', {

        method: 'POST',
        headers: {

            'Content-Type': 'application/json'

        },
        body: JSON.stringify({email, password, repeatPassword})

    });

    if(!response.ok) {

        const error = await response.json();
        throw new Error(error.message);
    }

    const data = await response.json();
    localStorage.setItem('user', JSON.stringify(data));

    } catch(err) {

        alert(err.message);
        throw err;
    }
}