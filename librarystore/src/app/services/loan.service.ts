import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Loan } from '../model/loan';
import { LoanDto } from '../model/loan-dto';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoanService {

  private http = inject(HttpClient);
  private baseUrl = environment.apiUrl;

   getAllLoans():Observable<Loan[]>{
      return this.http.get<Loan[]>(`${this.baseUrl}/Loan`);
    }

    getAllLoansByUserId(data:any):Observable<Loan[]>{
      return this.http.post<Loan[]>(`${this.baseUrl}/Loan/getall`,data);
    }

   addLoan(loan: Loan): Observable<LoanDto> {
    return this.http.post<LoanDto>(`${this.baseUrl}/Loan`, {
      bookId: loan.bookId
  });
}


    getLoanById(id: number):Observable<Loan> {
      return this.http.get<Loan>(`${this.baseUrl}/Loan/${id}` );
    }
  
    deleteLoan(loanId:number): Observable<void> {
      return this.http.delete<void>(`${this.baseUrl}/Loan/${loanId}`);
    }  
}
