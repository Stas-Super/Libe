import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Auth } from '../models/auth/auth';
import { BackendService } from './backend.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(protected backendService : BackendService) {

  }

  login(model : Auth): Observable<any>{
    return this.backendService.post('api/user/authentication/log-in', null, model);
  }
}
