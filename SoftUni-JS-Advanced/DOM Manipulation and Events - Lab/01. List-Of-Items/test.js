function addItem() {
    
    let inputTextElement = document.getElementById('newItemText');
    let itemElement = document.getElementById('items');

    let liElement = document.createElement('li');
    liElement.textContent = inputTextElement.value;
    itemElement.appendChild(liElement);
};