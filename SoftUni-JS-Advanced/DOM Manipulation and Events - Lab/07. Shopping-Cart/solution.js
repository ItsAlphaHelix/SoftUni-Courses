function solve() {

   let productsSet = [];
   let prizes = [];
   const products = Array.from(document.getElementsByClassName('add-product'));

   for(let product of products) {

      product.addEventListener('click', addAndMessage);

   }

   document.getElementsByClassName('checkout')[0].addEventListener('click', checkoutMessage);

   function checkoutMessage() {

      document.getElementsByTagName('textarea')[0].textContent += `You bought ${productsSet.join(', ')} for ${prizes.reduce((a, b) => a + b, 0).toFixed(2)}.`;
      Array.from(document.getElementsByTagName('button')).forEach(x => x.disabled = true);
      
   }

   function addAndMessage(ev) {

       let prize = Number(ev.target.parentNode.parentNode.children[3].textContent);
       let product = ev.target.parentNode.parentNode.children[1].children[0].textContent;
       let string = `Added ${product} for ${prize.toFixed(2)} to the cart.\n`;
       document.getElementsByTagName('textarea')[0].disabled = false;
       document.getElementsByTagName('textarea')[0].textContent += string;
       productsSet.push(product);
       prizes.push(prize);
   }
}