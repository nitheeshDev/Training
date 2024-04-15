/*name */

function name1() {
    var fieldInput = document.getElementById('fullname');
    var errorDiv = document.getElementById("error");
    var fieldValue = fieldInput.value.trim();

    if (fieldValue === "") {
        errorDiv.style.color = 'red';
        errorDiv.innerHTML = 'Please enter yourname';
        fieldInput.style.borderColor = 'red';
        fieldInput.style.backgroundColor = 'rgba(255, 0, 0, 0.1)';
    } else {
        errorDiv.innerHTML = "";
        fieldInput.style.borderColor = 'green';
        fieldInput.style.backgroundColor = 'rgba(81, 255, 145, 0.1)';
    }
}
/*email*/
function email1() {
    var fieldInput = document.getElementById('em');
    var errorDiv = document.getElementById("error1");
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

/*message */
function mess1() {
    var fieldInput = document.getElementById('mess');
    var errorDiv = document.getElementById("error2");
    var fieldValue = fieldInput.value.trim();

    if (fieldValue === "") {
        errorDiv.style.color = 'red';
        errorDiv.innerHTML = 'Please enter the message';
        fieldInput.style.borderColor = 'red';
        fieldInput.style.backgroundColor = 'rgba(255, 0, 0, 0.1)';
    } else {
        errorDiv.innerHTML = "";
        fieldInput.style.borderColor = 'green';
        fieldInput.style.backgroundColor = 'rgba(81, 255, 145, 0.1)';
    }
}

/*validate onsubmit method
 */
function validatecontact() {

    name1();
    email();
    message();

    if (
        document.getElementById("error").innerHTML !== "" ||
        document.getElementById("error1").innerHTML !== "" ||
        document.getElementById("error2").innerHTML !== "" 
       ) {
        return false;
    }


    return true;
}