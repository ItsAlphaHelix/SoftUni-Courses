const url = `http://localhost:3030/jsonstore/collections/books`;

const tbodyElement = document.querySelector('table tbody');
function attachEvents() {

    document.getElementById('loadBooks').addEventListener('click', loadBooks);
    document.querySelector('#form button').addEventListener('click', submitBook);
    tbodyElement.innerHTML = '';
}
async function loadBooks() {

    const response = await fetch(url);
    const data = await response.json();

    tbodyElement.innerHTML = '';

    for (const key in data) {

        const trElement = document.createElement('tr');
        const tdTitleElement = document.createElement('td');
        tdTitleElement.innerText = data[key].title;
        trElement.appendChild(tdTitleElement);

        const tdAuthorElement = document.createElement('td');
        tdAuthorElement.innerText = data[key].author;
        trElement.appendChild(tdAuthorElement);

        const tdAction = document.createElement('td');

        const editButton = document.createElement('button');
        editButton.innerText = 'Edit';
        editButton.addEventListener('click', editBook.bind(null, key));
        tdAction.appendChild(editButton);

        const deleteButton = document.createElement('button');
        deleteButton.addEventListener('click', deleteBook.bind(null, key));
        deleteButton.innerText = 'Delete';
        tdAction.appendChild(deleteButton);

        trElement.appendChild(tdAction);
        tbodyElement.appendChild(trElement);

    }
}

function editBook(id, event) {
    const inputTitleElement = document.querySelector('#edit-form input[name="title"]');
    const inputAuthorElement = document.querySelector('#edit-form input[name="author"]');
   
    const book = event.target.parentNode.parentNode;

    inputTitleElement.value = book.children[0].innerText;
    inputAuthorElement.value = book.children[1].innerText;

    document.querySelector('#edit-form button').addEventListener('click', submitEditBook.bind(null, id)).innerText = 'Save';
}

async function submitEditBook(id, event) {

    event.preventDefault();

    title = event.target.parentNode.children[2];
    author = event.target.parentNode.children[4];

    const putRequestBody = {

        title: title.value,
        author: author.value,

    }

    await fetch(`${url}/${id}`, {

        method: 'PUT',
        headers: {

            'Content-Type': 'application/json'

        },
        body: JSON.stringify(putRequestBody)
    });

    title.value = '';
    author.value = '';

}

async function deleteBook(id, event) {

    await fetch(`${url}/${id}`, {

        method: 'DELETE'

    });

    event.target.parentNode.parentNode.remove();
}
async function submitBook(event) {

    event.preventDefault();

    const inputTitleElement = document.querySelector('input[name="title"]');
    const inputAuthorElement = document.querySelector('input[name="author"]');

    if(inputAuthorElement.value == '' || inputTitleElement.value == '') {

        return;

    }

    await fetch(`${url}`, {

        method: 'POST',
        headers: {

            'Content-Type': 'application/json'

        },
        body: JSON.stringify({ title: inputTitleElement.value, author: inputAuthorElement.value })

    });

    inputTitleElement.value = '';
    inputAuthorElement.value = '';
}
attachEvents();