import { Component } from '@angular/core';
import { BookService } from '../../services/book.service';
import { Book } from '../../model/book';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Category } from '../../model/category';
import { CategoryService } from '../../services/category.service';
import Swal from 'sweetalert2';
import { CustomSwal } from '../../services/swal.configuration';

@Component({
  selector: 'app-search-book',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './search-book.component.html',
  styleUrl: './search-book.component.css'
})
export class SearchBookComponent {

  searchId: number = 0;
  searchedBook?: Book | null = null;
  categories?:Category[];

  constructor(private bookService:BookService,private categoryService:CategoryService) {}

  getAllCategories(): void {
    this.categoryService.getAllCategories().subscribe((categories:Category[])=>{
      this.categories=categories;
    }); 
  }
  
  getBookById(): void {
    this.bookService.getBookById(this.searchId).subscribe(
      (book: Book) => {
        // Check if book is valid (not null, undefined, or an empty object)
        if (book && book.bookId) {  
          this.searchedBook = book;
          CustomSwal.fire({
                title: 'Book Found!',
                icon: 'success'
              })
        } else {
          this.searchedBook = null;
          CustomSwal.fire({
                title: 'Book not found!',
                icon: 'error'
              })
        }
      },
      (error) => {
        this.searchedBook = null;
        CustomSwal.fire({
                title: 'Book not found!',
                icon: 'error'
              })
        console.error('Book not found:', error);
      }
    );
  }
  
}
