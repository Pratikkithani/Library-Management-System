import { Component } from '@angular/core';
import { LoanService } from '../../services/loan.service';
import { Loan } from '../../model/loan';
import { CommonModule, DatePipe } from '@angular/common';
import Swal from 'sweetalert2';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MAT_DATE_LOCALE, MatNativeDateModule, provideNativeDateAdapter } from '@angular/material/core';
import { CustomSwal } from '../../services/swal.configuration';

@Component({
  selector: 'app-loan',
  standalone: true,
  providers: [
    provideNativeDateAdapter(),
    { provide: MAT_DATE_LOCALE, useValue: 'en-GB' },
    DatePipe
  ],
  imports: [CommonModule,FormsModule,ReactiveFormsModule, MatDatepickerModule, MatInputModule, MatNativeDateModule],
  templateUrl: './loan.component.html',
  styleUrl: './loan.component.css'
})
export class LoanComponent {
  loans?: Loan[];
  userloans?: Loan[];
  loansexample: any;

  bookFilter: string = '';
  memberFilter: string = '';
  statusFilter: string = '';
  loanDateFilter: string | null = null;
  dueDateFilter: string | null = null;
  returnDateFilter: string | null = null;
  isLoading: boolean = false;
  // Pagination
  currentPage: number = 1;
  pageSize: number = 5;   // rows per page

  pageSizeOptions: number[] = [5, 10, 20, 50];


  ngOnInit(){
    this.getAllLoans();
    this.getAllLoansByUserId();
  }

  constructor(private loanservice:LoanService){}

  buildFilters(): any {
  const filters: any = {};

  if (this.bookFilter && this.bookFilter.trim() !== '') {
    filters.Title = this.bookFilter.trim();
  }

  if (this.statusFilter && this.statusFilter.trim() !== '') {
    filters.Status = this.statusFilter.trim();
  }

  if (this.loanDateFilter) {
    filters.LoanDate = this.loanDateFilter;
  }

  if (this.dueDateFilter) {
    filters.DueDate = this.dueDateFilter;
  }

  if (this.returnDateFilter) {
    filters.ReturnDate = this.returnDateFilter;
  }

  return filters;
}

  
  getAllLoans(): void {
    this.loanservice.getAllLoans().subscribe((loans:Loan [] )=> {
      this.loans=loans;
      console.log(loans);
    }); 
  }

  getAllLoansByUserId(): void {
     const filters = this.buildFilters();
    let obj = {
      WhereCondition: JSON.stringify(filters)
    }
    this.isLoading = true;
    this.loanservice.getAllLoansByUserId(obj).subscribe((userloans:Loan [] )=> {
      this.userloans=userloans;
      this.loansexample = this.userloans;
      this.isLoading = false;
    }); 
  }


  updateLoanStatus(loanId : number) : void{
    this.loanservice.deleteLoan(loanId).subscribe(res=>{
            CustomSwal.fire({
                title: 'Book Returned Successfully!',
                icon: 'success'
              }).then(()=>{
              this.getAllLoans();
              this.getAllLoansByUserId();
            })
            // Swal.fire('Success', '', 'success').then(()=>{
            //   this.getAllLoans();
            //   this.getAllLoansByUserId();
            // })
    })
  }

  get filteredLoans(): any[] {
  return this.loansexample?.filter((loan: any) => {

    const loanDateStr = new Date(loan.loanDate).toISOString().split('T')[0];
    const dueDateStr = new Date(loan.dueDate).toISOString().split('T')[0];
    const returnDateStr = loan.returnDate
      ? new Date(loan.returnDate).toISOString().split('T')[0]
      : null;

    const matchesLoanDate =
      this.loanDateFilter ? loanDateStr === this.loanDateFilter : true;

    const matchesDueDate =
      this.dueDateFilter ? dueDateStr === this.dueDateFilter : true;

    const matchesReturnDate =
      this.returnDateFilter
        ? returnDateStr === this.returnDateFilter
        : true;

    return (
      loan.book.title.toLowerCase().includes(this.bookFilter.toLowerCase()) &&
      loan.member.name.toLowerCase().includes(this.memberFilter.toLowerCase()) &&
      loan.status.toLowerCase().includes(this.statusFilter.toLowerCase()) &&
      matchesLoanDate &&
      matchesDueDate &&
      matchesReturnDate
    );
  }) || [];
}

get paginatedLoans(): any[] {
  const startIndex = (this.currentPage - 1) * this.pageSize;
  return this.loansexample?.slice(startIndex, startIndex + this.pageSize);
}

get totalPages(): number {
  return Math.ceil(this.loansexample.length / this.pageSize);
}

previousPage() {
  if (this.currentPage > 1) {
    this.currentPage--;
  }
}

nextPage() {
  if (this.currentPage < this.totalPages) {
    this.currentPage++;
  }
}

changePageSize(size: number) {
  this.pageSize = Number(size);
  this.currentPage = 1;  // reset to first page
}


private filterTimeout: any;

onFilterChange() {
  clearTimeout(this.filterTimeout);

  this.filterTimeout = setTimeout(() => {
    this.getAllLoansByUserId();
  }, 500); // 500ms delay
}

clearFilter(type: string) {

  switch (type) {
    case 'loanDate':
      this.loanDateFilter = null;
      break;

    case 'dueDate':
      this.dueDateFilter = null;
      break;

    case 'returnDate':
      this.returnDateFilter = null;
      break;

    case 'book':
      this.bookFilter = '';
      break;

    case 'status':
      this.statusFilter = '';
      break;
  }

  this.currentPage = 1;      // reset pagination
  this.getAllLoansByUserId(); // refresh API
}


}
