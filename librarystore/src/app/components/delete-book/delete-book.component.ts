import { Component } from '@angular/core';
import Swal from 'sweetalert2';
import { BookService } from '../../services/book.service';
import { Book } from '../../model/book';

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
        Swal.fire('Deleted!', 'Book has been deleted.', 'success');
        this.getAllBooks(); 
      },
      (error) => {
        console.error('Error deleting book:', error);
        Swal.fire('Error!', 'Failed to delete book.', 'error');
      }
    );
  }
  
}
