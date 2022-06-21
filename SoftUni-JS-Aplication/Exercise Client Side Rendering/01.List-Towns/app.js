import { html, render } from "../node_modules/lit-html/lit-html.js";

document.getElementById('btnLoadTowns').addEventListener('click', loadTowns);
const listTemplate = (data) => html`
    <ul>
        ${data.map(town => html`<li>${town}</li>`)}
    </ul>
`

function loadTowns(event) {

    event.preventDefault();

    const rootElement = document.getElementById('root');
    
    if (document.getElementById('towns').value != '') {

        const towns = document.getElementById('towns').value.split(', ');
        const result = listTemplate(towns);

        render(result, rootElement);

        document.getElementById('towns').value = '';

    }
}