function solve(n) {
const star = '* '
if (n == null || n == ' ' || n == 0) {
    for (let i = 0; i < 5; i++) {
        console.log(`${(star.repeat(5))}`);
    }
} else {
    for (let i = 0; i < n; i++) {
        console.log(`${(star.repeat(n))}`);
    }
}
};
