import { showView, spinner } from "./util.js";
import { homePage } from "./home.js";

const section = document.querySelector('#edit-movie');
const form = section.querySelector('.text-center');

export function attachEditEvent(element, id) {

    const editButton = element.querySelector('.edit-btn');
    editButton.addEventListener('click', onEdit.bind(null, id))

}

function editPage() {

    showView(section);
}

function onEdit(id, event) {

    event.preventDefault();
    editPage();
    form.addEventListener('submit', onSubmit.bind(null, id));

}

async function onSubmit(movieId, event) {

    event.preventDefault();
    
    const formData = new FormData(form);
    const user = JSON.parse(localStorage.getItem('user'));

    const movieTitle = formData.get('title');
    
    const movieDescription = formData.get('description');
    const movieUrl = formData.get('imageUrl');

    try {

        const response = await fetch(`http://localhost:3030/data/movies/${movieId}`, {

            method: 'PUT',
            headers: {

                'Content-Type': 'application/json',
                'X-Authorization': user.accessToken
            },

            body: JSON.stringify({title: movieTitle, description: movieDescription, img: movieUrl})

        });
         if(!response.ok) {

            const error = await response.json(); 
            throw new Error(error.message);
         }
        form.reset();   
        homePage();

    } catch (err) {

        alert(err.message);
        throw err;

  }

}