function solve(digits) {

let sum = 0;
numberLength = digits.toString();
let firstDigit = numberLength[0];
let result = true;

for (let i = 0; i < numberLength.length; i++) {   
    sum += Number(numberLength[i]);

    if (numberLength[i] != firstDigit) {
        result = false;
    }
}
console.log(result);
console.log(sum);
}