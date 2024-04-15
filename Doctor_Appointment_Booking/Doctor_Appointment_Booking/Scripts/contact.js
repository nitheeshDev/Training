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
function Gender1() {
    var fieldInput = document.getElementById('Gender');
    var errorDiv = document.getElementById("error1");
    var fieldValue = fieldInput.value.trim();

    if (fieldValue === "") {
        errorDiv.style.color = 'red';
        errorDiv.innerHTML = 'Please enter  *';
        fieldInput.style.borderColor = 'red';
        fieldInput.style.backgroundColor = 'rgba(255, 0, 0, 0.1)';
    } else {
        errorDiv.innerHTML = "";
        fieldInput.style.borderColor = 'green';
        fieldInput.style.backgroundColor = 'rgba(81, 255, 145, 0.1)';
    }
}
function validatecontact() {

    name1();
    email();
    message();
  
    if (
        document.getElementById("error").innerHTML !== "" ||
        document.getElementById("error11").innerHTML !== "" ||
        document.getElementById("error12").innerHTML !== "" ||
       ) {
        return false;
    }


    return true;
}