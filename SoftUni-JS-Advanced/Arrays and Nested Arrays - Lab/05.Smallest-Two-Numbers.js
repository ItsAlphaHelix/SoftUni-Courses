function solve(array) {
    array.sort((a, b) => a - b);
    let smallestNumbers = array.slice(0, 2);
    console.log(smallestNumbers.join(' '));
}
solve([3, 0, 10, 4, 7, 3]);