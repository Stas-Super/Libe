import { Component, OnInit } from '@angular/core';
import { Auth } from 'src/app/models/auth/auth';
import { AuthService } from 'src/app/services/auth.service';
import { BackendService } from 'src/app/services/backend.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  email : string = "";
  pass : string = "";
  constructor(private authService : AuthService) {

   }

  ngOnInit(): void {
  }

  login() :any{
    let model = new Auth();
    model.email = this.email;
    model.password = this.pass;
    this.authService.login(model).subscribe((response) =>{response.});
  }

}
