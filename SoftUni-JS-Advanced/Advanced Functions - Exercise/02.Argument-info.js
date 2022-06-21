function solve() {

    let obj = {};

    let input = Array.from(arguments);

    for (const argument of input) {
        
        console.log(`${typeof(argument)}: ${argument}`);

        if (!obj[typeof(argument)]) {
            obj[typeof(argument)] = 0;
        }
        obj[typeof(argument)]++;
    }

     let sortedObj = Object.keys(obj).sort((a, b) => obj[b] - obj[a])
     .forEach(x => console.log(`${x} = ${obj[x]}`));

     
};
solve('cat', 42, function () { console.log('Hello world!'); });