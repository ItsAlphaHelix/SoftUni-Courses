function juiceFlavors(input) {

    let dictionary = new Map();
    let result = new Map();

    input.forEach(x => {

        let [juice, quantity] = x.split(' => ');
        quantity = Number(quantity);
        
        if(!dictionary.has(juice)) {

            dictionary.set(juice, 0);

        }

        dictionary.set(juice, dictionary.get(juice) + quantity);

        while(dictionary.get(juice) >= 1000) {

            dictionary.set(juice, dictionary.get(juice) - 1000);
            result.set(juice, (result.get(juice) || 0) + 1);
        }
    });
   
    for (const [key, value] of result) {
        
        console.log(`${key} => ${value}`);

    }
}
juiceFlavors(['Orange => 2000',
            'Peach => 1432',
            'Banana => 450',
            'Peach => 600',
            'Strawberry => 549']);