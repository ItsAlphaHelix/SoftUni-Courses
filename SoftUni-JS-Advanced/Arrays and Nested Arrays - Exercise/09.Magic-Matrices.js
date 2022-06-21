function solve(array) {

    let firstRow = 0;
    let secondRow = 0;
    let thirdRow = 0;

    let firstCol = 0;
    let secondCol = 0;
    let thirdCol = 0;

    let isEqual = false;

    for (let row = 0; row < array.length; row++) {

        for (let col = 0; col < array[row].length; col++) { 


            firstRow += array[row][col];
            firstCol += array[col][row];

            // if(row == 0) {
            //     firstRow += array[row][col];
            //     firstCol += array[col][row];
            // } 
            // if (row == 1) {
            //     secondRow += array[row][col];
            //     secondCol += array[col][row];
            // }
            // if (row == 2) {
            //     thirdRow += array[row][col];
            //     thirdCol += array[col][row];
            // }
            
        }

        if (firstRow == firstCol) {

            isEqual = true;
        }

        firstRow = 0;
    firstCol = 0;
    }


    console.log(isEqual);
    // if (firstRow == secondRow && secondRow == thirdRow && firstRow == thirdRow
    //     && firstCol == secondCol && secondCol == thirdCol && firstCol == thirdCol
    //     && firstRow == secondCol && secondRow == thirdCol && firstRow == thirdCol){
    //     console.log('true');
    // } else {
    //     console.log('false');
    // }
};
solve([[1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]);