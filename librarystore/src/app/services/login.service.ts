import { HttpClient } from '@angular/common/http';
import { Inject, Injectable, PLATFORM_ID } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthResponseModel, Login } from '../model/login';
import { Register, RegistrationResponse } from '../model/register';
import { isPlatformBrowser } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private apiUrl="http://localhost:5036/api/Auth";
  //https://localhost:7134/api/Auth/login
  //https://localhost:7134/api/Auth/register
    constructor(private http:HttpClient,@Inject(PLATFORM_ID) private platformId: Object) { }
  
    login(loginData:Login):Observable<AuthResponseModel>{
      return this.http.post<AuthResponseModel>(`${this.apiUrl}/login`,loginData)
    }

    register(registerData:Register):Observable<RegistrationResponse>{
      return this.http.post<RegistrationResponse>(`${this.apiUrl}/register`,registerData)
    }

    isLoggedIn():boolean{
        return !!localStorage.getItem('token');
    }
    
}
