function solve(str1, str2, str3) {

    let len1 = str1.length;
    let len2 = str2.length;
    let len3 = str3.length;
    
    let sumLength = len1 + len2 + len3;
    let averageLength = Math.floor(sumLength / 3); 
    console.log(sumLength);    
    console.log(averageLength);
    }