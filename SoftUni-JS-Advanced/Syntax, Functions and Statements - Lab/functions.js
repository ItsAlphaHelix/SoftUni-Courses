//Function declaration
function printFullName(firstName, lastName) {
console.log(firstName + ' ' + lastName);
}

//Function invokation
printFullName('Dimityr', 'Georgiev');

//Function expression
let countDown = function(number){
  for(let i = number; i > 0; i--){
      console.log(i);
  }
};

countDown(10);

//Arror expression
let countUp = (max) => {
    for (let i = 0; i < max; i++) {;
        console.log(i);
    }
};

countUp(10);

//Return value
function sum(a, b){
    return a + b;
}
console.log(sum(10, 10));

//First way for arror expression
let totalSum = (a, b) => {
    return a + b;
};

console.log(totalSum(2, 2));

//Second way for arror expression
let calculateSum = (a, b) => a + b;

console.log(calculateSum(10, 15));