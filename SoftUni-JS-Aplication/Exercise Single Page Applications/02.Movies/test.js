/*
const routes = {
    '/': homePage, 
    '/login': loginPage,
    '/logout': logout,
    '/register': registerPage,
    '/create': createPage,
};
document.querySelector('nav').addEventListener('click', onNavigate);
document.querySelector('#add-movie-button a').addEventListener('click', onNavigate);

function onNavigate(event) {
    if (event.target.tagName == 'A' && event.target.href) {
        event.preventDefault();
        
        const url = new URL(event.target.href);
        const view = routes[url.pathname];

        if (typeof view == 'function') {
            view();
        }
    }
}

function logout() {
    localStorage.removeItem('user');
    updateNav();
}

updateNav();
homePage();
const section = document.querySelector('#add-movie');
const form = section.querySelector('form');
form.addEventListener('submit', onSubmit);

export function createPage() {
    showView(section);
}

async function onSubmit(event) {

    event.preventDefault();
    const formData = new FormData(form);

    const title = formData.get('title');
    const description = formData.get('description');
    const img = formData.get('imageUrl');

    await createMovie(title, description, img);
    form.reset();
    homePage();
}

async function createMovie(title, description, img) {

    if(title == '' || description == '' || img == '') {

        alert('Fill in all fields!');
        return;

    }

   try {
    const user = JSON.parse(localStorage.getItem('user'));

    const response = await fetch('http://localhost:3030/data/movies', {

        method: 'POST',
        headers: {

            'Content-Type': 'application/json',
            'X-Authorization': user.accessToken

        },
        body: JSON.stringify({title, description, img})
    });

    if(!response.ok) {

        const error = await response.json();
        throw new Error(error.message);
    }

   } catch(err) {

        alert(err.message);
        throw err;
   }
}
export function attachDeleteEvent(element, movieId) {

    const deleteBtn =  element.querySelector('.delete-btn');
  
    deleteBtn.addEventListener('click', onDelete.bind(null, movieId));
  }
  
  async function onDelete(movieId, event) {
  
      event.preventDefault();
  
      const user = JSON.parse(localStorage.getItem('user'));
      event.target.parentNode.replaceChildren(spinner());
  
      await fetch(`http://localhost:3030/data/movies/${movieId}`, {
  
          method: 'DELETE',
          headers: {
  
              'Content-Type': 'application/json',
              'X-Authorization': user.accessToken
  
          }
      });
      homePage();
  }
  const section = document.querySelector('#movie-example');

export function detailsPage(id) {
    showView(section);
    displayMovie(id);
}

async function displayMovie(id) {

    const user = JSON.parse(localStorage.getItem('user'));

    const [movie, likes, ownLike] = await Promise.all([
        getMovie(id),
        getLikes(id),
        getOwnLike(id, user)
    ]);

    section.replaceChildren(createMovieCard(movie, user, likes, ownLike));
}

function createMovieCard(movie, user, likes, ownLike) {
    const element = document.createElement('div');
    element.className = 'container';
    element.innerHTML = `
    <div class="row bg-light text-dark">
        <h1>Movie title: ${movie.title}</h1>
        <div class="col-md-8">
            <img class="img-thumbnail" src="${movie.img}" alt="Movie">
        </div>
        <div class="col-md-4 text-center">
            <h3 class="my-3 ">Movie Description</h3>
            <p>${movie.description}</p>
            ${createControls(movie, user, ownLike)}
            <span class="enrolled-span">Liked ${likes}</span>
        </div>
    </div>`;

    attachDeleteEvent(element, movie._id);
    attachEditEvent(element, movie._id);
    const likeBtn = element.querySelector('.like-btn');

    if (likeBtn) {
        likeBtn.addEventListener('click', (e) => likeMovie(e, movie._id));
    }

    return element;
}

function createControls(movie, user, ownLike) {
    const isOwner = user && user._id == movie._ownerId;

    let controls = [];

    if (isOwner) {
        controls.push('<a class="btn btn-danger delete-btn" href="#">Delete</a>');
        controls.push('<a class="btn btn-warning edit-btn" href="#">Edit</a>');
    } else if (user && ownLike == false) {
        controls.push('<a class="btn btn-primary like-btn" href="#">Like</a>');
    }
    controls.push();

    return controls.join('');
}

async function getMovie(id) {
    const res = await fetch(`http://localhost:3030/data/movies/${id}`);
    const movie = await res.json();

    return movie;
}

async function getLikes(id) {
    const res = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${id}%22&distinct=_ownerId&count`);
    const likes = await res.json();

    return likes;
}

async function getOwnLike(movieId, user) {
    if (!user) {
        return false;
    } else {
        const userId = user._id;
        const res = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${movieId}%22%20and%20_ownerId%3D%22${userId}%22`);
        const like = await res.json();

        return like.length > 0;
    }
}


async function likeMovie(event, movieId) {

    event.preventDefault();

    const user = JSON.parse(localStorage.getItem('user'));

    try {

        const response = await fetch(`http://localhost:3030/data/likes`, {

            method: 'POST',
            headers: {

                'Content-Type': 'application/json',
                'X-Authorization': user.accessToken
            },
            body: JSON.stringify({ movieId })
        });

        if (!response.ok) {

            const error = await response.json();
            throw new Error(error.message);
        }

        detailsPage(movieId);

    } catch (err) {

        alert(err.message);
        throw err;
    }
} 
const section = document.querySelector('#edit-movie');
const form = section.querySelector('.text-center');

export function attachEditEvent(element, id) {

    const editButton = element.querySelector('.edit-btn');
    editButton.addEventListener('click', onEdit.bind(null, id))

}

function editPage() {

    showView(section);
}

function onEdit(id, event) {

    event.preventDefault();
    editPage();
    form.addEventListener('submit', onSubmit.bind(null, id));

}

async function onSubmit(movieId, event) {

    event.preventDefault();
    
    const formData = new FormData(form);
    const user = JSON.parse(localStorage.getItem('user'));

    const movieTitle = formData.get('title');
    
    const movieDescription = formData.get('description');
    const movieUrl = formData.get('imageUrl');

    try {

        const response = await fetch(`http://localhost:3030/data/movies/${movieId}`, {

            method: 'PUT',
            headers: {

                'Content-Type': 'application/json',
                'X-Authorization': user.accessToken
            },

            body: JSON.stringify({title: movieTitle, description: movieDescription, img: movieUrl})

        });
         if(!response.ok) {

            const error = await response.json(); 
            throw new Error(error.message);
         }
        form.reset();   
        homePage();

    } catch (err) {

        alert(err.message);
        throw err;

  }

}
const section = document.querySelector('#home-page');
const catalog = section.querySelector('#movie .card-deck.d-flex.justify-content-center');
catalog.addEventListener('click', (event) => {
    if (event.target.tagName == 'BUTTON') {
        event.preventDefault();
        const id = event.target.dataset.id;
        detailsPage(id);
    }
});

export function homePage() {
    showView(section);
    displayMovies();
}

async function displayMovies() {
    catalog.replaceChildren(spinner());

    const movies = await getMovies();

    catalog.replaceChildren(...movies.map(createMoviePreview));
}

function createMoviePreview(movie) {
    const element = document.createElement('div');
    element.className = 'card mb-4';
    element.innerHTML = `
    <img class="card-img-top" src="${movie.img}"
        alt="Card image cap" width="400">
    <div class="card-body">
        <h4 class="card-title">${movie.title}</h4>
    </div>
    <div class="card-footer">
        <a href="/details/${movie._id}">
            <button data-id="${movie._id}" type="button" class="btn btn-info">Details</button>
        </a>
    </div>`;

    return element;
}

async function getMovies() {
    const res = await fetch('http://localhost:3030/data/movies');
    const data = await res.json();

    return data;
}
const section = document.querySelector('#form-login');
const form = section.querySelector('form');
form.addEventListener('submit', onSubmit);

export function loginPage() {

    showView(section);

}

async function onSubmit(event) {

    event.preventDefault();
    const formData = new FormData(form);

    const email = formData.get('email');
    const password = formData.get('password');

    await login(email, password);
    form.reset();
    updateNav();
    homePage();
}

async function login(email, password) {

    try{

        const response = await fetch('http://localhost:3030/users/login', {

            method: 'POST',
            headers: {

                'Content-Type': 'application/json'

            },
            body: JSON.stringify({email, password})
        });

        if(!response.ok) {

            const error = await response.json();
            throw new Error(error.message);

        }
        const data = await response.json();
        localStorage.setItem('user', JSON.stringify(data));

    }catch(err) {   

        alert(err.message);
        throw err;

    }

}
const section = document.querySelector('#form-sign-up');
const form = section.querySelector('form');
form.addEventListener('submit', onSubmit);

export function registerPage() {

    showView(section);

}

async function onSubmit(event) {

    event.preventDefault();

    const formData = new FormData(form);
    const email = formData.get('email');
    const password = formData.get('password');
    const repeatPassword = formData.get('repeatPassword');
    
    await register(email, password, repeatPassword);
    form.reset();
    loginPage();
    updateRegisterNav();
}

async function register(email, password, repeatPassword) {

    try {

        const response = await fetch('http://localhost:3030/users/register', {

        method: 'POST',
        headers: {

            'Content-Type': 'application/json'

        },
        body: JSON.stringify({email, password, repeatPassword})

    });

    if(!response.ok) {

        const error = await response.json();
        throw new Error(error.message);
    }

    const data = await response.json();
    localStorage.setItem('user', JSON.stringify(data));

    } catch(err) {

        alert(err.message);
        throw err;
    }
}
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
*/


