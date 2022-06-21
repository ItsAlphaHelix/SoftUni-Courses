function solve() {

    const label = document.querySelector('#info span');
    const deparBtn = document.getElementById('depart');
    const arriveBtn = document.getElementById('arrive');

    let stop = {

        next: 'depot'

    }

   async function depart() {
       
        deparBtn.disabled = true;

        
            const url = `http://localhost:3030/jsonstore/bus/schedule/${stop.next}`;
            const response = await fetch(url);

            if(response.status != 200) {
                
                label.innerText = `Error!`;
                deparBtn.disabled = true;
                arriveBtn.disabled = true;

            } 

        stop = await response.json();
        label.innerText = `Next stop ${stop.name}`;
        arriveBtn.disabled = false;

    }

    async function arrive() {

        arriveBtn.disabled = true;
        deparBtn.disabled = false;
        label.innerText = `Arriving at ${stop.name}`;

    }

    return {
        depart,
        arrive
    };
}

let result = solve();