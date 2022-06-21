function create(input) {
    
    let contentElement = document.getElementById('content');
    let elements = input;

    for (let i = 0; i < elements.length; i++);
    {

        let divElement = document.createElement('div');
        let pElement = document.createElement('p');
        let text = document.createTextNode(elements[i]);
        
        pElement.appendChild(text);
        pElement.style.display = 'none';
        divElement.appendChild(pElement)

        div.addEventListener('click', showParagraphs);   

        contentElement.appendChild(divElement);
    }
    
    function showParagraphs(e) {
        e.target.children[0].style.display = 'block';
     }
 };