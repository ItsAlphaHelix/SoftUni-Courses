import { getToken } from "./auth.js";
import { renderHome } from "./home.js";

const createSection = document.querySelector('.create');
const createForm = createSection.querySelector('form');

createForm.addEventListener('submit', async (event) => {

    event.preventDefault();
    const formData = new FormData(event.currentTarget);
    console.log(event.currentTarget);
    const name = formData.get('name');
    const img = formData.get('img');
    const ingredients = formData.get('ingredients').split('\n');
    const steps = formData.get('steps').split('\n');
    console.log(ingredients);
    let data = {
        name,
        img,
        ingredients,
        steps,
    };

    
    await fetch('http://localhost:3030/data/recipes', {

      method: 'POST',
      headers: {

        'content-type': 'aplication/json',
        'X-Authorization': getToken()

      },
      body: JSON.stringify(data)
    });
    alert('Successfuly create recipe!');
    createSection.style.display = 'none';
    renderHome();
});

export function createRender() {

    createSection.style.display = 'block';

}