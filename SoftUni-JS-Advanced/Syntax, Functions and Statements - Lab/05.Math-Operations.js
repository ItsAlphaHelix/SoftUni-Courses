function solver(firstNumber, secondNumber, element) {
    let result;

    if(element == '*') {
        result = firstNumber * secondNumber;
    }   
    else if(element == '**') {
        result = firstNumber ** secondNumber;
    }
    else if(element == '+') {
        result = firstNumber + secondNumber;
    }
    else if(element == '/') {
        result = firstNumber / secondNumber;
    }
    else if(element == '-') {
        result = firstNumber - secondNumber;
    }
    else if(element == '%'){
        result = firstNumber % secondNumber;
    }

    console.log(result);
}