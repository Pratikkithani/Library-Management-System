import { Component } from '@angular/core';
import { Category } from '../../model/category';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { CategoryService } from '../../services/category.service';
import Swal from 'sweetalert2';
import { BookService } from '../../services/book.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-category',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './category.component.html',
  styleUrl: './category.component.css'
})
export class CategoryComponent {
  categories?:Category[];
    searchedCategory? = new Category(); 
  

  constructor(private categoryService:CategoryService,private categoryservice:CategoryService,private router:Router) { }

  ngOnInit(){
    this.getAllCategories();
  }
  getAllCategories(): void {
      this.categoryService.getAllCategories().subscribe((categories:Category[])=>{
        this.categories=categories;
      }); 
    }

    deleteCategoryById(categoryId: number) {
        if (categoryId === undefined) {
          console.error('Category ID is undefined, cannot delete.');
          Swal.fire('Error!', 'Invalid category ID.', 'error');
          return;
        }
          this.categoryservice.deleteCategory(categoryId).subscribe(
            () => {
              console.log('Category deleted successfully');
              Swal.fire('Deleted!', 'Category has been deleted.', 'success');
              this.getAllCategories(); 
            },
            (error) => {
              console.error('Error deleting book:', error);
              Swal.fire('Error!', 'Failed to delete book.', 'error');
            }
          );
        }
    
        updateCategory(updateBookForm: NgForm): void {
            if (!this.searchedCategory) {
              Swal.fire('Error', 'No book selected for update!', 'error');
              return;
            }
        
            this.categoryservice.updateCategory(this.searchedCategory).subscribe(
              (res) => {
                Swal.fire('Success', 'Book Updated Successfully!', 'success');
                updateBookForm.reset();
                this.searchedCategory = undefined;
              },
              (error) => {
                Swal.fire('Error', 'Failed to update book!', 'error');
                console.error('Update failed:', error);
              }
            );
          }
    
    
          updateCategoryById(categoryId: number) {
            this.router.navigate(['/updatecategory', categoryId]); // Navigate to update page
          }
}
