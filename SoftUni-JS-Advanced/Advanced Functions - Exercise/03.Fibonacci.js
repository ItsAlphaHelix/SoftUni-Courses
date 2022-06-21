function getFibonator() {

    let firstNumber = 1;
    let secondNumber = 0;

    return () =>  {
        
        let nextSum = firstNumber;
        firstNumber = firstNumber + secondNumber;
        secondNumber = nextSum;

        

        return secondNumber;
    }

};
let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13