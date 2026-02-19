import { Component } from '@angular/core';
import { AuthResponseModel, Login } from '../../model/login';
import { LoginService } from '../../services/login.service';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';
import Swal from 'sweetalert2';
import { RouterModule } from '@angular/router';
import { Router } from '@angular/router';
import { TokenService } from '../../services/token.service';
import { CustomSwal } from '../../services/swal.configuration';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule,CommonModule,RouterModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginModel:Login=new Login('','');
  errorMsg='';
  constructor(private userService:LoginService,private router: Router,private tokenservice:TokenService){}

  loginUser(loginForm:NgForm){
    this.loginModel=loginForm.value;
    console.log(this.loginModel);
    this.userService.login(this.loginModel).subscribe({
      next:(response:AuthResponseModel)=>{
        console.log('Login Succes',response);
        localStorage.setItem('token',response.token)
        localStorage.setItem('username',response.userName)
        console.log(this.tokenservice.getUserRole())
        CustomSwal.fire({
                title: 'Login Successful!',
                icon: 'success'
              }).then(() => {
          this.router.navigateByUrl('/home');  
        });
        // Swal.fire('Success', '', 'success').then(() => {
        //   this.router.navigateByUrl('/home');  
        // });

        loginForm.reset();
       
      },
      error:(error)=>{
        console.error('LoginFailed',error)
        this.errorMsg=JSON.stringify(error.error)
        CustomSwal.fire({
                title: this.errorMsg,
                icon: 'error'
              })
      }
    })
    
    }
}
