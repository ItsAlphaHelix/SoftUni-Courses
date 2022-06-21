function solve(array) {

    let output = [];

    for (let i = 0; i < array.length; i++) {
        let command = array[i];

        if (command == 'add') {
            output.push(i + 1);
        } else if (command == 'remove') {
            output.pop();
        }
        
    }

    if(output.length == 0) {
        console.log('Empty');
    }

    console.log(output.join('\n'));
}
solve(['remove', 
'remove', 
'remove']);