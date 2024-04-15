import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
//export class CounterComponent {
//  public currentCount = 0;

//  public incrementCounter() {
//    this.currentCount++;
//  }
//}

export class RegistrationFormComponent {
  registrationForm: FormGroup;

  constructor(private formBuilder: FormBuilder) {
    this.registrationForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(8)]],
      confirmPassword: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      address: [''],
      city: [''],
      state: [''],
      zipCode: ['']
    });
  }

  onSubmit() {
    if (this.registrationForm.valid) {
      // Handle form submission, e.g., send data to the server
      console.log(this.registrationForm.value);
    } else {
      // Form is invalid, show error messages
      // You can access form controls like this: this.registrationForm.get('controlName')
    }
  }
}
