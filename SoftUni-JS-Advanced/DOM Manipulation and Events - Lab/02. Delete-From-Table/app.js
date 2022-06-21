function deleteByEmail() {
    
    let inputEmailElement = document.querySelector('input[name="email"]')
    let emailCellsElements = document.querySelectorAll('tr td:nth-of-type(2)')
    let resultElement = document.getElementById('result');

    let emailElements = Array.from(emailCellsElements);
    let targetElement = emailElements.find(x => x.textContent == inputEmailElement.value);
    
    if (targetElement) {
        targetElement.parentElement.remove();
        resultElement.textContent = "Deleted.";
    } else {
        resultElement.textContent = "Not found.";
    }
}