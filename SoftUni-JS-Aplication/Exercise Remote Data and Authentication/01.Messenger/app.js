const url = `http://localhost:3030/jsonstore/messenger`;
const messages = document.getElementById('messages');

function attachEvents() {

    document.getElementById('submit').addEventListener('click', sumbit);
    document.getElementById('refresh').addEventListener('click', refresh);

}

async function sumbit() {

    const inputNameElement = document.querySelector('input[name="author"]');
    const  inputMessageElement = document.querySelector('input[name="content"]');

    const name = inputNameElement.value;
    const message = inputMessageElement.value;

    if(inputNameElement.value != '' && inputMessageElement.value != '') {

            await fetch(url, {

            method: 'POST',
            headers: {
                'Content-Type': `aplication/json`
            },
            body: JSON.stringify({author:name, content: message})
        });

        inputNameElement.value = '';
        inputMessageElement.value = '';
    }
}

async function refresh() {

    const response = await fetch(url);
    const data = await response.json();

    messages.value = Object.values(data)
    .map(data => `${data.author}: ${data.content}`)
    .join('\n');
}

attachEvents();