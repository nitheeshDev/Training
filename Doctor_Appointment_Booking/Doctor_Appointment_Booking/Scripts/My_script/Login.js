
//validate email
function validateEmail(email) {
    var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailPattern.test(email);
}
    function validateUsername() {
        var usernameInput = document.getElementById('Username');
        var errorSpan = document.getElementById('error');


        if (usernameInput.value === '') {
            errorSpan.style.color = '#FF0000'; 
            errorSpan.innerHTML = 'Please enter your email *';
            usernameInput.style.borderColor = '#FF0000';
            usernameInput.style.backgroundColor = 'rgba(255, 0, 0, 0.10)';
            
            
        }
        else if (!validateEmail(usernameInput.value)) {
            errorSpan.style.color = '#FF0000';
            errorSpan.innerHTML = 'Please enter a valid email address *';
            usernameInput.style.borderColor = '#FF0000';
            usernameInput.style.backgroundColor = 'rgba(255, 0, 0, 0.10)';
           
        }
        else {
            errorSpan.innerHTML = '';
            usernameInput.style.borderColor = '#00FF00'; 
            usernameInput.style.backgroundColor = 'rgba(81, 255, 145, 0.10)';
           
        }
}
function password1(pass) {
    var passwordPattern = /^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;
    return passwordPattern.test(pass);
}
//validate password
function validate() {
    var passwordInput = document.getElementById('Password');
        var errorSpan = document.getElementById('error1');
        var password = passwordInput.value;
        var passwordPattern = /^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;

        if (password === '') {
            errorSpan.style.color = '#FF0000'; 
            errorSpan.innerHTML = 'Please enter your Password *';
            passwordInput.style.borderColor = '#FF0000';
            passwordInput.style.backgroundColor = 'rgba(255, 0, 0, 0.10)';
            return false;
        } else if (!password1(password)) {
            errorSpan.style.color = '#FF0000'; 
            errorSpan.innerHTML = 'Password valid password *';
            passwordInput.style.borderColor = '#FF0000';
            passwordInput.style.backgroundColor = 'rgba(255, 0, 0, 0.10)';
            return false;
        }
        else {
            errorSpan.innerHTML = '';
            passwordInput.style.borderColor = '#00FF00';
            passwordInput.style.backgroundColor = 'rgba(81, 255, 145, 0.10)';
            return true;
        }
    }
    //validate onsubmitt
function validateForm() {

    validateUsername();
    validatepassword();
    if (
        document.getElementById("error").innerHTML !== "" ||
        document.getElementById("error1").innerHTML !== "")
    {
        return false;
    }


    return true;
}

