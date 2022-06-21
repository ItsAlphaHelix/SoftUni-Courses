import { html, render } from "../node_modules/lit-html/lit-html.js";

const menuTemplate = (data) => html`
<h1>Dropdown Menu</h1>
<article>
    <div>
        <select id="menu">
            ${data.map(x => html`
            <option value=${x._id}>${x.text}</option>`)}
        </select>
    </div>
    <form>
        <label for="itemText">
            Text:
        </label>
        <input type="text" id="itemText" />
        <input type="submit" value="Add">
    </form>
</article>
`
const url = 'http://localhost:3030/jsonstore/advanced/dropdown';
const main = document.body;
main.addEventListener('click', addItem);
update();

async function update(dates) {
    const data = await getRequest(dates);
    const result = menuTemplate(data);

    render(result, main);
}

function addItem(event) {

    if (event.target.value == 'Add') {

        event.preventDefault()
        if (document.getElementById('itemText').value != '') {

            const inputField = document.getElementById('itemText').value;
            postRequest(inputField);
            update(inputField);

            document.getElementById('itemText').value = '';
        }
    }
}

async function getRequest() {

    const response = await fetch(`${url}`);
    const data = await response.json();
    const values = Object.values(data);

    return values;
}

async function postRequest(inputField) {

    const response = await fetch(`${url}`, {

        method: 'POST',
        headers: {

            'Content-Type': 'application/json',

        },
        body: JSON.stringify({ text: inputField })
    })
    const data = await response.json();

    return data;
}
