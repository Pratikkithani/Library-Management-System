import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from '../model/category';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private http = inject(HttpClient);
  private baseUrl = environment.apiUrl;
  
    getAllCategories():Observable<Category[]>{
      return this.http.get<Category[]>(`${this.baseUrl}/Category`);
    }

    addCategory(category: Category):Observable<Category> {
        return this.http.post<Category>(`${this.baseUrl}/Category`, category);
     }
      getCategoryById(id: number):Observable<Category> {
        return this.http.get<Category>(`${this.baseUrl}/Category/${id}` );
      }
    
      updateCategory(category:Category):Observable<Category> {
        return this.http.put<Category>(`${this.baseUrl}/Category/${category.categoryId}`, category);
      }

      deleteCategory(categoryId:number): Observable<void> {
        return this.http.delete<void>(`${this.baseUrl}/Category/${categoryId}`);
      }  
}
