async function lockedProfile() {
    const profileDiv = document.querySelector('.profile');
    const mainElement = document.getElementById('main');
    mainElement.addEventListener('click', showHiddenInfo);

    try {
        mainElement.innerHTML = '';

        const response = await fetch(`http://localhost:3030/jsonstore/advanced/profiles`);

        if (response.status !== 200) {
            throw new Error(`Error ${response.status}: ${response.statusText}. Refresh and try again`);
        }

        const data = await response.json();

        for (const profile in data) {
            const newProfileDiv = profileDiv.cloneNode(true);

            newProfileDiv.querySelector('[name="user1Username"]').value = data[profile].username;
            newProfileDiv.querySelector('[name="user1Email"]').value = data[profile].email;
            newProfileDiv.querySelector('[name="user1Age"]').value = data[profile].age;

            mainElement.appendChild(newProfileDiv);
        }

    } catch (error) {
        const h1Element = document.createElement('h1');
        h1Element.textContent = error.message;
        mainElement.innerHTML = '';
        mainElement.appendChild(h1Element);
    }

    function showHiddenInfo(ev) {
        if (ev.target.tagName.toLowerCase() == 'button' &&
            ev.target.parentNode.children[2].checked == false) {

            const hiddenChildren = ev.target.parentNode.children[9].children;
            
            console.log(hiddenChildren);
            if (ev.target.textContent === 'Show more') {
                for (let i = 1; i <= 4; i++) {
                    hiddenChildren[i].style.display = 'block';
                }
                
                ev.target.textContent = 'Hide it';
            }
            else {
                for (let i = 1; i <= 4; i++) {
                    hiddenChildren[i].style.display = 'none';
                }
                ev.target.textContent = 'Show more';
            }
        }
    }
}