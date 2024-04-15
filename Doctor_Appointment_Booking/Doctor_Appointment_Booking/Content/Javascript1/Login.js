function validateUsername() {
    var usernameInput = document.getElementById('Username');
    var errorSpan = document.getElementById('error');
    

    if (usernameInput.value === '') {
        errorSpan.style.color = '#FF0000'; // Red color
        errorSpan.innerHTML = 'Please enter your email *';
        usernameInput.style.borderColor = '#FF0000';
        usernameInput.style.backgroundColor = 'rgba(255, 0, 0, 0.10)';
    } else {
        errorSpan.innerHTML = '';
        usernameInput.style.borderColor = '#00FF00'; // Green color
        usernameInput.style.backgroundColor = 'rgba(81, 255, 145, 0.10)';
    }
}


