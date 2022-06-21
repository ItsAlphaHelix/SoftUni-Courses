function solve() {
    document.querySelector('#searchBtn').addEventListener('click', onClick);
    

    function onClick() {
        let searchBoxElement = document.getElementById('searchField');
        let rowElements = Array.from(document.querySelectorAll('tbody tr'))
        .forEach(x => {
            x.classList.remove('select');
            if (searchBoxElement.value !== '' && x.innerHTML.includes(searchBoxElement.value)) {
                x.className = 'select';
            }
        });

        searchBoxElement.value = '';
    }
}