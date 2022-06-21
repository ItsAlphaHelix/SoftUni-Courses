function search() {
   
    let searchBoxElement = document.getElementById('searchText')
    let matches = 0;
    let townsELement = Array.from(document.querySelectorAll('#towns li'))
    .forEach(x => {
        
        if (x.textContent.includes(searchBoxElement.value)) {
            matches++;
            x.style.fontWeight = 'bold';
            x.style.textDecoration = 'underline'
        } else {
            x.style.fontWeight = 'normal';
            x.style.textDecoration = 'none'
        }
        
    });
    let resultElement = document.getElementById('result');
    resultElement.textContent = `${matches} matches found`
    searchBoxElement.value = '';
 }