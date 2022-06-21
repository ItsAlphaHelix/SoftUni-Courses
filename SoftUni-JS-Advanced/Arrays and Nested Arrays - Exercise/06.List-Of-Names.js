function solve(array) {
    let sortedNames = array.sort((a, b) => a.localeCompare(b));
    let count = 1;

    for (const name of sortedNames) {
        console.log(`${count++}.${name}`);
    }
};
solve(["John", "Bob", "Christina", "Ema"]);