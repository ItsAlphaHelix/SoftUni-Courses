function calc() {
   
    let numberOneId = document.getElementById('num1');
    let numberTwoId = document.getElementById('num2');

    let firstNumber = Number(numberOneId.value);
    let secondNUmber = Number(numberTwoId.value);

    let sum = firstNumber + secondNUmber;

    let resultElement = document.getElementById('sum');

    resultElement.value = sum;
}
