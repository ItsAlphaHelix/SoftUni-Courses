function solve(array) {
    let obj = {};
    
    for(let i = 0; i < array.length; i += 2) {
        let food = array[i];
        let calories = Number(array[i + 1]);

        obj[food] = calories;
    }
    return obj;
};
solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);