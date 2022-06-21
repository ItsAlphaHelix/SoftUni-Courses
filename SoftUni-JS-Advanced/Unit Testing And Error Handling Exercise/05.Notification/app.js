function notify(message) {
  
  let notification = document.getElementById('notification');
  notification.innerText = message;
  notification.style.display = 'block'

  notification.addEventListener('click', onClick);

  function onClick(event) {

    event.target.style.display = 'none';

  }
}