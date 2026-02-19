import { Component } from '@angular/core';
import Swal from 'sweetalert2';
import { BookService } from '../../services/book.service';
import { Book } from '../../model/book';
import { CustomSwal } from '../../services/swal.configuration';

@Component({
  selector: 'app-delete-book',
  standalone: true,
  imports: [],
  templateUrl: './delete-book.component.html',
  styleUrl: './delete-book.component.css'
})
export class DeleteBookComponent {

  books?:Book[];
  constructor(private bookService:BookService){}


  getAllBooks(): void {
      this.bookService.getAllBooks().subscribe((books:Book [] )=> {
        this.books=books;
        console.log(this.books);
      }); 
    }


  deleteBookById(bookId: number) {
    this.bookService.deleteBook(bookId).subscribe(
      () => {
        console.log('Book deleted successfully');
        CustomSwal.fire({
                title: 'Book has been deleted.',
                icon: 'success'
              })
        this.getAllBooks(); 
      },
      (error) => {
        console.error('Error deleting book:', error);
        CustomSwal.fire({
                title: 'Failed to delete book.',
                icon: 'error'
              })
      }
    );
  }
  
}
