import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { BackendService } from 'src/app/services/backend.service';
import { LogInModel } from 'src/app/models/auth/login.model';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  imageSOurce : string = "libe/src/app/components/authentication/login/images/background_picture.png"
  email : string = "";
  password : string = "";
  isFormEmpty : boolean = true;
  model : LogInModel = {
    password: this.password,
    email : this.email
  }

  formGroup = new FormGroup({
    emailValidator: new FormControl(this.email, [
      Validators.required,
      Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$'),
    ]),
    passwordValidator: new FormControl(this.password, [
      Validators.required,
      Validators.minLength(6)
    ])
  });

  constructor(private authService : AuthService) {

   }

  ngOnInit(): void {
  }

  login(){
    debugger;
    var response = this.authService.login(this.model).subscribe(response => {
      console.log(response.user);
      console.log(response.jwt);
    });
    debugger;
  }

  formOnChenge(){
    debugger;
    if(this.email != "" && this.password != ""){
      this.isFormEmpty = false;
    }
    else{
      this.isFormEmpty = true;
    }
  }

}
