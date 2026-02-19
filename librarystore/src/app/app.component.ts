import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { BookComponent } from './components/book/book.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { HeaderComponent } from './components/header/header.component';
import { AddBookComponent } from './components/add-book/add-book.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,BookComponent,LoginComponent,RegisterComponent,HeaderComponent,AddBookComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  
})
export class AppComponent {
  title = 'librarystore';
}
