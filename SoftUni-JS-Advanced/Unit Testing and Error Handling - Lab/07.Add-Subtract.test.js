const {expect} = require('chai');
const AddSubtract = require('./07.Add-Subtract');

describe('Add Subtract Test', () => {

    it('return an object as a result of the function', () => {

        expect(typeof AddSubtract()).to.equal('object');

    })


    it('contains three functions add, subtract, get as properties', () => {
   
        const object = AddSubtract();

        expect(object).haveOwnProperty('add');
        expect(object).haveOwnProperty('subtract');
        expect(object).haveOwnProperty('get');

    }) 

    it('sums properly', () => {

        const object = AddSubtract();
        object.add(3);
        object.add(2);

        expect(object.get()).to.be.equal(5);
        object.add(5);
        expect(object.get()).to.be.equal(11);
    })

    it('subtracts properly', () => {

        const object = createCalculator();
        object.add(3);
        object.subtract(2);
        expect(object.get()).to.equal(1);
        object.subtract(10);
        expect(object.get()).to.equal(-9);

    })

    it('calculates properly if a string represantation of a number is given', () => {

        const object = createCalculator();
        object.add('1');
        expect(object.get()).to.equal(1);

    })

    it('returns NaN if not a number or not a string represantation of a number is given', () => {

        const object = createCalculator();
        object.add('blah');
        expect(Number.isNaN(object.get())).to.be.true;

    })
})