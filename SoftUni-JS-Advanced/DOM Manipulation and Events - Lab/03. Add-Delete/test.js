function addItem() {
    
    let inputElement = document.getElementById('newItemText');
    let itemElement = document.getElementById('items');

    let liElement = document.createElement('li');

    liElement.textContent = inputElement.value;

    let deleteElement = document.createElement('a'); 
    deleteElement.href = '#';
    deleteElement.textContent = '[Delete]';

    deleteElement.addEventListener('click', (e) => {
        e.currentTarget.parentElement.remove();
    });

    liElement.appendChild(deleteElement);
    itemElement.appendChild(liElement);
}