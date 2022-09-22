import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BackendService } from './backend.service';
import {UserResponseModel} from 'src/app/models/auth/login.response'
import { LogInModel } from '../models/auth/login.model';
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(protected backendService : BackendService) {

  }

  login(model : LogInModel) : Observable<UserResponseModel>{
    return this.backendService.post('api/user/authentication/log-in', null, model);
  }
}