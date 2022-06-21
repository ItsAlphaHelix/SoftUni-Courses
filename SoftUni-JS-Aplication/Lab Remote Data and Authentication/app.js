const baseUrl = `http://localhost:3030`;

window.addEventListener('load', async () => {

    const mainElement = document.querySelector('main');
    const response = await fetch(`${baseUrl}/jsonstore/cookbook/recipes`);
    const data = await response.json();

    mainElement.innerHTML = '';

    Object.values(data).forEach(recipe => {

        const articleElement = document.createElement('article');
        articleElement.addEventListener('click', showDetails.bind(null, recipe._id));
        articleElement.classList.add('preview');

        const titleDivElement = document.createElement('div');
        titleDivElement.classList.add('title');

        const h2Element = document.createElement('h2');

        const divSmallElement = document.createElement('div');
        divSmallElement.classList.add('small');

        const imgElement = document.createElement('img');
        imgElement.setAttribute('src', recipe.img);

        h2Element.innerText = recipe.name;

        divSmallElement.appendChild(imgElement);
        titleDivElement.appendChild(h2Element);
        articleElement.appendChild(titleDivElement);
        articleElement.appendChild(divSmallElement);

        mainElement.appendChild(articleElement);
    });

    async function showDetails(id, event) {
       
        if (event.target.tagName.toLowerCase() == 'article') {

            const detailsUrl = `${baseUrl}/jsonstore/cookbook/details/${id}`
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
        }
    }
});