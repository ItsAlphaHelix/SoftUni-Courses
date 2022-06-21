const views = [...document.querySelectorAll('.view-section')];

function hideAll() {
    
    views.forEach(x => x.style.display = 'none');

}

export function showView(section) {

    hideAll();
    section.style.display = 'block';

}

 export function spinner() {

    const element = document.createElement('p');
    element.innerHTML = 'Loading ...';

  return element;
}

export function updateNav() {

    const user = JSON.parse(localStorage.getItem('user'));
    const msgContainer = document.getElementById('welcome-msg');

    if(user) {

        document.querySelectorAll('.user').forEach(x => x.style.display = 'inline-block');     
        document.querySelectorAll('.guest').forEach(x => x.style.display = 'none');
        msgContainer.innerText =`Welcome, ${user.email}`;

    }else {

        document.querySelectorAll('.user').forEach(x => x.style.display = 'none');  
        document.querySelectorAll('.guest').forEach(x => x.style.display = 'inline-block');
        msgContainer.innerText = '';

    }
}
export function updateRegisterNav() {

    const user = JSON.parse(localStorage.getItem('user'));

    if(user) {

        document.querySelectorAll('.guest')[1].children[0].style.display = 'none'; 

    } else {

        document.querySelectorAll('.guest')[1].children[0].style.display = 'inline-block'; 

    }
}