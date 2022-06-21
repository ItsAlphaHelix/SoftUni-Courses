function attachEvents() {

    const postCommentElement = document.getElementById('post-comments');
    const postBodyElement = document.getElementById('post-body');
    const postTitleElement = document.getElementById('post-title');
    const posts = document.getElementById('posts');
    const loadButton = document.getElementById('btnLoadPosts');
    const viewButton = document.getElementById('btnViewPost');

    loadButton.addEventListener('click', load);
    viewButton.addEventListener('click', view);

    const postUrl = 'http://localhost:3030/jsonstore/blog/posts';
    const commentUrl = 'http://localhost:3030/jsonstore/blog/comments';

    async function view() {

        postCommentElement.innerHTML = '';

        const postRespones = await fetch(postUrl);
        const postData = await postRespones.json();

        postTitleElement.innerText = postData[posts.value].title;
        postBodyElement.innerText = postData[posts.value].body;

        const commentRespones = await fetch(commentUrl);
        const commentData = await commentRespones.json();

        Object.values(commentData).forEach(info => {

            if (info.postId == posts.value) {

                const liElement = document.createElement('li');
                liElement.id = info.postId;
                liElement.innerText = info.text;

                postCommentElement.appendChild(liElement);
            }
        });     
    }
    
    async function load() {

        const postResponse = await fetch(postUrl);
        const dataResponse = await postResponse.json();

        posts.innerHTML = '';

        for (const key in dataResponse) {

            const option = document.createElement('option');
            option.setAttribute('value', key);
            const title = dataResponse[key].title.toUpperCase();
            option.innerText = title;

            posts.appendChild(option);
        }
    }
}

attachEvents();