import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { BookService } from '../../services/book.service';
import { Book } from '../../model/book';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-default',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './default.component.html',
  styleUrl: './default.component.css'
})
export class DefaultComponent {
  books?:Book[];

  constructor(private bookService:BookService){}

  ngOnInit(){
    this.getAllBooks();
  }

  getAllBooks(): void {
      this.bookService.getAllBooks().subscribe((books:Book [] )=> {
        this.books=books;
        console.log(this.books);
      }); 
    }
}
