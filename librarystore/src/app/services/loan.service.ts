import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Loan } from '../model/loan';
import { LoanDto } from '../model/loan-dto';

@Injectable({
  providedIn: 'root'
})
export class LoanService {

  private http = inject(HttpClient);

   getAllLoans():Observable<Loan[]>{
      return this.http.get<Loan[]>("http://localhost:5036/api/Loan");
    }

    getAllLoansByUserId():Observable<Loan[]>{
      return this.http.get<Loan[]>("http://localhost:5036/api/Loan/getall");
    }

   addLoan(loan: Loan): Observable<LoanDto> {
    return this.http.post<LoanDto>('http://localhost:5036/api/Loan', {
      bookId: loan.bookId
  });
}


    getLoanById(id: number):Observable<Loan> {
      return this.http.get<Loan>(`http://localhost:5036/api/Loan/${id}` );
    }
  
    deleteLoan(loanId:number): Observable<void> {
      return this.http.delete<void>(`http://localhost:5036/api/Loan/${loanId}`);
    }  
}
