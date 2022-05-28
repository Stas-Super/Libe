import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BackendService {

  baseHost : string = "";
  constructor(protected _http : HttpClient) {
    this.baseHost = environment.baseHost;
  }

  get(url : string, arg? : any) : any {
    this._http.get(`${this.baseHost}${url}`, );
  }

  post(url : string, arg? : any, data?: any) : any{
    this._http.post(`${this.baseHost}${url}`, JSON.stringify(data));
  }

  put(url : string, arg? : any, data? : any) : any{

  }

  delete(url : string, arg? : any) : any{

  }
}
