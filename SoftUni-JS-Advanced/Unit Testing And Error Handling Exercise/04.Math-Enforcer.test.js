const mathEnforcer = require('./04.Math-Enforcer.js');
const { expect } = require('chai');

describe('Math Enforcer Tests', () => {

    describe('Add Five Tests', () => {

        //incorrect tests
        it('return undefined when type of parameter is null', () => {

            expect(mathEnforcer.addFive(null)).to.be.equal(undefined);

        });

        it('return undefined when type of parameter is undefined', () => {

            expect(mathEnforcer.addFive(undefined)).to.be.equal(undefined);

        });

        it('return undefined when type of parameter is string', () => {

            expect(mathEnforcer.addFive('number')).to.be.equal(undefined);

        });

        it('return undefined when type of parameter is array', () => {

            expect(mathEnforcer.addFive([])).to.be.equal(undefined);

        });

        it('return undefined when type of parameter is object', () => {

            expect(mathEnforcer.addFive({})).to.be.equal(undefined);

        });

        //correct tests
        it('return sum between two integers', () => {

            expect(mathEnforcer.addFive(2)).to.be.equal(7);

        });

        it('return sum between decimal and integer', () => {

            expect(mathEnforcer.addFive(10.5)).to.be.equal(15.5);

        });

        it('return sum between negative number and integer', () => {

            expect(mathEnforcer.addFive(-1)).to.be.equal(4);

        });
    });

    describe('Subtract Ten Tests', () => {

        //incorrect tests

        it('return undefined when type of subtract parameter is null', () => {

            expect(mathEnforcer.subtractTen(null)).to.be.equal(undefined);

        });


        it('return undefined when type of subtract parameter is undefined', () => {

            expect(mathEnforcer.subtractTen(undefined)).to.be.equal(undefined);

        });

        it('return undefined when type of parameter is string', () => {

            expect(mathEnforcer.subtractTen('number')).to.be.equal(undefined);

        });

        it('return undefined when type of parameter is array', () => {

            expect(mathEnforcer.subtractTen([])).to.be.equal(undefined);

        });

        it('return undefined when type of parameter is object', () => {

            expect(mathEnforcer.subtractTen({})).to.be.equal(undefined);

        });

        //correct tests

        it('return undefined when type of first parameter is undefined', () => {

            expect(mathEnforcer.sum(undefined)).to.be.equal(undefined);

        });

        it('return subtract between two integers', () => {

            expect(mathEnforcer.subtractTen(10)).to.be.equal(0);

        });

        it('return subtract between decimal and integer', () => {

            expect(mathEnforcer.subtractTen(20.5)).to.be.equal(10.5);

        });

        it('return subtract between negative number and integer', () => {

            expect(mathEnforcer.subtractTen(-5)).to.be.equal(-15);

        });

    });

    describe('Sum Tests', () => {

        it('return sum between two integers', () => {

            expect(mathEnforcer.sum(5, 5)).to.be.equal(10);

        });

        it('return sum between two decimal points', () => {

            expect(mathEnforcer.sum(2.5, 2.5)).to.be.equal(5);

        });

        it('return sum with negative numbers', () => {

            expect(mathEnforcer.sum(-10, -2.5)).to.be.equal(-12.5);

        });

        it('return undefined when first parameter is empty string', () => {

            expect(mathEnforcer.sum('', 2.5)).to.be.equal(undefined);

        })
        it('return undefined when first parameter is number, but second is string', () => {

            expect(mathEnforcer.sum(21, '20')).to.be.equal(undefined);

        })
    });

});