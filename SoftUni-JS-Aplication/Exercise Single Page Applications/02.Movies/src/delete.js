import { homePage } from "./home.js";
import { spinner } from "./util.js";

export function attachDeleteEvent(element, movieId) {

  const deleteBtn =  element.querySelector('.delete-btn');

  deleteBtn.addEventListener('click', onDelete.bind(null, movieId));
}

async function onDelete(movieId, event) {

    event.preventDefault();

    const user = JSON.parse(localStorage.getItem('user'));
    event.target.parentNode.replaceChildren(spinner());

    await fetch(`http://localhost:3030/data/movies/${movieId}`, {

        method: 'DELETE',
        headers: {

            'Content-Type': 'application/json',
            'X-Authorization': user.accessToken

        }
    });
    homePage();
}
