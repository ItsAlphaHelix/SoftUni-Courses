function solve(firstNumber, secondNumber, thirdNumber) {
    let result;

    if(firstNumber > secondNumber && firstNumber && firstNumber > thirdNumber) {
            result = firstNumber;
    }
    else if(secondNumber > firstNumber && secondNumber > thirdNumber) {
            result = secondNumber;
    }
    else if(thirdNumber > firstNumber && thirdNumber > secondNumber) {
            result = thirdNumber;
    }
    
    console.log(`The largest number is ${result}.`);
}