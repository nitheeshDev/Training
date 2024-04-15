/*full name */
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
/*
doctorid
*/
function doctorid1() {
    var fieldInput = document.getElementById('doc');
    var errorDiv = document.getElementById("error11");
    var fieldValue = fieldInput.value.trim();

    if (fieldValue === "") {
        errorDiv.style.color = 'red';
        errorDiv.innerHTML = 'Please enter doctorID *';
        fieldInput.style.borderColor = 'red';
        fieldInput.style.backgroundColor = 'rgba(255, 0, 0, 0.1)';
    } else {
        errorDiv.innerHTML = "";
        fieldInput.style.borderColor = 'green';
        fieldInput.style.backgroundColor = 'rgba(81, 255, 145, 0.1)';
    }
}
//doctor specilization
function doctor() {
    var fieldInput = document.getElementById('doc1');
    var errorDiv = document.getElementById("error12");
    var fieldValue = fieldInput.value.trim();

    if (fieldValue === "") {
        errorDiv.style.color = 'red';
        errorDiv.innerHTML = 'Please enter Doctor specilization';
        fieldInput.style.borderColor = 'red';
        fieldInput.style.backgroundColor = 'rgba(255, 0, 0, 0.1)';
    } else {
        errorDiv.innerHTML = "";
        fieldInput.style.borderColor = 'green';
        fieldInput.style.backgroundColor = 'rgba(81, 255, 145, 0.1)';
    }
}

//gender
function Gender1() {
    var fieldInput = document.getElementById('Gender');
    var errorDiv = document.getElementById("error1");
    var fieldValue = fieldInput.value.trim();

    if (fieldValue === "") {
        errorDiv.style.color = 'red';
        errorDiv.innerHTML = 'Please enter Gender *';
        fieldInput.style.borderColor = 'red';
        fieldInput.style.backgroundColor = 'rgba(255, 0, 0, 0.1)';
    } else {
        errorDiv.innerHTML = "";
        fieldInput.style.borderColor = 'green';
        fieldInput.style.backgroundColor = 'rgba(81, 255, 145, 0.1)';
    }
}

//date of birth
function Dateofbirth() {
    var fieldInput = document.getElementById('DOB');
    var errorDiv = document.getElementById("error2");
   /* var ageDisplay = document.getElementById("ageDisplay");*/
    var fieldValue = fieldInput.value.trim();

    if (fieldValue === "") {
        errorDiv.style.color = 'red';
        errorDiv.innerHTML = 'Please enter your date of birth.';
        fieldInput.style.borderColor = 'red';
        fieldInput.style.backgroundColor = 'rgba(255, 0, 0, 0.1)';
    } else {
        errorDiv.innerHTML = "";
        fieldInput.style.borderColor = 'green';
        fieldInput.style.backgroundColor = 'rgba(81, 255, 145, 0.1)';
    } 
    document.getElementById('DOB').addEventListener('blur', Dateofbirth);
}
document.getElementById('DOB').addEventListener('blur', Dateofbirth);

//address
function address() {
    var fieldInput = document.getElementById('add');
    var errorDiv = document.getElementById("error6");
    var fieldValue = fieldInput.value.trim();

    if (fieldValue === "") {
        errorDiv.style.color = 'red';
        errorDiv.innerHTML = 'Please enter your address *';
        fieldInput.style.borderColor = 'red';
        fieldInput.style.backgroundColor = 'rgba(255, 0, 0, 0.1)';
    } else {
        errorDiv.innerHTML = "";
        fieldInput.style.borderColor = 'green';
        fieldInput.style.backgroundColor = 'rgba(81, 255, 145, 0.1)';
    }
}
//number
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

//email
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
//password
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
        errorDiv.innerHTML = 'Enter valid password';
        fieldInput.style.borderColor = 'red';
        fieldInput.style.backgroundColor = 'rgba(255, 0, 0, 0.1)';
    } else {
        errorDiv.innerHTML = "";
        fieldInput.style.borderColor = 'green';
        fieldInput.style.backgroundColor = 'rgba(81, 255, 145, 0.1)';
    }
}
//cpassword
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



//validate onsubmit method

function validateDoctor() {

    Fullname11();
    doctorid1();
    doctor();
    Gender1();
    Dateofbirth();
    address();
    number();
    email();
    password();
    cpassword();

    if (
        document.getElementById("error").innerHTML !== "" ||
        document.getElementById("error11").innerHTML !== "" ||
        document.getElementById("error12").innerHTML !== "" ||
        document.getElementById("error1").innerHTML !== "" ||
        document.getElementById("error2").innerHTML !== "" ||
        document.getElementById("error6").innerHTML !== "" ||
        document.getElementById("error7").innerHTML !== "" ||
        document.getElementById("error8").innerHTML !== "" ||
        document.getElementById("error9").innerHTML !== "" ||
        document.getElementById("error10").innerHTML !== "") {
        return false;
    }


    return true;
}

//hide future date
document.addEventListener('DOMContentLoaded', function () {
    var currentDate = new Date();
    var dateInput = document.getElementById('DOB');
    var formattedCurrentDate = currentDate.toISOString().slice(0, 10);
    dateInput.setAttribute('max', formattedCurrentDate);
});