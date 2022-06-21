async function solution() {

    const mainElement = document.getElementById('main');

    try {

        const url = `http://localhost:3030/jsonstore/advanced/articles/list`;
        const response = await fetch(url);

        if(response.status != 200) {

            throw new Error(`${response.status}. ${response.statusText}.`);

        }

        const data = await response.json();

        for (const d of data) {
            
            const divAccordion = document.createElement('div');
            divAccordion.classList.add('accordion');

            const divHead = document.createElement('div');
            divHead.classList.add('head');

            const spanElement = document.createElement('span');
            spanElement.innerText = d.title;

            const button = document.createElement('button');
            button.classList.add('button');
            button.setAttribute('id', d._id);
            button.innerText = 'MORE';

            const extraElement = document.createElement('div');
            extraElement.classList.add('extra');

            const pElement = document.createElement('p');

            button.addEventListener('click', toogle);

            divHead.appendChild(spanElement);
            divHead.appendChild(button);
            divAccordion.appendChild(divHead);
            extraElement.appendChild(pElement);
            divAccordion.appendChild(extraElement);
            mainElement.appendChild(divAccordion);
        }

    } catch(error) {

        const h1Element = document.createElement('h1');
        h1Element.innerText = error;
        h1Element.style.textAlign = 'center';
        mainElement.appendChild(h1Element);
    }

    async function toogle(event) {
        const id  = event.target.id;
        const url = `http://localhost:3030/jsonstore/advanced/articles/details/${id}`
        const response = await fetch(url);
        const data = await response.json();

        const extra = event.target.parentNode.parentNode.children[1];
        const content = event.target.parentNode.parentNode.children[1].children[0];

        content.innerText = data.content;

        if(event.target.innerText == 'MORE') {

            event.target.innerText = 'LESS'
            extra.style.display = 'block';

        } else {

            event.target.innerText = 'MORE'
            extra.style.display = 'none';

        }       

    }

}