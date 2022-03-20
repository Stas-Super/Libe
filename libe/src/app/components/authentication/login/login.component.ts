import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { BackendService } from 'src/app/services/backend.service';
import { LogInModel } from 'src/app/models/auth/login.model';
import { Router } from '@angular/router';
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
  constructor(private authService : AuthService) {

   }

  ngOnInit(): void {
  }

  login(){
    var response = this.authService.login(this.model).subscribe(response => {
      console.log(response.user);
      console.log(response.jwt);
    });
  }

  formOnChenge(){
    if(this.email != "" && this.password != ""){
      this.isFormEmpty = false;
    }
    else{
      this.isFormEmpty = true;
    }
  }

}
