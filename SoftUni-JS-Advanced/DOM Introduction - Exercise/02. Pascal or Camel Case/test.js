function solve() {

    let inputTextElement = document.getElementById('text');
    let inputElementNamingConvention = document.getElementById('naming-convention');
    let resultElement = document.getElementById('result');

    let input = inputTextElement.value;
    let result = ' ';
    if (inputElementNamingConvention.value == 'Camel Case') {

        for (let i = 0; i < input.length; i++) {

            if (input[i] == ' ') {
                result += (input[i + 1].toUpperCase());
                i++;
            } else {
                result += input[i].toLowerCase();
            }
        }
    } else if (inputElementNamingConvention.value == 'Pascal Case') {

        result = input[0].toUpperCase();

        for (let i = 1; i < input.length; i++) {

            if (input[i] == ' ') {
                result += input[i + 1].toUpperCase();
                i++;
            } else {
                result += input[i].toLowerCase();
            }
        }
    } else {
        result = 'Error!'
    }
    resultElement.textContent = result;
}