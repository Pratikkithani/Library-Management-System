  import { Component, OnInit } from '@angular/core';
  import { Router, RouterModule } from '@angular/router';
  import { RouterService } from '../../services/router.service';
  import { CommonModule } from '@angular/common';
  import { FormsModule } from '@angular/forms';
  import { LoginService } from '../../services/login.service';
import { TokenService } from '../../services/token.service';

  @Component({
    selector: 'app-header',
    standalone: true,
    imports: [RouterModule,CommonModule,FormsModule],
    templateUrl: './header.component.html',
    styleUrl: './header.component.css'
  })
  export class HeaderComponent {

    constructor(public userservice: LoginService,private router:Router,public tokenservice:TokenService) {}


    logout() {
      localStorage.clear();
      this.router.navigate(['/login']); 
    }
  }
