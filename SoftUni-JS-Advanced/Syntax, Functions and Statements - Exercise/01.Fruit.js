function solve(typeOfFruit, gramsOfFruit, priceOfFruit) {
    let neededPrice = gramsOfFruit * priceOfFruit;

    console.log(`I need $${(neededPrice / 1000).toFixed(2)} to buy ${(gramsOfFruit / 1000).toFixed(2)} kilograms ${typeOfFruit}.`)
}