import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Book } from '../model/book';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  private http = inject(HttpClient);
  private baseUrl = environment.apiUrl;


  getAllBooks():Observable<Book[]>{
    return this.http.get<Book[]>(`${this.baseUrl}/Book`);
  }

  getAvailableBooks():Observable<Book[]>{
    return this.http.get<Book[]>(`${this.baseUrl}/Book/getavailbooks`);
  }

  addBook(book: Book):Observable<Book> {
    return this.http.post<Book>(`${this.baseUrl}/Book`, book);
 }
  getBookById(id: number):Observable<Book> {
    return this.http.get<Book>(`${this.baseUrl}/Book/${id}`);
  }

  updateBook(book:Book):Observable<Book> {
    return this.http.put<Book>(`${this.baseUrl}/Book/${book.bookId}`, book);
  }

  deleteBook(bookId:number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/Book/${bookId}`);
  }  

  
}
