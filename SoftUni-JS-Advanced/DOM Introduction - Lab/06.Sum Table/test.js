function sumTable() {

    let priceElements = Array.from(document.querySelectorAll('body table tbody td')).splice(0, 6);
    let resultElement = document.getElementById('sum');
    let sum = 0;
    for (let i = 0; i < priceElements.length; i++) {
        if (i % 2 != 0) {

            sum += Number(priceElements[i].textContent);
        }
    }
    resultElement.textContent = sum;
}