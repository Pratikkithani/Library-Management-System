import { Component } from '@angular/core';
import { LoanService } from '../../services/loan.service';
import { BookService } from '../../services/book.service';
import { Loan } from '../../model/loan';
import { Book } from '../../model/book';
import { FormsModule, NgForm } from '@angular/forms';
import Swal from 'sweetalert2';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-loan',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './add-loan.component.html',
  styleUrl: './add-loan.component.css'
})
export class AddLoanComponent {
  loans?: Loan[];
  books?: Book[];
  newLoan: Loan = new Loan();

  constructor(private loanService: LoanService, private bookService: BookService,private router:Router) {}

  ngOnInit() {
    this.getAllBooks();
  }

  getAllBooks(): void {
    this.bookService.getAvailableBooks().subscribe((books: Book[]) => {
      this.books = books;
      console.log(this.books);
    });
  }

  addLoan(addForm: NgForm): void {
  const loanRequest :Loan = {
    bookId: this.newLoan.bookId,
    memberId: this.newLoan.memberId
  };

  this.loanService.addLoan(loanRequest).subscribe(
    (res: Loan) => {
      console.log('Loan response:', res);
      Swal.fire('Success', 'Book Borrowed Successfully!', 'success');
      addForm.resetForm();
      this.newLoan = { bookId: undefined, memberId: undefined }; 
      this.router.navigateByUrl('/loan')

    },
    (error) => {
      console.error('Error borrowing book:', error);
      Swal.fire('Error', `Failed to borrow book: ${error.message}`, 'error');
    }
  );
}


}
