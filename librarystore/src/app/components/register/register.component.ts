import { Component } from '@angular/core';
import { Register } from '../../model/register';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoginService } from '../../services/login.service';
import Swal from 'sweetalert2';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule,RouterModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {

  registerForm!:FormGroup
  errorMsg='';
  constructor(private fb:FormBuilder,private userService:LoginService){

  }

  ngOnInit():void{
    this.registerForm=this.fb.group({
      firstName:['',Validators.required],
      lastName:['',Validators.required],
      email:['',[Validators.required,Validators.email]],
      userName:['',Validators.required],
      password:['',Validators.required]

    })
  }

  registerUser(user:FormGroup){
    this.userService.register(user.value).subscribe({
      next:(response)=>{
        console.log(response);
        Swal.fire('Success', 'Register Successful!', 'success')
        this.registerForm!.reset();
      },
      error:(error)=>{
        console.error('Resgister failed',error)
        this.errorMsg=JSON.stringify(error.error)
        alert(this.errorMsg)
      }
    })
  }




}
