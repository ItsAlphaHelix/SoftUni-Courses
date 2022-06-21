function solve(array) {

    let output = [];
    let biggest = array[0];

    for (let i = 0; i < array.length; i++) {
        if(array[i] >= biggest) {
            output.push(array[i])
            biggest = array[i];
        }
    }
    return output;
}
solve([1,
    3,
    8,
    4,
    10,
    12,
    3,
    2,
    24]);