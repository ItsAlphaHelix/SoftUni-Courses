function colorize() {    

    let townElements = Array.from(document.querySelectorAll('body table tbody tr'))
    .splice(1)
    .forEach((x, i) => {
        if (i % 2 == 0) {
            x.style.background = 'teal'
        }
    });

}