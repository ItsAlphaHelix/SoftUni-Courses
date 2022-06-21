const url = `http://localhost:3030/jsonstore/phonebook`;

function attachEvents() {

    document.getElementById('btnLoad').addEventListener('click', loadInformation);
    document.getElementById('btnCreate').addEventListener('click', createInfomation);

}

async function loadInformation() {

    const phoneBookElement = document.getElementById('phonebook'); 

    const response = await fetch(url);
    const data = await response.json();

    phoneBookElement.innerHTML = '';

    for (const key in data) {
       
        const liElement = document.createElement('li');
        const deleteButton = document.createElement('button');
        deleteButton.addEventListener('click', deleteInformation.bind(null, key));
        deleteButton.innerText = 'Delete';

        liElement.innerText = `${data[key].person}: ${data[key].phone}`;
        liElement.appendChild(deleteButton);

        phoneBookElement.appendChild(liElement);
    }

    async function deleteInformation(key, event) {
        
        await fetch(`${url}/${key}`, {
            method: 'DELETE',
        });

        event.target.parentNode.remove();
    }
}

async function createInfomation() {

    const [inputPersonElement, inputPhoneElement]
     = [document.getElementById('person'), document.getElementById('phone')];

    const person = inputPersonElement.value;
    const phone = inputPhoneElement.value;

    if(inputPersonElement.value != '' && inputPhoneElement.value != '') {

        await fetch(url, {

            method: 'POST',
            headers: {
                'Content-Type': 'aplication/json'
            },    
            body: JSON.stringify({person: person, phone: phone})
        });

        inputPersonElement.value = '';
        inputPhoneElement.value = '';
    }
}

attachEvents();