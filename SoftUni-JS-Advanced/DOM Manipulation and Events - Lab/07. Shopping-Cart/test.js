function solve() {

    let productsSet = [];
    let prises = [];

    let buttonElement = Array.from(document.getElementsByClassName('add-product'));

    for (let button of buttonElement) {
        button.addEventListener('click', add);

    }
    
    document.getElementsByClassName('checkout')[0].addEventListener('click', checkoutMessage);

    function checkoutMessage() {

        document.getElementsByTagName('textarea')[0].textContent += `You bought ${productsSet.join(', ')} for ${prises.reduce((a, b) => a + b, 0).toFixed(2)}.`;
        Array.from(document.getElementsByTagName('button')).forEach(x => x.disabled = true);
        
     }

    function add(ev) {
        console.log(ev);
        let prise = Number(ev.target.parentNode.parentNode.children[3].textContent);
        let product = ev.target.parentNode.parentNode.children[1].children[0].textContent;

        document.getElementsByTagName('textarea')[0].disabled = false;
        document.getElementsByTagName('textarea')[0].textContent += `Added ${product} for ${prise} to the cart.\n`;

        productsSet.push(product);
        prises.push(prise);
    }
}