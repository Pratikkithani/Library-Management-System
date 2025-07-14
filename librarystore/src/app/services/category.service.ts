import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from '../model/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private http = inject(HttpClient);
  
    getAllCategories():Observable<Category[]>{
      return this.http.get<Category[]>("http://localhost:5036/api/Category");
    }

    addCategory(category: Category):Observable<Category> {
        return this.http.post<Category>('http://localhost:5036/api/Category', category);
     }
      getCategoryById(id: number):Observable<Category> {
        return this.http.get<Category>(`http://localhost:5036/api/Category/${id}` );
      }
    
      updateCategory(category:Category):Observable<Category> {
        return this.http.put<Category>(`http://localhost:5036/api/Category/${category.categoryId}`, category);
      }

      deleteCategory(categoryId:number): Observable<void> {
        return this.http.delete<void>(`http://localhost:5036/api/Category/${categoryId}`);
      }  
}
