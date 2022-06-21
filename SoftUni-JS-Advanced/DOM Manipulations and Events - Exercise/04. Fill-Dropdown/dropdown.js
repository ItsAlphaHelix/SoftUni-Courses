function addItem() {
    
    let inputTextElement = document.getElementById('newItemText');
    let inputValueElement = document.getElementById('newItemValue');
    let menuElement = document.getElementById('menu');

    let optionElement = document.createElement('option')

    optionElement.textContent = inputTextElement.value;
    optionElement.value = inputValueElement.value;

    menuElement.appendChild(optionElement);
    
    inputTextElement.value = '';
    inputValueElement.value = '';
}