function addItem() {
    let inputElement = document.getElementById('newItemText');
    let itemElement = document.getElementById('items');

    let liElement = document.createElement('li');

    liElement.textContent = inputElement.value;
    itemElement.appendChild(liElement);
};