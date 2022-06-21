function solve() {

  let inputElement = document.getElementById('input');
  let textArr = inputElement.value.split('.').filter(s => s !== '');
  let resultDiv = document.getElementById('output');

  console.log(textArr);
  while (textArr.length > 0) {

    text = textArr.splice(0, 3).join('. ') + '.';
    let p = document.createElement('p');
    p.textContent = text;
    resultDiv.appendChild(p);

  }
}