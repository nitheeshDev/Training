
/*  admin
fullname*/
function Fullname11() {
    var fieldInput = document.getElementById('fullname');
    var errorDiv = document.getElementById("error");
    var fieldValue = fieldInput.value.trim();
    var namePattern = /^[A-Za-z\s]+$/;

    if (fieldValue === "") {
        errorDiv.style.color = 'red';
        errorDiv.innerHTML = 'Please enter your Full Name.';
        fieldInput.style.borderColor = 'red';
        fieldInput.style.backgroundColor = 'rgba(255, 0, 0, 0.1)';
    } else if (!namePattern.test(fieldValue)) {
        errorDiv.style.color = 'red';
        errorDiv.innerHTML = 'Full Name can only contain letters and spaces.';
        fieldInput.style.borderColor = 'red';
        fieldInput.style.backgroundColor = 'rgba(255, 0, 0, 0.1)';
    } else {
        errorDiv.innerHTML = "";
        fieldInput.style.borderColor = 'green';
        fieldInput.style.backgroundColor = 'rgba(81, 255, 145, 0.1)';
    }
}

/*  admin
contact no*/
function number() {
    var fieldInput = document.getElementById('num');
    var errorDiv = document.getElementById("error7");
    var numericPattern = /^\d+$/;
    var fieldValue = fieldInput.value.trim();

    if (fieldValue === "") {
        errorDiv.style.color = 'red';
        errorDiv.innerHTML = 'Please enter your phone number';
        fieldInput.style.borderColor = 'red';
        fieldInput.style.backgroundColor = 'rgba(255, 0, 0, 0.1)';
    }
    else if (!numericPattern.test(fieldValue)) {
        errorDiv.style.color = 'red';
        errorDiv.innerHTML = 'Phone number can only contain numeric digits.';
        fieldInput.style.borderColor = 'red';
        fieldInput.style.backgroundColor = 'rgba(255, 0, 0, 0.1)';
    } else {
        errorDiv.innerHTML = "";
        fieldInput.style.borderColor = 'green';
        fieldInput.style.backgroundColor = 'rgba(81, 255, 145, 0.1)';
    }
}
/*  admin
email*/
function email() {
    var fieldInput = document.getElementById('em');
    var errorDiv = document.getElementById("error8");
    var fieldValue = fieldInput.value.trim();
    var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    if (fieldValue === "") {
        errorDiv.style.color = 'red';
        errorDiv.innerHTML = 'Please enter your email address.';
        fieldInput.style.borderColor = 'red';
        fieldInput.style.backgroundColor = 'rgba(255, 0, 0, 0.1)';
    } else if (!emailPattern.test(fieldValue)) {
        errorDiv.style.color = 'red';
        errorDiv.innerHTML = 'Please enter a valid email address.';
        fieldInput.style.borderColor = 'red';
        fieldInput.style.backgroundColor = 'rgba(255, 0, 0, 0.1)';
    } else {
        errorDiv.innerHTML = "";
        fieldInput.style.borderColor = 'green';
        fieldInput.style.backgroundColor = 'rgba(81, 255, 145, 0.1)';
    }
}
function password() {
    var fieldInput = document.getElementById('pass');
    var errorDiv = document.getElementById("error9");
    var fieldValue = fieldInput.value.trim();
    var passwordPattern = /^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$/;

    if (fieldValue === "") {
        errorDiv.style.color = 'red';
        errorDiv.innerHTML = 'Please enter your password.';
        fieldInput.style.borderColor = 'red';
        fieldInput.style.backgroundColor = 'rgba(255, 0, 0, 0.1)';
    } else if (!passwordPattern.test(fieldValue)) {
        errorDiv.style.color = 'red';
        errorDiv.innerHTML = 'Please enter valid password';
        fieldInput.style.borderColor = 'red';
        fieldInput.style.backgroundColor = 'rgba(255, 0, 0, 0.1)';
    } else {
        errorDiv.innerHTML = "";
        fieldInput.style.borderColor = 'green';
        fieldInput.style.backgroundColor = 'rgba(81, 255, 145, 0.1)';
    }
}
function cpassword() {
    var passwordInput = document.getElementById('pass');
    var confirmPasswordInput = document.getElementById('cpass');
    var errorDiv = document.getElementById("error10");
    var passwordValue = passwordInput.value.trim();
    var confirmPasswordValue = confirmPasswordInput.value.trim();

    if (confirmPasswordValue === "") {
        errorDiv.style.color = 'red';
        errorDiv.innerHTML = 'Please confirm your password.';
        confirmPasswordInput.style.borderColor = 'red';
        confirmPasswordInput.style.backgroundColor = 'rgba(255, 0, 0, 0.1)';
    } else if (confirmPasswordValue !== passwordValue) {
        errorDiv.style.color = 'red';
        errorDiv.innerHTML = 'Passwords do not match.';
        confirmPasswordInput.style.borderColor = 'red';
        confirmPasswordInput.style.backgroundColor = 'rgba(255, 0, 0, 0.1)';
    } else {
        errorDiv.innerHTML = "";
        confirmPasswordInput.style.borderColor = 'green';
        confirmPasswordInput.style.backgroundColor = 'rgba(81, 255, 145, 0.1)';
    }
}
function validateForm() {

    Fullname11();
    number();
    email();
    password();
    cpassword();

    if (
        document.getElementById("error").innerHTML !== "" ||
        document.getElementById("error7").innerHTML !== "" ||
        document.getElementById("error8").innerHTML !== "" ||
        document.getElementById("error9").innerHTML !== "" ||
        document.getElementById("error10").innerHTML !== "") {
        return false;
    }


    return true;
}
document.addEventListener('DOMContentLoaded', function () {
    var currentDate = new Date();
    var dateInput = document.getElementById('DOB');
    var formattedCurrentDate = currentDate.toISOString().slice(0, 10);
    dateInput.setAttribute('min', formattedCurrentDate);
});