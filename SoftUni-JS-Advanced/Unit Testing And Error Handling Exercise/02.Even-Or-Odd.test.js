const {expect} = require('chai');
const isOddOrEven = require('./02.Even-Or-Odd');

describe('Test Odd And Event Numbers' , () => {

    it('return undefined if parametar is not a string', () => {

        expect(isOddOrEven(3)).to.be.equal(undefined);
        expect(isOddOrEven({})).to.be.equal(undefined);
        expect(isOddOrEven(undefined)).to.be.equal(undefined);
        expect(isOddOrEven(null)).to.be.equal(undefined);
        expect(isOddOrEven([])).to.be.equal(undefined);
    });
    it('return even result if string length is even', () => {

        expect(isOddOrEven('Hi')).to.be.equal('even');

    });
    it ('return odd result if string length is odd', () => {

        expect(isOddOrEven('H')).to.be.equal('odd');

    });
});