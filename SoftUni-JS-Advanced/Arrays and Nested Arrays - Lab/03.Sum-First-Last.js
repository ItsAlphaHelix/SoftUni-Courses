function solve(array) {
    let result = 0;

    let firstNumber = Number(array.shift());
    let lastNumber = Number(array.pop());

    result = firstNumber + lastNumber;
    console.log(result);
}
solve(['20', '30', '40'])