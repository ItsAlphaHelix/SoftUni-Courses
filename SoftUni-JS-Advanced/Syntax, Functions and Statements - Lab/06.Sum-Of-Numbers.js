function solve(n, m) {
    let result = 0;

    let numberOne = parseInt(n);
    let numberTwo = parseInt(m);

    for(let i = numberOne; i <= numberTwo; i++) {
        result += i;
    }

    return result;
}
console.log(solve('1', '5'));