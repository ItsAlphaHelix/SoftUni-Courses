function solve(elements) {
    let result = 0;

    for(let i = 0; i < elements.length; i++) {
        result += elements[i];
        print(i);
    }
    result = 0;

    for(let i = 0; i < elements.length; i++) {
        result += 1 / elements[i]
        print(i);
    }

    console.log(elements.join(''));
      

    function print(i) {
        if (i == elements.length - 1) {
            console.log(result);
        }
    }
}