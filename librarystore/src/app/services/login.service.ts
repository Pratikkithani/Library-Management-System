import { HttpClient } from '@angular/common/http';
import { Inject, Injectable, PLATFORM_ID } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthResponseModel, Login } from '../model/login';
import { Register, RegistrationResponse } from '../model/register';
import { isPlatformBrowser } from '@angular/common';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  // private apiUrl="http://localhost:5036/api/Auth";
  private baseUrl = environment.apiUrl;

  //https://localhost:7134/api/Auth/login
  //https://localhost:7134/api/Auth/register
    constructor(private http:HttpClient,@Inject(PLATFORM_ID) private platformId: Object) { }
  
    login(loginData:Login):Observable<AuthResponseModel>{
      return this.http.post<AuthResponseModel>(`${this.baseUrl}/Auth/login`,loginData)
    }

    register(registerData:Register):Observable<RegistrationResponse>{
      return this.http.post<RegistrationResponse>(`${this.baseUrl}/Auth/register`,registerData)
    }

    isLoggedIn():boolean{
        return !!localStorage.getItem('token');
    }
    
}
