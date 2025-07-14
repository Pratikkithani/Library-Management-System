import { Component } from '@angular/core';
import Swal from 'sweetalert2';
import { Category } from '../../model/category';
import { CategoryService } from '../../services/category.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-search-category',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './search-category.component.html',
  styleUrl: './search-category.component.css'
})
export class SearchCategoryComponent {

  searchId: number = 0;
  searchedCategory?: Category | null = null;
  categories?:Category[];
  
  constructor(private categoryService:CategoryService) {}
  
    getAllCategories(): void {
      this.categoryService.getAllCategories().subscribe((categories:Category[])=>{
        this.categories=categories;
      }); 
    }
    
    getCategoryById(): void {
      this.categoryService.getCategoryById(this.searchId).subscribe(
        (category: Category) => {
          // Check if book is valid (not null, undefined, or an empty object)
          if (category && category.categoryId) {  
            this.searchedCategory = category;
            Swal.fire('Success', 'Category Found!', 'success');
          } else {
            this.searchedCategory = null;
            Swal.fire('Error', 'Category not found!', 'error');
          }
        },
        (error) => {
          this.searchedCategory = null;
          Swal.fire('Error', 'Category not found!', 'error');
          console.error('Category not found:', error);
        }
      );
    }
}
