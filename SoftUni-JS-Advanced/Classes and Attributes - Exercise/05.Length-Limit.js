class Stringer {

    constructor(innerString, innerLength) {

        this.initialString = innerString;
        this.innerString = innerString;
        this.innerLength = innerLength;

    }
    decrease(length) {

        this.innerLength -= length;
        this.innerString = this.innerString.slice(0, this.innerLength);
        this.innerString += '...';

        if (this.innerLength <= 0) {
            this.innerLength = 0;
            
            return  this.innerString = '...';
        }
    }
    increase(length) {

        this.innerLength += length;
        this.innerString = '';
        for(let i = 0; i < this.innerLength; i++) {
            
            this.innerString += this.initialString[i];

        }
    }
    toString() {

        return this.innerString;

    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4); 
console.log(test.toString()); // Test