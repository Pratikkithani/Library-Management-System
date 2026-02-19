import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Book } from '../model/book';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  private http = inject(HttpClient);

  getAllBooks():Observable<Book[]>{
    return this.http.get<Book[]>("http://localhost:5036/api/Book");
  }

  getAvailableBooks():Observable<Book[]>{
    return this.http.get<Book[]>("http://localhost:5036/api/Book/getavailbooks");
  }

  addBook(book: Book):Observable<Book> {
    return this.http.post<Book>('http://localhost:5036/api/Book', book);
 }
  getBookById(id: number):Observable<Book> {
    return this.http.get<Book>(`http://localhost:5036/api/Book/${id}`);
  }

  updateBook(book:Book):Observable<Book> {
    return this.http.put<Book>(`http://localhost:5036/api/Book/${book.bookId}`, book);
  }

  deleteBook(bookId:number): Observable<void> {
    return this.http.delete<void>(`http://localhost:5036/api/Book/${bookId}`);
  }  

  
}
