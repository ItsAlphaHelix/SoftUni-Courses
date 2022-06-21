function solve(input) {

    let products = [];
    for (const iterator of input) {
        let [town, product, price] = iterator.split(' | ');
        price = Number(price);

        if (products.filter(x => x.product == product).length > 0) {

            let obj = products.find(x => x.product == product);

            if (obj.price > price) {

                obj.price = price;
                obj.town = town;
            }

        } else {

            let obj = { product, town, price };
            products.push(obj);
        }
    }

    for (const product of products) {
        console.log(`${product.prod} -> ${product.price} (${product.town})`);
    }
};
solve(['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10']);