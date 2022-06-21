function solve(array, steps) {
    let output = [];

    for(let i = 0; i < array.length; i += steps) {
        output.push(array[i]);
    }
    return output;
};
solve(['5', 
    '20', 
    '31', 
    '4', 
    '20'], 
    2);