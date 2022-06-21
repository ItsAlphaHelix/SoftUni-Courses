function subtract() {
    
    let firstNumberElement = document.getElementById('firstNumber');
    let secondNumberElement = document.getElementById('secondNumber');
    let resultElement = document.getElementById('result');

   return resultElement.textContent = Number(firstNumberElement.value) - Number(secondNumberElement.value);
}