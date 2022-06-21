function solve(input, typeOfSorting) {

    let arrayForSorting = input;

    if (typeOfSorting == 'asc') {

        arrayForSorting.sort((a, b) =>  a-b);

    } else {

        arrayForSorting.sort((a, b) => b-a);

    }
    return arrayForSorting;
};
solve([14, 7, 17, 6, 8], 'desc');
