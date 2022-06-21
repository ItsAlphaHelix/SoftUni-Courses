function solve(year, month, day) {
    let date = new Date(year, month + 1, day - 1);
    let previousYear = date.getFullYear();
    let previousMonth = date.getMonth() - 1;
    let previousDay = date.getDate();
    console.log(`${previousYear}-${previousMonth}-${previousDay}`);
   }
   solve(2016, 10, 1);