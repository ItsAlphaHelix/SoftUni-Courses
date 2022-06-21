function solve(input) {
    let output = input;
    output = input.replace(/\W+/g, ' ').trim();
    output = output.replace(/\s+/g, ', ');  
    output = output.toUpperCase();
    console.log(output);
}
solve('Hi, how are you?');
solve('Functions in JS can be nested, i.e. hold other functions');