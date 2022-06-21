import { html, render } from "../node_modules/lit-html/lit-html.js";

const url = `http://localhost:3030/jsonstore/collections/books`;

const booksTemplate = (data) => html`
    ${data.map(x => html`
    <tr>
        <td>${x.title}</td>
        <td>${x.author}</td>
        <td>
            <button>Edit</button>
            <button>Delete</button>
        </td>
    </tr>
    `)}
`;

const form = document.getElementById('add-form');
form.addEventListener('click', inviteBook);

const tbody = document.querySelector('tbody');
const button = document.getElementById('loadBooks');
button.addEventListener('click', loadBook);

function loadBook() {

    update();
}

async function update(values) {

    const data = await getRequest(values);
    const result = booksTemplate(data);
    render(result, tbody);
}

async function getRequest() {

    const response = await fetch(url);
    const data = await response.json();
    const values = Object.values(data);

    return values;
}

async function postRequest(values) {

    const data = inviteBook(values);
    console.log(data);
    const response = await fetch(url, {

        method: 'POST',
        headers: {

            'Content-Type': 'application/json'

        },
        body: JSON.stringify(data)
    });

    const value = await response.JSON();

    update(value);
}

function inviteBook(event) {

    if (event.target.value == 'Submit') {

        event.preventDefault();
        const formData = new FormData(form);
        const title = formData.get('title');
        const author = formData.get('author');

        const data = {
            title,
            author,
        }
        console.log(data)

        return data;

    }
}
