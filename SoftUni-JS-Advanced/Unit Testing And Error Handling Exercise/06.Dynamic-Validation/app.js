function validate() {
    
    
    document.getElementById('email').addEventListener('change', onChange);
    function onChange(event) {

        let pattern = /[\w+]+@[\w]+\.[\w]+/gm;

        if(pattern.test(event.target.value)) {

            event.target.classList.remove('error');

        } else {

            event.target.classList = 'error';
            
        }

    }
}