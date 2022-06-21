import { renderLogin } from "./login.js";
import { updateAuth } from "./auth.js";

const registerSection = document.querySelector('.register');
const registerForm = registerSection.querySelector('form');

registerForm.addEventListener('submit', async (event) => {

    event.preventDefault();

    const formData = new FormData(event.currentTarget);
    const email = formData.get('email');
    const password = formData.get('password');
    const repeatPassword = formData.get('rePass');

    if (password != repeatPassword) {

        alert('Тhe password must be the same!');
        return;
    }
    if (email == '' || password == '' || repeatPassword == '') {

        alert('You must fill all the fields!')
        return;

    }


    try {

        const response = await fetch('http://localhost:3030/users/register', {

            method: 'POST',
            headers: {

                'content-type': 'aplication/json'

            },
            body: JSON.stringify({ email, password, repeatPassword })

        });

        if (!response.ok || response.status != 200) {
            registerForm.reset();
            throw new Error(data.message);
        }

        const data = await response.json();
        localStorage.setItem('user', JSON.stringify(data));
        registerForm.reset();
        renderLogin();
        updateAuth();
        registerSection.style.display = 'none';
        alert('Successfuly register!');


    } catch (err) {

        alert(err.message);

    }
});

export function registerRender() {

    registerSection.style.display = 'block';

}