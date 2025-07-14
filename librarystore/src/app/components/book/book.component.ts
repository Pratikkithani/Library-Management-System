import { Component, OnInit } from '@angular/core';
import { BookService } from '../../services/book.service';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Book } from '../../model/book';
import { Router, RouterModule } from '@angular/router';
import Swal from 'sweetalert2';
import { Category } from '../../model/category';
import { CategoryService } from '../../services/category.service';

@Component({
  selector: 'app-book',
  standalone: true,
  imports: [FormsModule,CommonModule,RouterModule],
  templateUrl: './book.component.html',
  styleUrl: './book.component.css'
})
export class BookComponent {
  newBook: Book = new Book();
  books?:Book[];
  categories?:Category[];
  searchId: number = 0;
  searchedBook? = new Book(); 


  constructor(private bookService:BookService,private categoryService:CategoryService,private router:Router) {}

  ngOnInit(){
    this.getAllBooks();
    this.getAllCategories();
  }
  getAllCategories(): void {
    this.categoryService.getAllCategories().subscribe((categories:Category[])=>{
      this.categories=categories;
      console.log(this.categories);
    }); 
  }

  getBookById() {
    this.bookService.getBookById(this.searchId).subscribe(
      (book: Book) => {
        this.searchedBook = book;
    });
  }

  getAllBooks(): void {
    this.bookService.getAllBooks().subscribe((books:Book [] )=> {
      this.books=books;
      console.log(this.books);
    }); 
  }

  deleteBookById(bookId: number) {
    if (bookId === undefined) {
      console.error('Book ID is undefined, cannot delete.');
      Swal.fire('Error!', 'Invalid book ID.', 'error');
      return;
    }
      this.bookService.deleteBook(bookId).subscribe(
        () => {
          console.log('Book deleted successfully');
          Swal.fire('Deleted!', 'Book has been deleted.', 'success');
          this.getAllBooks(); 
        },
        (error) => {
          console.error('Error deleting book:', error);
          Swal.fire('Error!', 'Failed to delete book.', 'error');
        }
      );
    }

    updateBook(updateBookForm: NgForm): void {
        if (!this.searchedBook) {
          Swal.fire('Error', 'No book selected for update!', 'error');
          return;
        }
    
        this.bookService.updateBook(this.searchedBook).subscribe(
          (res) => {
            Swal.fire('Success', 'Book Updated Successfully!', 'success');
            updateBookForm.reset();
            this.searchedBook = undefined;
          },
          (error) => {
            Swal.fire('Error', 'Failed to update book!', 'error');
            console.error('Update failed:', error);
          }
        );
      }


      updateBookById(bookId: number) {
        this.router.navigate(['/updatebook', bookId]); // Navigate to update page
      }
}
