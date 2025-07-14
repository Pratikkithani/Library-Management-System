import { Component } from '@angular/core';
import { LoanService } from '../../services/loan.service';
import { Loan } from '../../model/loan';
import { CommonModule } from '@angular/common';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-loan',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './loan.component.html',
  styleUrl: './loan.component.css'
})
export class LoanComponent {
  loans?: Loan[];
  userloans?: Loan[];

  ngOnInit(){
    this.getAllLoans();
    this.getAllLoansByUserId();
  }

  constructor(private loanservice:LoanService){}
  getAllLoans(): void {
    this.loanservice.getAllLoans().subscribe((loans:Loan [] )=> {
      this.loans=loans;
      console.log(loans);
    }); 
  }

  getAllLoansByUserId(): void {
    this.loanservice.getAllLoansByUserId().subscribe((userloans:Loan [] )=> {
      this.userloans=userloans;
      console.log(userloans);
    }); 
  }


  updateLoanStatus(loanId : number) : void{
    this.loanservice.deleteLoan(loanId).subscribe(res=>{
            Swal.fire('Success', 'Book Returned Successfully!', 'success').then(()=>{
              this.getAllLoans();
            })
    })
  }
}
