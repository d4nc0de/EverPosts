import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { appsettigns } from '../settings/appsettings';
import { User } from '../Interfaces/User';
import { Observable } from 'rxjs';
import { BaseResponse } from '../Interfaces/BaseResponse';
import { Login } from '../Interfaces/Login';

@Injectable({
  providedIn: 'root'
})
export class AccessService {

  private http = inject(HttpClient)
  private baseUrl:string = appsettigns.apiUrl;


  constructor() { }

  register(objeto:User): Observable<BaseResponse<boolean>>
  {
    return this.http.post<BaseResponse<boolean>>(`${this.baseUrl}Access/Register`,objeto);    
  }

  login(objeto:Login): Observable<BaseResponse<string>>
  {
    return this.http.post<BaseResponse<string>>(`${this.baseUrl}Access/Login`,objeto);    
  }


}
