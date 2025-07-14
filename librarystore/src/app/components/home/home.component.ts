import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

      username: string | null = '';

      ngOnInit():void{
        this.username = localStorage.getItem('username');
        console.log('Username:', this.username);
      }
  
}
