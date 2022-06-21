import { homePage } from './home.js';
import { showView} from './util.js';

const section = document.querySelector('#add-movie');
const form = section.querySelector('form');
form.addEventListener('submit', onSubmit);

export function createPage() {
    showView(section);
}

async function onSubmit(event) {

    event.preventDefault();
    const formData = new FormData(form);

    const title = formData.get('title');
    const description = formData.get('description');
    const img = formData.get('imageUrl');

    await createMovie(title, description, img);
    form.reset();
    homePage();
}

async function createMovie(title, description, img) {

    if(title == '' || description == '' || img == '') {

        alert('Fill in all fields!');
        return;

    }

   try {
    const user = JSON.parse(localStorage.getItem('user'));

    const response = await fetch('http://localhost:3030/data/movies', {

        method: 'POST',
        headers: {

            'Content-Type': 'application/json',
            'X-Authorization': user.accessToken

        },
        body: JSON.stringify({title, description, img})
    });

    if(!response.ok) {

        const error = await response.json();
        throw new Error(error.message);
    }

   } catch(err) {

        alert(err.message);
        throw err;
   }
}
