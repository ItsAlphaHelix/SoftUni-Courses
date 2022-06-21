const lookupChar = require('./03.Char-Lookup');
const {expect} = require('chai');

describe('Look Up Char Test', () => {

    it('return char at index', () => {

        expect(lookupChar('Hello', 0)).to.be.equal('H');

    });

    it('return char at index', () => {

        expect(lookupChar('Hello', 1)).to.be.equal('e');

    });

    it('return message is string length is smaller than index', () => {

        expect(lookupChar('Hello', 10)).to.be.equal('Incorrect index');

    });

    it('return message if index is negative', () => {

        expect(lookupChar('Hello', -10)).to.be.equal('Incorrect index');

    });

    it('return undefined if first parametar is not a string', () => {

        expect(lookupChar(20, 5)).to.be.equal(undefined);

    });

    it('return undefined if first parametar is an array', () => {

        expect(lookupChar([], 5)).to.be.equal(undefined);

    });

    it('return undefined if first parametar is an object', () => {

        expect(lookupChar([], 5)).to.be.equal(undefined);

    });

    it('return undefined if second parametar is a string', () => {

        expect(lookupChar('hello', 'string')).to.be.equal(undefined);

    });

    it('return undefined if second parametar is a decimal number', () => {

        expect(lookupChar('hello', 5.5)).to.be.equal(undefined);

    });

    it('return undefined if second parametar is an object', () => {

        expect(lookupChar('hello', {})).to.be.equal(undefined);

    });

    it('return undefined if second parametar is an array', () => {

        expect(lookupChar('hello', [])).to.be.equal(undefined);

    });
});
