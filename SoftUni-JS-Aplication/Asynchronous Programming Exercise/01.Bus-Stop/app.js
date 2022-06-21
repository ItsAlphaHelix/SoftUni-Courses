async function getInfo() {

    const stopNameElement = document.getElementById('stopName');
    const busElement = document.getElementById('buses');
    const stopIdElement = document.getElementById('stopId');
    const id = stopIdElement.value;
    const url = `http://localhost:3030/jsonstore/bus/businfo/${id}`;

    try {

        const response = await fetch(url);

        if(response.status != 200) {

            throw new Error();

        }

        const data = await response.json();        
        stopNameElement.innerText = data.name;

        busElement.innerHTML = '';

        Object.entries(data.buses).forEach(x => {

            const liElement = document.createElement('li');

            liElement.innerText = `Bus ${x[0]} arrives in ${x[1]} minutes`;
            busElement.appendChild(liElement);

        });

    } catch(ex) {

        stopNameElement.innerText = ex;

    }
}