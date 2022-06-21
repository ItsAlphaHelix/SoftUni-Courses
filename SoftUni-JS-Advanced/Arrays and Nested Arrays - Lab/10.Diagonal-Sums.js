function solve(array) {
    let primaryDiagonal = 0;
    let secondaryDiagonal = 0;

    let result = [];

    for (let i = 0; i < array.length; i++) {

        for (let j = 0; j < array.length; j++) {

            primaryDiagonal += array[i][j];
            i++
        }
        result.push(primaryDiagonal);
    }
    for (let i = 0; i < array.length; i++) {
        for (let j = array.length - 1; j >= 0; j--) {
            secondaryDiagonal += array[i][j];
            i++;
        }
        result.push(secondaryDiagonal);
    }
    console.log(result.join(' '));
}
solve([[3, 5, 17],
[-1, 7, 14],
[1, -8, 89]])