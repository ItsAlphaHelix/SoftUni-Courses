function solve(inputType) {
    let result;

    if(typeof(inputType) !== 'number') {
         console.log(`We can not calculate the circle area, because we receive a ${typeof(inputType)}.`);
    }
    else {
        result = Math.pow(inputType, 2) * Math.PI;
        console.log(result.toFixed(2));
    }
}