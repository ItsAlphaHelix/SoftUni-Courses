function subtract() {
    let firstNumberElement = document.getElementById('firstNumber');
    let secondNumberElement = document.getElementById('secondNumber');

    let firstNumberAsNumber = Number(firstNumberElement.value);
    let secondNumberAsNumber = Number(secondNumberElement.value);

    let sum = firstNumberAsNumber - secondNumberAsNumber;
    let resultElement = document.getElementById('result');
    resultElement.textContent = sum;
}