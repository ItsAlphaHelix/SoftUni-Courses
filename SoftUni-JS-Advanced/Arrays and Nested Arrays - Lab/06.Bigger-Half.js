function solve(array) {
    let sorted = array.sort((a, b) => a- b);
    let evenOrOdd = Math.floor(array.length / 2);

    let result = sorted.slice(evenOrOdd)

    return result;
}
solve([3, 19, 14, 7, 2, 19, 6])