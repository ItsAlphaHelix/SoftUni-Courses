const baseUrl = `http://localhost:3030`;
const homeSection = document.querySelector('.home');
const activeElement = document.querySelector('.active');

export async function renderHome() {

    const response = await fetch(`${baseUrl}/data/recipes`);
    const data = await response.json();
    renderRecipe(data);
    homeSection.style.display = 'block';

}

function renderRecipe(data) {
    const h2Element = document.createElement('h2');
    h2Element.innerText = 'Catalog';
    homeSection.appendChild(h2Element);

    homeSection.replaceChildren();

    Object.values(data).forEach(data => {

        const articleElement = document.createElement('article');
        articleElement.addEventListener('click', renderHiddenInfo.bind(null, data._id));
        articleElement.classList.add('preview');

        const divTitleElement = document.createElement('div');
        divTitleElement.classList.add('title');

        const h2TitleElement = document.createElement('h2');
        h2TitleElement.innerText = data.name;
        divTitleElement.appendChild(h2TitleElement);
        articleElement.appendChild(divTitleElement);

        const divImgElement = document.createElement('div');
        divImgElement.classList.add('small');

        const imgElement = document.createElement('img');
        imgElement.setAttribute('src', data.img);
        divImgElement.appendChild(imgElement);
        articleElement.appendChild(divImgElement);

        homeSection.appendChild(articleElement);
    });
}

async function renderHiddenInfo(id, event) {

    if (event.target.tagName == 'ARTICLE') {

        const detailsUrl = `${baseUrl}/data/recipes/${id}`
        const detailsResponse = await fetch(detailsUrl);
        const detailsData = await detailsResponse.json();

        event.target.innerHTML = '';

        const h2Element = document.createElement('h2');
        h2Element.innerText = detailsData.name;
        event.target.appendChild(h2Element);

        const divBandElement = document.createElement('div');
        divBandElement.classList.add('band');
        event.target.appendChild(divBandElement);

        const divThumbElement = document.createElement('div')
        divThumbElement.classList.add('thumb');
        divBandElement.appendChild(divThumbElement);

        const imgElement = document.createElement('img');
        imgElement.setAttribute('src', detailsData.img);
        divThumbElement.appendChild(imgElement);

        const divIngredient = document.createElement('ingredients');
        divIngredient.classList.add('ingredients');
        divBandElement.appendChild(divIngredient);

        const h3Element = document.createElement('h3');
        h3Element.innerText = 'Ingredients:';
        divIngredient.appendChild(h3Element);

        const ulElement = document.createElement('ul');
        divIngredient.appendChild(ulElement);

        detailsData.ingredients.forEach(ingredient => {

            const liElement = document.createElement('li');
            liElement.innerText = ingredient;
            ulElement.appendChild(liElement);
        });

        const divDescription = document.createElement('description');
        divDescription.classList.add('description');
        event.target.appendChild(divDescription);

        const h3PrepartionElement = document.createElement('h3')
        h3PrepartionElement.innerText = 'Preparations:';
        divDescription.appendChild(h3PrepartionElement);

        detailsData.steps.forEach(preparetaion => {

            const pElement = document.createElement('p');
            
            pElement.innerText = preparetaion;
            divDescription.appendChild(pElement);
        });

        const editButton = document.createElement('button');
        editButton.innerText = 'Edit';
        divDescription.appendChild(editButton);
    }
}