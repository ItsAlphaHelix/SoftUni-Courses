function extractText() {
    
    let itemElements = document.getElementById('items');
    let resultElement = document.getElementById('result');

    resultElement.textContent = itemElements.textContent;
    
};  