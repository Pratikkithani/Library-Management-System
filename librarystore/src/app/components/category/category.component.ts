import { Component } from '@angular/core';
import { Category } from '../../model/category';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { CategoryService } from '../../services/category.service';
import Swal from 'sweetalert2';
import { BookService } from '../../services/book.service';
import { Router } from '@angular/router';
import { CustomSwal } from '../../services/swal.configuration';

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
          CustomSwal.fire({
              title: 'Invalid category ID.',
              icon: 'error'
            })
          return;
        }
          this.categoryservice.deleteCategory(categoryId).subscribe(
            () => {
              console.log('Category deleted successfully');
              CustomSwal.fire({
                title: 'Category has been deleted.',
                icon: 'success'
              })
              this.getAllCategories(); 
            },
            (error) => {
              console.error('Error deleting book:', error);
              CustomSwal.fire({
                title: 'Failed to delete book.',
                icon: 'error'
              })
            }
          );
        }
    
        updateCategory(updateBookForm: NgForm): void {
            if (!this.searchedCategory) {
              CustomSwal.fire({
                title: 'No book selected for update!',
                icon: 'error'
              })
              return;
            }
        
            this.categoryservice.updateCategory(this.searchedCategory).subscribe(
              (res) => {
                CustomSwal.fire({
                title: 'Book Updated Successfully!',
                icon: 'success'
              })
                updateBookForm.reset();
                this.searchedCategory = undefined;
              },
              (error) => {
                CustomSwal.fire({
                  title: 'Failed to update book!',
                  icon: 'error'
                })
                console.error('Update failed:', error);
              }
            );
          }
    
    
          updateCategoryById(categoryId: number) {
            this.router.navigate(['/updatecategory', categoryId]); // Navigate to update page
          }
}
