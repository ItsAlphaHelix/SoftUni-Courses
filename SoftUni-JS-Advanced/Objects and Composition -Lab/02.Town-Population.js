function solve(input) {

    let towns = [];

    for (const info of input) {
        let commandArgs = info.split(' <-> ');
        let town = commandArgs[0];
        let population = Number(commandArgs[1]);
        
    // let [town, populationText] = info.split(' <-> ');

        if(!towns[town]) {
            towns[town] = 0;
        }

        towns[town] += population;
    }
    
    //First way to print associative array
    // for (const town in towns) {
    //     console.log(`${town} : ${towns[town]}`);
    // }

    //Second way to print associative array
    // Object.keys(towns).forEach(x => {
    //     console.log(`${x} : ${towns[x]}`);
    // });

    //Third way to print associative array;
    let entries = Object.entries(towns);
    
    for (const kvp of entries) {
        console.log(`${kvp[0]} : ${kvp[1]}`);
    }
};
solve(['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000']);