function solve(array) {
    let result = Number.NEGATIVE_INFINITY;
    for (let i = 0; i < array.length; i++) {
    
        for (j = 0; j < array[i].length; j++) {

            let currentBiggestNumber = array[i][j];

            if (currentBiggestNumber > result) {

                result = currentBiggestNumber;
            }
        }
    }
    console.log(result);
}
solve([[3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4]]
   )