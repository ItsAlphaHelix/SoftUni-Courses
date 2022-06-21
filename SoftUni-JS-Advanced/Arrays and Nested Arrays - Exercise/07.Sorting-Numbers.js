function solve(array) {
    let resultArray = [];

    array = array.sort((a, b) => a - b);

    while(array.length != 0) {
        resultArray.push(array.shift());
        resultArray.push(array.pop());
    }

    console.log(resultArray);
};
solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);