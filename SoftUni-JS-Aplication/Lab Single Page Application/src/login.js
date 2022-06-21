import { updateAuth } from "./auth.js";
import { renderHome } from "./home.js";

const loginSection = document.querySelector('.login');
const loginForm = loginSection.querySelector('form');

loginForm.addEventListener('submit', async (event) => {

    event.preventDefault();

    let formData = new FormData(event.currentTarget);
    let email = formData.get('email');
    let password = formData.get('password');
    
    if(email == '' || password == ''){

        alert('You must fill all the fields!')
        return;
    }
        const response = await fetch('http://localhost:3030/users/login', {

        method: 'POST',
        headers: {

            'content-type': 'aplication/json'
            
        },
        body: JSON.stringify({email, password})

    });

    if(!response.ok || response.status != 200) {

        alert('Incorrect password or email');
        loginForm.reset();
        return;
    }

    const data = await response.json();
    localStorage.setItem('user', JSON.stringify(data));
    updateAuth();
    loginForm.reset();
    renderHome();
    loginSection.style.display = 'none';
    alert('Successfully log in!');

});   

export function renderLogin() {

    loginSection.style.display = 'block';

}