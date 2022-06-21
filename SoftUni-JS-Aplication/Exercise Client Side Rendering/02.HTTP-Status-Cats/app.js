import { html, render } from "../node_modules/lit-html/lit-html.js";
import { cats } from "./catSeeder.js";

const allCats = document.getElementById('allCats');
allCats.addEventListener('click', toogle);

const cardTemplate = (data) => html`
    <ul>
        ${data.map(cat => html`
        <li>
            <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
            <div class="info">
                <button class="showBtn"> Show status code</button>
                <div class="status" style="display: none" id="${cat.id}">
                    <h4>Status Code: ${cat.statusCode}</h4>
                    <p>${cat.statusMessage}</p>
                </div>
            </div>
        </li>
        `)}
    </ul>
`;

const catValues = Object.values(cats);

console.log(catValues);
update();

function update() {

    const result = cardTemplate(catValues);
    render(result, allCats);

}

function toogle(event) {
    
    if(event.target.tagName == 'BUTTON') {

        event.preventDefault();

        if(event.target.innerText == 'Show status code') {

            event.target.innerText = 'Hide status code';
            event.target.parentNode.children[1].style.display = 'block';

        } else {

            event.target.innerText = 'Show status code';
            event.target.parentNode.children[1].style.display = 'none';
        }
    }
}