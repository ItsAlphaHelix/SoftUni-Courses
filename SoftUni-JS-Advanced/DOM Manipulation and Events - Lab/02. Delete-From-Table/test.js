function deleteByEmail() {
    let inputEmailElement = document.querySelector('input[type="text"]');
    let tableElements = Array.from(document.querySelectorAll('tr td'));
    
    let targetElement = tableElements.find(x => x.textContent == inputEmailElement.value);
    let resultElement = document.getElementById('result');

    if (targetElement) {
        targetElement.parentElement.remove();
        resultElement.textContent = 'Deleted';
    } else {
        resultElement.textContent = 'Not found.';
    }
}