function calc() {
   
    let firstNumberElement = document.getElementById('num1');
    let secondNumberElement = document.getElementById('num2');
    let resultElement = document.getElementById('sum');

    resultElement.value = Number(firstNumberElement.value) + Number(secondNumberElement.value);
}
